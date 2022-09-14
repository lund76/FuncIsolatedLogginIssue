using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Func7PreviewFunc
{
    public class HttpExample
    {
        private readonly ILogger _logger;

        public HttpExample(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpExample>();
        }

        [Function("HttpExample")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
           _logger.LogInformation("Log Request number {InfoLogCount}", 1);
           _logger.LogTrace("A little trace in the middle");
           _logger.LogDebug("A littel debug info in the middle");
           _logger.LogInformation("Log Request number {InfoLogCount}", 2);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
