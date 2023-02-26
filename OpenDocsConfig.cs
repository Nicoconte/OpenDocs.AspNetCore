using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDocs.AspNetCore
{
    internal sealed class OpenDocsConfig
    {
        public string Server { get; set; }
        public string Environment { get; set; }
        public string ApplicationName { get; set; }
        public string? AccessKey { get; set; }
        public string? SwaggerDocsUrl { get; set; } = "/swagger/v1/swagger.json";
        public string? GroupID { get; set; }
    }
}
