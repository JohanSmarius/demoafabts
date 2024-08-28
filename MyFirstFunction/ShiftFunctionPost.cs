using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyFirstFunction
{
    public class ShiftFunctionPost
    {
        private readonly ILogger<ShiftFunctionPost> _logger;

        public ShiftFunctionPost(ILogger<ShiftFunctionPost> logger)
        {
            _logger = logger;
        }

        [Function("ShiftFunctionPost")]
        [CosmosDBOutput(databaseName: "shifts", containerName: "newshift", Connection = "CosmosDBConnection", CreateIfNotExists = true)]
        public async Task<Shift> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "shift")] 
            HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.Created);
            response.Body = req.Body;

            var shift = await JsonSerializer.DeserializeAsync<Shift>(req.Body);

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return shift;
        }
    }
}
