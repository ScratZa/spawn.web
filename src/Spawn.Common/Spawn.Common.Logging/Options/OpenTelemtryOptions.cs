using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spawn.Common.Logging.Options
{
    public class OpenTelemtryOptions
    {
        public bool IncludeScopes { get; set; } = true;
        public bool FormatMessage { get; set; } = true;

        public bool UseConsole { get; set; } = true;
        public bool UseSeq { get; set;} = false;

        public SeqConfiguration SeqConfiguration { get; set; } = new SeqConfiguration();
    }

    public class SeqConfiguration
    {
        public string Endpoint { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
    }
}
