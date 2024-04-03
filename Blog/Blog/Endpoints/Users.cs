using Blog.Entities;
using Blog.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Endpoints
{
    public static class Users
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder routes)
        {
            // CRUD User
            var users = routes.MapGroup("/api/users").WithTags("Users");            

            // GET
            users.MapGet("/", (AppDbContext dbContext) => dbContext.Users.Select(u => new UserDto()
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
            }));
            
            users.MapGet("/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                return dbContext.Users.Select(u => new UserDto()
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                }).SingleOrDefault(user => user.Id == id);
            });
            
            // POST
            users.MapPost("/", async (UserCreateDto user, AppDbContext dbContext) =>
            {
                var newUser = new User()
                {
                    FullName = user.FullName,
                    Email = user.Email
                };

                dbContext.Users.Add(newUser);
                await dbContext.SaveChangesAsync();
            });
            
            // PUT
            users.MapPut("/{id}", async ([FromRoute] int id, UserUpdateDto user, AppDbContext dbContext) =>
            {
                var currentUser = dbContext.Users.SingleOrDefault(user => user.Id == id);
            
                currentUser.FullName = user.FullName;
                currentUser.Email = user.Email;

                await dbContext.SaveChangesAsync();
            });
            
            // DELETE
            users.MapDelete("/{id}", async ([FromRoute] int id, AppDbContext dbContext) =>
            {
                var userDelete = dbContext.Users.SingleOrDefault(user => user.Id == id);
            
                dbContext.Users.Remove(userDelete);

                await dbContext.SaveChangesAsync();
            });
        }
    }
}
