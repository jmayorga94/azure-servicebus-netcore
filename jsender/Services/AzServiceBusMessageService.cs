using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using jsender.API.Models;
using jsender.Application;
using Newtonsoft.Json;

namespace jsender.Services
{
    public class AzServiceBusMessageService : IMessageService
    {
        private readonly ServiceBusClient _client;
        private static string JsonContentType = "application/json";
        private  ServiceBusSender _sender { get; set; }

   
        public AzServiceBusMessageService(ServiceBusClient client, ServiceBusSender sender)
        {
            _client = client;
            _sender = sender;
           
        }

        public async Task<bool> SendMessageAsync(Transaction transaction)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(transaction);
                byte[] byteArray = Encoding.ASCII.GetBytes(jsonString);
                ServiceBusMessage message = new ServiceBusMessage(byteArray);
                message.ContentType = JSON_CONTENT_TYPE;
                

                await _sender.SendMessageAsync(message);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SendMultipleMessages(int quantity, Transaction transaction)
        {
            string jsonString = JsonConvert.SerializeObject(transaction);
            byte[] byteArray = Encoding.ASCII.GetBytes(jsonString);
            ServiceBusMessage message = new ServiceBusMessage(byteArray);
            message.ContentType = JSON_CONTENT_TYPE;

            using ServiceBusMessageBatch messageBatch = await _sender.CreateMessageBatchAsync();

            for (int i = 1; i <= quantity; i++)
            {
                if (!messageBatch.TryAddMessage(message))
                {
                    throw new Exception($"The message {i} is too large to fit in the batch.");
                }
            }

            try
            {
            
                await _sender.SendMessagesAsync(messageBatch);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
