using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Configuration;

public class SwaggerConfigurator
{
    public void Configure(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ATM API",
                Version = "v1",
                Description = "API для управления банкоматом",
                Contact = new OpenApiContact
                {
                    Name = "SvetaEnjoyer",
                    Email = "SvetaEnjoyer@ggmail.com",
                },
            });
        });
    }
}