using System;
using System.Threading.Tasks;
using jsender.API.Models;

namespace jsender.Application
{
    public interface IMessageService
    {
        public Task<bool> SendMessageAsync(Transaction transaction);
        public Task<bool> SendMultipleMessages(int quantity, Transaction transaction);

    }
}
