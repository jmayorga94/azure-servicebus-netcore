using System;
using jsender.API.Models;

namespace jsender.Requests
{
    public class SendSingleTransactionRequest
    {
        public MetaData Metadata { get; set; }
        public Data Data { get; set; }

    }
}
