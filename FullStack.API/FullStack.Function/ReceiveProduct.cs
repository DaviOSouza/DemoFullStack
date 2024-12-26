using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using FullStack.Function.Model;
using FullStack.Function.Repository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FullStack.Function
{
    public class ReceiveProduct
    {
        private readonly ILogger<ReceiveProduct> _logger;

        private readonly IConfiguration _config;

        public ReceiveProduct(ILogger<ReceiveProduct> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        [Function(nameof(ReceiveProduct))]
        public async Task Run(
            [ServiceBusTrigger("produtos", Connection = "sbConection")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {



           Produto p = JsonConvert.DeserializeObject<Produto>(Encoding.UTF8.GetString(message.Body));
           var repo = new ProductRepository(_config);
            repo.SalvarProduto(p);
            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
