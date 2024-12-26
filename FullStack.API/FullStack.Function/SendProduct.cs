using FullStack.Function.Helper;
using FullStack.Function.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FullStack.Function
{
    public class SendProduct
    {
        private readonly ILogger<SendProduct> _logger;

        public SendProduct(ILogger<SendProduct> logger)
        {
            _logger = logger;
        }

        [Function("SendProduct")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var helper = new ServiceBusHelper("Endpoint=sb://fullstackdemosb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=yFCqMcbIcpc7ipYuF16UhAC8YpBMPgEzm+ASbPskO1Y=",
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
