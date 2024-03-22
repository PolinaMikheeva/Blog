using Blog.Data;
using Blog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Endpoints
{
    public static class Users
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder routes)
        {
            // CRUD User
            var users = routes.MapGroup("/api/v1/users");

            users.MapGet("/users", (AppDbContext dbContext) => dbContext.Users);

            users.MapGet("/users/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                return dbContext.Users.FirstOrDefault(user => user.Id == id);
            });

            users.MapPost("/user", (User user, AppDbContext dbContext) => dbContext.Users.Add(user));

            users.MapPut("/user/{id}", ([FromRoute] int id, User user, AppDbContext dbContext) =>
            {
                User currentUser = dbContext.Users.FirstOrDefault(user => user.Id == id);

                currentUser.FullName = user.FullName;
                currentUser.Email = user.Email;
            });

            users.MapDelete("/user/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                var userDelete = dbContext.Users.FirstOrDefault(user => user.Id == id);

                dbContext.Users.Remove(userDelete);
            });
        }
    }
}
