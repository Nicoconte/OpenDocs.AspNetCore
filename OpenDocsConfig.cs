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
        public string? ClientID { get; set; }
        public string? ClientSecret { get; set; }
        public string? SwaggerDocsUrl { get; set; } = "/swagger/swagger.json";
        public string? GroupID { get; set; }
    }
}
