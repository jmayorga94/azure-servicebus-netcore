
using jsender.API.Models;

namespace jsender.API.Requests
{
    public class SendMultipleTransactionsRequest
    {
        public int Quantity { get; set; }
        public MetaData Metadata { get; set; }
        public Data Data { get; set; }
    }
}
