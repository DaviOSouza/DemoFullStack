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
    public class ReceiveCliente
    {
        private readonly ILogger<ReceiveCliente> _logger;

        private readonly IConfiguration _config;

        public ReceiveCliente(ILogger<ReceiveCliente> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        [Function(nameof(ReceiveCliente))]
        public async Task Run(
            [ServiceBusTrigger("clientes", Connection = "sbConection")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {



           Cliente c = JsonConvert.DeserializeObject<Cliente>(Encoding.UTF8.GetString(message.Body));
           var repo = new ClienteRepository(_config);
            repo.SalvarCliente(c);
            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
