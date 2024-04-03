using Blog.Entities;
using Blog.Models.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Endpoints
{
    public static class Tags
    {
        public static void RegisterTagEndpoints(this IEndpointRouteBuilder routes)
        {
            // CRUD Tag
            var tags = routes.MapGroup("/api/tags").WithTags("Tags");

            // GET
            tags.MapGet("/", (AppDbContext dbContext) => dbContext.Tags.Select( p => new TagDto()
            {
                Id = p.Id,
                Name = p.Name,

            }));

            tags.MapGet("/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                return dbContext.Tags.Select(p => new TagDto()
                {
                    Id = p.Id,
                    Name = p.Name,
            
                }).SingleOrDefault(t => t.Id == id);
            });
            
            // POST
            tags.MapPost("/", async (TagCreateDto tag, AppDbContext dbContext) =>
            {
                var newTag = new Tag()
                {
                    Name = tag.Name,
                };
            
                dbContext.Tags.Add(newTag);
                await dbContext.SaveChangesAsync();
            });
            
            // PUT
            tags.MapPut("/{id}", async ([FromRoute] int id, TagUpdateDto tag, AppDbContext dbContext) =>
            {
                var currentTag = dbContext.Tags.SingleOrDefault(t => t.Id == id) ?? throw new Exception("Tag с таким Id не найден");
            
                currentTag.Name = tag.Name;
            
                await dbContext.SaveChangesAsync();
            });
            
            // DELETE
            tags.MapDelete("/{id}", async ([FromRoute] int id, AppDbContext dbContext) =>
            {
                var tagDelete = dbContext.Tags.FirstOrDefault(t => t.Id == id) ?? throw new Exception("Tag с таким Id не найден");
            
                dbContext.Tags.Remove(tagDelete);
            
                await dbContext.SaveChangesAsync();
            });
        }
    }
}
