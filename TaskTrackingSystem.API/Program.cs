using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskTrackingSystem.API.Middleware;
using TaskTrackingSystem.Application;
using TaskTrackingSystem.Infrastructure;
using TaskTrackingSystem.Infrastructure.Persistence;

namespace TaskTrackingSystem.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Clean Architecture DI
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Task Tracking System API",
                Version = "v1",
                Description = """
                    Backend API for the Team Sprint Planning Board — an agile project management tool for small teams.

                    ## Authentication
                    All endpoints except **Register** and **Login** require a valid JWT bearer token.
                    Obtain a token via `POST /api/auth/login` and include it in the `Authorization` header as `Bearer {token}`.

                    ## Roles
                    - **Admin** — can manage teams, view all users, create sprints for any team, and access all resources.
                    - **Member** — can view and manage resources within their own team only.

                    ## Error Responses
                    All error responses follow a consistent shape:
                    ```json
                    {
                      "message": "Error description",
                      "errors": { "FieldName": ["Validation error message"] }
                    }
                    ```
                    The `errors` property is only present on `400 Validation Failed` responses.
                    """,
                Contact = new OpenApiContact
                {
                    Name = "Task Tracking System"
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter the JWT token obtained from the /api/auth/login endpoint."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            // Include XML comments from API project
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            // Tag descriptions for grouping in Swagger UI
            options.TagActionsBy(api => new[] { api.GroupName ?? api.ActionDescriptor.RouteValues["controller"]! });
        });

        var app = builder.Build();

        // Middleware pipeline
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseCors(policy =>
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Task Tracking System API";
                options.DefaultModelsExpandDepth(1);
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        // Auto-migrate database (applies pending migrations + seed data)
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
        }

        app.Run();
    }
}
