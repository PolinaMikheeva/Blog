using Blog.Data;
using Blog.Entities;
using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Modules.Users
{
    public class Endpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            // CRUD User

            app.MapGet("/users", (AppDbContext dbContext) => dbContext.Users);

            app.MapGet("/users/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                return dbContext.Users.FirstOrDefault(user => user.Id == id);
            });

            app.MapPost("/user", (User user, AppDbContext dbContext) => dbContext.Users.Add(user));

            app.MapPut("/user/{id}", ([FromRoute] int id, User user, AppDbContext dbContext) =>
            {
                User currentUser = dbContext.Users.FirstOrDefault(user => user.Id == id);

                currentUser.FullName = user.FullName;
                currentUser.Email = user.Email;
            });

            app.MapDelete("/user/{id}", ([FromRoute] int id, AppDbContext dbContext) =>
            {
                var userDelete = dbContext.Users.FirstOrDefault(user => user.Id == id);

                dbContext.Users.Remove(userDelete);
            });
        }
    }
}
