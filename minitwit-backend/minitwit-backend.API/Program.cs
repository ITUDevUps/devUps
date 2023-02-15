using System.Net;
using System.Reflection;
using minitwit_backend.Data;
using minitwit_backend.Data.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<MinitwitContext>();


builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapGet("/GetMessages",async () =>
{
    using var repo = new MessageRepository(new MinitwitContext());
    return await repo.GetMessagesAsync();
});
app.MapGet("/GetMessages/{userName}", async (string userName) =>
{
    using var repo = new MessageRepository(new MinitwitContext());
    return await repo.GetMessagesAsyncByUserName(userName);
});


app.MapPost("/api-sim/register", (ApiSimUser user) =>
{
    var error = string.Empty;
    try
    {
        if (String.IsNullOrEmpty(user.UserName))
        {
            error = "You have to enter a username";
        } 
        else if (String.IsNullOrEmpty(user.Email) || !user.Email.Contains('@'))
        {
            error = "You have to enter a valid email address";
        } 
        else if (String.IsNullOrEmpty(user.Password))
        {
            error = "You have to enter a password";
        } //also needs to check if username exists
        else
        {
            using var repo = new UserRepository(new MinitwitContext());
            repo.RegisterUser(user);
        }
    }
    catch (Exception e)
    {
        error = e.Message;
    }
    if (error != string.Empty)
    {
        return Results.BadRequest(error);
    }
    return Results.NoContent();
});

app.MapPost("/api-sim/fllws/{username}", (string username, ApiSimFollow follow) =>
{
    try
    {
        var context = new MinitwitContext();

        using var userRepo = new UserRepository(context);

        if (!userRepo.TryGetUserId(username, out var userId))
        {
            return Results.NotFound(username);
        }

        if (!string.IsNullOrEmpty(follow.Follow))
        {
            if (!userRepo.TryGetUserId(follow.Follow, out var followId))
            {
                return Results.NotFound(follow.UnFollow);
            }

            using var followerRepo = new FollowerRepository(context);
            followerRepo.Follow(userId, followId);
        }
        else if (!string.IsNullOrEmpty(follow.UnFollow))
        {
            if (!userRepo.TryGetUserId(follow.UnFollow, out var unFollowId))
            {
                return Results.NotFound(follow.UnFollow);
            }

            using var followerRepo = new FollowerRepository(context);
            followerRepo.Follow(userId, unFollowId);
        }
    }
    catch (Exception e)
    {
        return Results.NotFound(e);
    }
    return Results.NoContent();
});


app.Run();
