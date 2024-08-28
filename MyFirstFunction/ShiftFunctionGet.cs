using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MyFirstFunction
{
    public class ShiftFunctionGet
    {
        private readonly ILogger<ShiftFunctionGet> _logger;

        public ShiftFunctionGet(ILogger<ShiftFunctionGet> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ShiftFunctionGet))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "shift")] 
            HttpRequest req,
            [CosmosDBInput(databaseName:"shifts", containerName: "newshift", 
                Connection = "CosmosDBConnection", SqlQuery = "SELECT * FROM c")] Shift[] shifts)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var shift = new Shift { Person = "John Doe", Id = "1" };

            return new OkObjectResult(shifts);
        }
    }
}
