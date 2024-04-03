using Carter;

namespace Blog.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddCors()
                .AddEndpointsApiExplorer()
                .AddCarter()
                .AddSwaggerGen();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger()
                    .UseSwaggerUI();
            }
        }
    }
}
