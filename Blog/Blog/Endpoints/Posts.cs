using Blog.Entities;
using Blog.Models.Post;
using Blog.Models.Tag;
using Blog.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Endpoints
{
    public static class Posts
    {
        public static void RegisterPostEndpoints(this IEndpointRouteBuilder routes)
        {
            // CRUD Post
            var posts = routes.MapGroup("/api/posts").WithTags("Posts");

            // GET
            posts.MapGet("/", (AppDbContext dbContext) =>
            dbContext.Posts.Include(p => p.User).Select(p => new PostDto()
            {
                Id = p.Id,
                Title = p.Title,
                UserFullName = p.User.FullName,
                Description = p.Description,
                Complexity = p.Complexity,
                MinDescription = p.MinDescription,
                TimeReading = p.TimeReading,
                Views = p.Views,

                User = new UserDto()
                {
                    FullName = p.User.FullName,
                    Email = p.User.Email,
                },

                Tags = p.Tags.Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList()

            }));

            posts.MapGet("/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                return dbContext.Posts.Include(t => t.Tags).Select(p => new PostDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    UserFullName = p.User.FullName,
                    Description = p.Description,
                    Complexity = p.Complexity,
                    MinDescription = p.MinDescription,
                    TimeReading = p.TimeReading,
                    Views = p.Views,

                    User = new UserDto()
                    {
                        FullName = p.User.FullName,
                        Email = p.User.Email,
                    },

                    Tags = p.Tags.Select(t => new TagDto
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList()
                })
                .FirstOrDefault(post => post.Id == id);
            });
            
            // POST
            posts.MapPost("/", async (PostCreateDto post, AppDbContext dbContext) =>
            {
                var newPost = new Post()
                {
                    Title = post.Title,
                    Description = post.Description,
                    MinDescription = post.MinDescription,
                    Complexity = post.Complexity,
                    TimeReading = post.TimeReading,
                    Views = post.Views,
            
                    UserId = post.UserId
                };

                if (post.Tags.Count() > 0)
                    newPost.Tags = await dbContext.Tags.Where(t => post.Tags.Contains(t.Id)).ToListAsync();

                dbContext.Posts.Add(newPost);
                await dbContext.SaveChangesAsync();
            });
            
            // PUT
            posts.MapPut("/{id}", async ([FromRoute] int id, PostUpdateDto post, AppDbContext dbContext) =>
            {
                var currentPost = dbContext.Posts.Include(t => t.Tags).SingleOrDefault(post => post.Id == id) ?? throw new Exception("Post с таким Id не найден");
            
                currentPost.Description = post.Description;
                currentPost.Views = post.Views;
                currentPost.Title = post.Title;
                currentPost.Complexity = post.Complexity;
                currentPost.MinDescription = post.MinDescription;
                currentPost.TimeReading = post.TimeReading;
                currentPost.UserId = post.UserId;

                if (post.Tags.Count() > 0)
                    currentPost.Tags = await dbContext.Tags.Where(t => post.Tags.Contains(t.Id)).ToListAsync();
                else if(currentPost.Tags?.Count > 0)
                    currentPost.Tags.Clear();

                dbContext.Update(currentPost);
                await dbContext.SaveChangesAsync();
            });
            
            // DELETE
            posts.MapDelete("/{id}", async ([FromRoute] int id, AppDbContext dbContext) =>
            {
                var postDelete = dbContext.Posts.SingleOrDefault(post => post.Id == id) ?? throw new Exception("Post с таким Id не найден");
            
                dbContext.Posts.Remove(postDelete);
                await dbContext.SaveChangesAsync();
            });
        }
    }
}