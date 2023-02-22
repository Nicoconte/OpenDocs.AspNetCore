using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDocs.AspNetCore
{
    internal sealed class OpenDocsInvalidConfigException : Exception
    {
        public OpenDocsInvalidConfigException(string configName) 
            : base(string.Format("Invalid configuration. '{0}' cannot be empty/null", configName)) 
        { }
    }
}
