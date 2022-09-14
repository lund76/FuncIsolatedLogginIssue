using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Logging;
namespace Func7PreviewFunc
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                
                .ConfigureLogging((context, logger) =>
                {
                    var conString = context.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
                
                    logger.AddApplicationInsights(
                    configureTelemetryConfiguration: (config) => config.ConnectionString = conString,
                    configureApplicationInsightsLoggerOptions: (options) => {}
                    );
                })
                
                .Build();



            host.Run();
        }
    }
}