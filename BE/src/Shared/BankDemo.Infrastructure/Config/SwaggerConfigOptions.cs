using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BankDemo.Infrastructure.Config
{
    public class SwaggerConfigOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;
        private readonly IConfiguration config;

        public SwaggerConfigOptions(IApiVersionDescriptionProvider provider, IConfiguration config)
        {
            this.provider = provider;
            this.config = config;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, name));
            }
        }
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = config["SwaggerTitle"] + description.ApiVersion.ToString(),
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, string name)
        {
            var info = new OpenApiInfo()
            {
                Title = config["SwaggerTitle"],
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}

