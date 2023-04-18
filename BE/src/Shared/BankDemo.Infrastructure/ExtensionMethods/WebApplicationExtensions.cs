using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace BankDemo.Infrastructure.ExtensionMethods
{
    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder UseSwaggerWithVersioning(this WebApplication app)
        {
            IServiceProvider services = app.Services;
            var provider = services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}
