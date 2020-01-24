using System;
using System.Collections.Generic;

namespace OpenBanking.POC.Domain.Models
{
    public class AmountBalance
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
    }

    public class CreditLineBalance
    {
        public CreditLineBalance()
        {
            AmountBalance = new AmountBalance();
        }

        public bool Included { get; set; }
        public string Type { get; set; }
        public AmountBalance AmountBalance { get; set; }
    }

    public class Balance
    {
        public Balance()
        {
            Amount = new AmountBalance();
            CreditLine = new List<CreditLineBalance>();
        }

        public string AccountId { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public AmountBalance Amount { get; set; }
        public IList<CreditLineBalance> CreditLine { get; set; }
    }

    public class DataBalance
    {
        public DataBalance()
        {
            Balance = new List<Balance>();
        }

        public IList<Balance> Balance { get; set; }
    }

    public class BalanceResult
    {
        public BalanceResult()
        {
            Data = new DataBalance();
            Links = new Links();
            Meta = new Meta();
        }

        public DataBalance Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }
}