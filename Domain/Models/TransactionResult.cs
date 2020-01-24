using System;
using System.Collections.Generic;

namespace OpenBanking.POC.Domain.Models
{
    public class AmountTransaction
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
    }

    public class ChargeAmountTransaction
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
    }

    public class InstructedAmountTransaction
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
    }

    public class CurrencyExchangeTransaction
    {
        public CurrencyExchangeTransaction()
        {
            InstructedAmount = new InstructedAmountTransaction();
        }

        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public string UnitCurrency { get; set; }
        public int ExchangeRate { get; set; }
        public string ContractIdentification { get; set; }
        public DateTime QuotationDate { get; set; }
        public InstructedAmountTransaction InstructedAmount { get; set; }
    }

    public class BankTransactionCode
    {
        public string Code { get; set; }
        public string SubCode { get; set; }
    }

    public class ProprietaryBankTransactionCode
    {
        public string Code { get; set; }
        public string Issuer { get; set; }
    }

    public class BalanceTransaction
    {
        public BalanceTransaction()
        {
            Amount = new AmountTransaction();
        }

        public string CreditDebitIndicator { get; set; }
        public string Type { get; set; }
        public AmountTransaction Amount { get; set; }
    }

    public class MerchantDetails
    {
        public string MerchantName { get; set; }
        public string MerchantCategoryCode { get; set; }
    }

    public class PostalAddress
    {
        public PostalAddress()
        {
            AddressLine = new List<string>();
        }

        public string AddressType { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string PostCode { get; set; }
        public string TownName { get; set; }
        public string CountrySubDivision { get; set; }
        public string Country { get; set; }
        public IList<string> AddressLine { get; set; }
    }

    public class CreditorAgent
    {
        public CreditorAgent()
        {
            PostalAddress = new PostalAddress();
        }

        public string SchemeName { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public PostalAddress PostalAddress { get; set; }
    }

    public class CreditorAccount
    {
        public string SchemeName { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string SecondaryIdentification { get; set; }
    }

    public class DebtorAgent
    {
        public DebtorAgent()
        {
            PostalAddress = new PostalAddress();
        }

        public string SchemeName { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public PostalAddress PostalAddress { get; set; }
    }

    public class DebtorAccount
    {
        public string SchemeName { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string SecondaryIdentification { get; set; }
    }

    public class CardInstrument
    {
        public string CardSchemeName { get; set; }
        public string AuthorisationType { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
    }

    public class AdditionalProp1
    {
    }

    public class SupplementaryData
    {
        public SupplementaryData()
        {
            AdditionalProp1 = new AdditionalProp1();
        }

        public AdditionalProp1 AdditionalProp1 { get; set; }
    }

    public class Transaction
    {
        public Transaction()
        {
            Amount = new AmountTransaction();
            ChargeAmount = new ChargeAmountTransaction();
            CurrencyExchange = new CurrencyExchangeTransaction();
            BankTransactionCode = new BankTransactionCode();
            ProprietaryBankTransactionCode = new ProprietaryBankTransactionCode();
            Balance = new BalanceTransaction();
            MerchantDetails = new MerchantDetails();
            CreditorAgent = new CreditorAgent();
            CreditorAccount = new CreditorAccount();
            DebtorAgent = new DebtorAgent();
            DebtorAccount = new DebtorAccount();
            CardInstrument = new CardInstrument();
            SupplementaryData = new SupplementaryData();
        }

        public string AccountId { get; set; }
        public string TransactionId { get; set; }
        public string TransactionReference { get; set; }
        public IList<string> StatementReference { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string Status { get; set; }
        public DateTime BookingDateTime { get; set; }
        public DateTime ValueDateTime { get; set; }
        public string TransactionInformation { get; set; }
        public string AddressLine { get; set; }
        public AmountTransaction Amount { get; set; }
        public ChargeAmountTransaction ChargeAmount { get; set; }
        public CurrencyExchangeTransaction CurrencyExchange { get; set; }
        public BankTransactionCode BankTransactionCode { get; set; }
        public ProprietaryBankTransactionCode ProprietaryBankTransactionCode { get; set; }
        public BalanceTransaction Balance { get; set; }
        public MerchantDetails MerchantDetails { get; set; }
        public CreditorAgent CreditorAgent { get; set; }
        public CreditorAccount CreditorAccount { get; set; }
        public DebtorAgent DebtorAgent { get; set; }
        public DebtorAccount DebtorAccount { get; set; }
        public CardInstrument CardInstrument { get; set; }
        public SupplementaryData SupplementaryData { get; set; }
    }

    public class Data
    {
        public Data()
        {
            Transaction = new List<Transaction>();
        }

        public IList<Transaction> Transaction { get; set; }
    }

    public class TransactionResult
    {
        public TransactionResult()
        {
            Data = new Data();
            Links = new Links();
            Meta = new Meta();
        }

        public Data Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }
}