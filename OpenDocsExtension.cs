using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace OpenDocs.AspNetCore
{
    public static class OpenDocsExtension
    {

        public static IApplicationBuilder UseOpenDocs(this IApplicationBuilder app, IConfiguration configuration, string section="OpenDocs")
        {
            OpenDocsConfig config = new OpenDocsConfig();

            configuration.GetSection(section).Bind(config);

            if (string.IsNullOrWhiteSpace(config.Server))
                throw new OpenDocsInvalidConfigException(nameof(config.Server));

            if (string.IsNullOrWhiteSpace(config.Environment))
                throw new OpenDocsInvalidConfigException(nameof(config.Environment));

            if (string.IsNullOrWhiteSpace(config.ApplicationName))
                throw new OpenDocsInvalidConfigException(nameof(config.ApplicationName));

            app.Map("/opendocs", app =>
            {
                app.UseMiddleware<OpenDocsMiddleware>(config);
            });

            return app;
        }

    }
}