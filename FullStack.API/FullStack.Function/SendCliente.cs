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
    public class SendCliente
    {
        private readonly ILogger<SendProduct> _logger;
        private readonly IConfiguration _config;

        public SendCliente(ILogger<SendProduct> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        [Function("SendCliente")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var helper = new ServiceBusHelper(_config["sbConection"],
                "clientes");
            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var cliente = JsonConvert.DeserializeObject<Cliente>(requestBody);


                if (cliente == null)
                    return new BadRequestObjectResult("Body is empty");

                await helper.SendMessageAsync<Cliente>(cliente);


                return new OkObjectResult("Success");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
