using System;

namespace jsender.Models
{
    public class Body
    {
        public int idMonetaryConfirmation { get; set; }

        public int channelId { get; set; }

        public int instaceId { get; set; }

        public int referencesNumber { get; set; }

        public string efectiveDate { get; set; }

        public int postUserData { get; set; }

        public int retrievalReferenceNumber { get; set; }

        public int vpRspCode { get; set; }

        public int nbrOfInstallment { get; set; }

        public string pmtTypeInd { get; set; }

        public string transactionCode { get; set; }

        public int mccType { get; set; }

        public string requestType { get; set; }

        public string cardNumber { get; set; }

        public string merchantOrgNbr { get; set; }

        public string totalSalesAmount { get; set; }

        public string systemAction { get; set; }

        public int reasonActionCode { get; set; }

        public string actionDescription { get; set; }

        public string cvvCvcResult { get; set; }

        public string authorizationCode { get; set; }

        public string collectionIndicator { get; set; }

        public int merchantStore { get; set; }

        public string merchantName { get; set; }

        public int merchantCategcode { get; set; }

        public string merchantCity { get; set; }

        public string merchantState { get; set; }

        public string merchantCountryCode { get; set; }

        public string state { get; set; }

        public DateTime transactionDate { get; set; }

        public int estado { get; set; }

        public Body()
        {

        }

    }
}
