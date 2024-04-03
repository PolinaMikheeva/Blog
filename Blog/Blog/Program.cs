using Blog;
using Blog.Endpoints;
using Blog.Extensions;
using Microsoft.EntityFrameworkCore;

// Нстройка IOC контейнера

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.RegisterServices();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultValue")));

// Нстройка Pipeline

var app = builder.Build();

// Configure the HTTP request pipeline.
app.RegisterMiddlewares();

app.RegisterPostEndpoints();
app.RegisterTagEndpoints();
app.RegisterUserEndpoints();

app.Run();