using System.Reflection;
using minitwit_backend.Data;
using minitwit_backend.controller;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Could be moved too.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<MinitwitContext>();

builder.Services.AddCors();

var app = builder.Build();

// Endpoints moved to controller
app.RegisterMapMiddleware();
app.RegisterMessageEndpoints();

app.Run();
