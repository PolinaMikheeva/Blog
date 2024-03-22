using Blog.Data;
using Blog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Endpoints
{
    public static class Tags
    {
        public static void RegisterTagEndpoints(this IEndpointRouteBuilder routes)
        {
            // CRUD Tag
            var tags = routes.MapGroup("/api/v1/tags");

            tags.MapGet("/", (AppDbContext dbContext) => dbContext.Tags);

            tags.MapGet("/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                return dbContext.Tags.FirstOrDefault(t => t.Id == id);
            });

            tags.MapPost("/", (Tag tag, AppDbContext dbContext) => dbContext.Tags.Add(tag));

            tags.MapPut("/{id}", ([FromRoute] int id, Tag tag, AppDbContext dbContext) =>
            {
                Tag currentTag = dbContext.Tags.FirstOrDefault(t => t.Id == id);

                currentTag.Name = tag.Name;
            });

            tags.MapDelete("/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                var tagDelete = dbContext.Tags.FirstOrDefault(t => t.Id == id);

                dbContext.Tags.Remove(tagDelete);
            });
        }
    }
}
