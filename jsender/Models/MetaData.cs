using System;
namespace jsender.API.Models
{
    public class MetaData
    {
        public string _messageType { get; set; }

        public string _messageId { get; set; }

        public string _messageIdOrg { get; set; }

        public string _shortMessageId { get; set; }
        public string _applicationId { get; set; }
        public string _serviceId { get; set; }
        public DateTime _datetime { get; set; }

        public MetaData()
        {

        }
    }
}
