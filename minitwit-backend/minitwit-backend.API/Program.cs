using Microsoft.EntityFrameworkCore;
using minitwit_backend.Controllers;
using minitwit_backend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<MinitwitContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


var app = builder.Build();

app.RegisterMapMiddleware();

app.Run();
