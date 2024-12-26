using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace FullStack.Function.Helper
{
    public class ServiceBusHelper
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _queueName;
        private IQueueClient _queueClient;

        public ServiceBusHelper(string serviceBusConnectionString, string queueName)
        {
            _serviceBusConnectionString = serviceBusConnectionString;
            _queueName = queueName;
            _queueClient = new QueueClient(_serviceBusConnectionString, _queueName);
        }

        public async Task SendMessageAsync(string messageBody)
        {
            try
            {
                // Criar a mensagem a partir do corpo fornecido
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                // Enviar a mensagem para a fila
                await _queueClient.SendAsync(message);
                Console.WriteLine($"Mensagem enviada: {messageBody}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar mensagem: {ex.Message}");
            }
        }

        public async Task SendMessageAsync<T>(T messageObject)
        {
            try
            { // Serializar o objeto em JSON
                string messageBody = JsonConvert.SerializeObject(messageObject);
                // Criar a mensagem a partir do corpo fornecido
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                // Enviar a mensagem para a fila
                await _queueClient.SendAsync(message); Console.WriteLine($"Mensagem enviada: {messageBody}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar mensagem: {ex.Message}");

            }
        }

                public async Task CloseAsync()
        {
            await _queueClient.CloseAsync();
        }
    }

}
