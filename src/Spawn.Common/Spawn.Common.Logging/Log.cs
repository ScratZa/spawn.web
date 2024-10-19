using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Spawn.Common.Logging
{
    public static partial class Log
    {
        [LoggerMessage(EventId =0,
            Level =LogLevel.Information,
            Message="Application Starting `{applicationName}`")]
        public static partial void HelloWorld(this ILogger logger, string applicationName);
        [LoggerMessage(
            EventId = 1000,
            Level = LogLevel.Error,
            Message = "Expected Key `{keyName}` not found in Configuration")]
        public static partial void MissingConfiguration(this ILogger logger, string keyName);
    }
}
