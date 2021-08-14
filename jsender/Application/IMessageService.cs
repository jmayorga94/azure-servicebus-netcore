using System;
using System.Threading.Tasks;

namespace jsender.Application
{
    public interface IMessageService
    {
        public Task<bool> SendMessageAsync(string message);
        public Task<bool> SendMultipleMessages(int quantity, string message);

    }
}
