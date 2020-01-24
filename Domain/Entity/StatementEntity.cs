using System;

namespace Domain.Entity
{
    public class StatementEntity
    {
        public string AccountId { get; set; }
        public long TransactionId { get; set; }
        public string TransactionReference { get; set; }
        public string CreditDebitIndicator { get; set; }
        public decimal Amount { get; set; }
        public DateTime ValueDateTime { get; set; }
    }
}
