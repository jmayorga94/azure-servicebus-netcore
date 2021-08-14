using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using jsender.Application;
using jsender.Utility;
using Microsoft.Extensions.Options;

namespace jsender.Services
{
    public class AzServiceBusMessageService : IMessageService
    {
        public static ServiceBusClient _client { get; set; }

        public static ServiceBusSender _sender { get; set; }

        private AzServiceBusConfig _serviceBusConfig { get; set; }

        public AzServiceBusMessageService(IOptions<AzServiceBusConfig> serviceBusConfig)
        {
            _serviceBusConfig = serviceBusConfig.Value;
            _client = new ServiceBusClient(_serviceBusConfig.ConnectionString);
            _sender = _client.CreateSender(_serviceBusConfig.QueueName);

        }

        public async Task<bool> SendMessageAsync(string bodyOfMessage)
        {
            try
            {
                ServiceBusMessage message = new ServiceBusMessage(bodyOfMessage);

                await _sender.SendMessageAsync(message);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SendMultipleMessages(int quantity, string message)
        {
            throw new NotImplementedException();
        }

    }
}
