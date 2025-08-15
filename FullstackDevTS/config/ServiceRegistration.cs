using FullstackDevTS.Commands.Handler;
using FullstackDevTS.Db;
using FullstackDevTS.Models.Entities;
using FullstackDevTS.Repositories;
using FullstackDevTS.Repositories.TestRepository;
using FullstackDevTS.Services;
using FullstackDevTS.Services.Implementation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.OpenApi.Models;
namespace FullstackDevTS.Config;

public class ServiceRegistration
{
    public void OnLoad(IServiceCollection services, IConfiguration configuration)
    {
        AddLocalDatabase(services, configuration);
        ServiceOnLoad(services);
        SwaggerOnload(services);
    }
    
    private static void AddLocalDatabase(IServiceCollection services, IConfiguration configuration)
    {
        var localConnectionString = configuration["connectionStrings:local_db"];
    
        services.AddDbContext<ApplicationDatabaseContext>(options => 
            options.UseSqlServer(localConnectionString,
                    provider => provider.EnableRetryOnFailure())
                .LogTo(Console.WriteLine, LogLevel.Information)
        );
    }

    private void ServiceOnLoad(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddScoped(typeof(IRepository<TestModel>),typeof(TestRepositoryData));
        services.AddScoped<ITestService, TestService>();
        
        services.AddScoped(typeof(ICategoryRepository<CategoryModel>),typeof(CategoryRepository));
        services.AddScoped(typeof(ICategoryService<CategoryModel>),typeof(CategoryService));
        
        services.AddMediatR(typeof(Program).Assembly);

        // services.AddScoped<TestDataCommandHandler>();
        // services.AddMediatR(typeof(TestDataCommandHandler).Assembly); 
        // services.AddMediatR(typeof(CreateCategoryCommandHandler).Assembly);
        // services.AddMediatR(typeof(GetAllCategoriesQueryHandler).Assembly);

    }

    private void SwaggerOnload(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("ApiKey",new OpenApiSecurityScheme
            {
                Description = "The API Key to access the Backend Service",
                Type = SecuritySchemeType.ApiKey,
                Name = "x-api-key",
                In = ParameterLocation.Header,
                Scheme = "ApiKeyScheme"
            });
            
            var scheme = new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header
            };

            var requirement = new OpenApiSecurityRequirement
            {
                { scheme, new List<string>() } 
            };
            
            c.AddSecurityRequirement((requirement));
            
        });

    }
}