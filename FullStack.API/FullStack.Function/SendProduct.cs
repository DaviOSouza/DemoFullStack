using FullStack.Function.Helper;
using FullStack.Function.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FullStack.Function
{
    public class SendProduct
    {
        private readonly ILogger<SendProduct> _logger;
        private readonly IConfiguration _config;

        public SendProduct(ILogger<SendProduct> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        [Function("SendProduct")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var helper = new ServiceBusHelper(_config["sbConection"],
                "produtos");
            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var product = JsonConvert.DeserializeObject<Produto>(requestBody);
        

                if (product == null)
                    return new BadRequestObjectResult("Body is empty");

                await helper.SendMessageAsync<Produto>(product);

                               
                return new OkObjectResult("Success");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
