using Blog;
using Blog.Endpoints;
using Blog.Entities;
using Blog.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;

// Нстройка IOC контейнера

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.RegisterServices();
builder.Services.AddAntiforgery();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultValue")));

// Нстройка Pipeline

var app = builder.Build();

// Configure the HTTP request pipeline.
app.RegisterMiddlewares();
app.RegisterPostEndpoints();
app.RegisterTagEndpoints();
app.UseAntiforgery();

app.MapGet("/posts", () =>
{
    return "BLog";
});

/*
// CRUD creat - read - update -delete

app.MapGet("/posts/{id}", ([FromRoute] int id) =>
{
    return "posts";
});

//app.MapPost("/posts/{id}", ([FromRoute] int id, 
//                           [FromForm] Post post,
//                          [FromServices] AppDbContext dbContext) =>
//{
//    return "posts";
//});

app.MapPut("/posts/{id}", (int id, Post post) =>
{
    return "posts";
});

app.MapDelete("/posts/{id}", (int id, Post post) =>
{
    return "posts";
});

app.MapPatch("/posts/{id}", (int id, Post post) =>
{
    return "posts";
});
*/


app.Run();