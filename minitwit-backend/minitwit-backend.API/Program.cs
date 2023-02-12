using minitwit_backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<MinitwitContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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


app.Run();