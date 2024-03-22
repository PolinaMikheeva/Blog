using Blog.Data;
using Blog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Endpoints
{
    public static class Posts
    {
        public static void RegisterPostEndpoints(this IEndpointRouteBuilder routes)
        {
            // CRUD Post

            var posts = routes.MapGroup("/api/v1/posts");

            posts.MapGet("/posts", (AppDbContext dbContext) => dbContext.Posts);

            posts.MapGet("/post/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                return dbContext.Posts.FirstOrDefault(post => post.Id == id);
            });

            posts.MapPost("/post", (Post post, AppDbContext dbContext) => dbContext.Posts.Add(post));

            posts.MapPut("/post/{id}", ([FromRoute] int id, Post post, AppDbContext dbContext) =>
            {
                Post currentPost = dbContext.Posts.FirstOrDefault(post => post.Id == id);

                currentPost.UserId = post.UserId;
                currentPost.Description = post.Description;
                currentPost.Views = post.Views;
                currentPost.Title = post.Title;
                currentPost.Complexity = post.Complexity;
                currentPost.MinDescription = post.MinDescription;
                currentPost.TimeReading = post.TimeReading;
            });

            posts.MapDelete("/post/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                var postDelete = dbContext.Posts.FirstOrDefault(post => post.Id == id);

                dbContext.Posts.Remove(postDelete);
            });
        }
    }
}