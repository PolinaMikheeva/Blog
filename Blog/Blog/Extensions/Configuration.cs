using Carter;

namespace Blog.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddEndpointsApiExplorer()
                .AddCarter()
                .AddSwaggerGen();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            app.UseAntiforgery();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger()
                    .UseSwaggerUI();
            }

            app.MapCarter();
        }
    }
}
