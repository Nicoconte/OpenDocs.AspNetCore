using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OpenDocs.AspNetCore
{
    internal sealed class OpenDocsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly OpenDocsConfig _config;
            
        public OpenDocsMiddleware(RequestDelegate next, OpenDocsConfig config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string apiBaseUrl = string.Concat(context.Request.Scheme, "://", context.Request.Host);
            string swaggerUrl = string.Concat(apiBaseUrl, _config.SwaggerDocsUrl);

            var client = new HttpClient();

            var swaggerContentResponse = await (await client.GetAsync(swaggerUrl)).Content.ReadAsStringAsync();

            var openDocsRequest = JsonConvert.SerializeObject(new OpenDocsSyncRequest()
            {
                SwaggerContent = swaggerContentResponse,
                Environment = _config.Environment,
                ClientID = _config.ClientID,
                ClientSecret = _config.ClientSecret,
                ApplicationName= _config.ApplicationName,
                GroupID = _config.GroupID,
            });

            string syncDocsUrl = string.Concat(_config.Server, "/sync-docs");
            await client.PostAsync(syncDocsUrl, new StringContent(openDocsRequest));

            await _next(context);
        }

    }
}
