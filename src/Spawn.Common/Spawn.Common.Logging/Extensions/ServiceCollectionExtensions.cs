using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using Spawn.Common.Logging.Options;

namespace Spawn.Common.Logging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseSpawnLogger(this IServiceCollection services, IConfiguration config)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var application = Environment.GetEnvironmentVariable("APPLICATION_NAME");

            var openTelemetryConfiguration = config.GetSection("OpenTelemetry").Get<OpenTelemtryOptions>();

            services.AddLogging(logging => logging.AddOpenTelemetry(openTelemetryLoggerOptions =>
             {
                 openTelemetryLoggerOptions.SetResourceBuilder(
                     ResourceBuilder.CreateEmpty()
                         // Replace "GettingStarted" with the name of your application
                         .AddService(application)
                         .AddAttributes(new Dictionary<string, object>
                         {
                             // Add any desired resource attributes here
                             [environment] = environment
                         }));

                 openTelemetryLoggerOptions.IncludeScopes = openTelemetryConfiguration.IncludeScopes;
                 openTelemetryLoggerOptions.IncludeFormattedMessage = openTelemetryConfiguration.FormatMessage;

                 if (openTelemetryConfiguration.UseSeq)
                 {

                     openTelemetryLoggerOptions.AddOtlpExporter(exporter =>
                     {
                         exporter.Endpoint = new Uri("http://localhost/ingest/otlp/v1/logs");
                         exporter.Protocol = OtlpExportProtocol.HttpProtobuf;
                     });
                 }
                 else
                 {
                     openTelemetryLoggerOptions.AddConsoleExporter();
                 }
             }));

            return services;
        }
    }
}
