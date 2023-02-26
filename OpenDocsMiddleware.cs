using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

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
            var swaggerFilePath = $"{Directory.GetCurrentDirectory()}/swagger.json";

            await File.WriteAllTextAsync(swaggerFilePath, swaggerContentResponse);

            var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(_config.Environment), nameof(_config.Environment));
            formData.Add(new StringContent(_config.ApplicationName), nameof(_config.ApplicationName));
            formData.Add(new StringContent(_config.AccessKey ?? string.Empty), nameof(_config.AccessKey));
            formData.Add(new StringContent(_config.GroupID ?? string.Empty), nameof(_config.GroupID));

            formData.Add(new ByteArrayContent(File.ReadAllBytes(swaggerFilePath)), "SwaggerFile", "swagger.json");

            string syncDocsUrl = string.Concat(_config.Server, "/api/application/sync-docs");
            var syncResponse = await client.PostAsync(syncDocsUrl, formData);

            File.Delete(swaggerFilePath);

            await context.Response.WriteAsync(syncResponse.IsSuccessStatusCode ? "Document was sended successfully" : "Something goes wrong");

            return;
        }

    }
}
