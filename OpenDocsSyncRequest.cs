using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDocs.AspNetCore
{
    internal sealed class OpenDocsSyncRequest
    {
        public string Environment { get; set; }
        public string ApplicationName { get; set; }
        public string SwaggerContent { get; set; }
        public string? ClientID { get; set; }
        public string? ClientSecret { get; set; }
        public string? GroupID { get; set; }
    }
}
