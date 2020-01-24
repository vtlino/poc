using Common;
using Newtonsoft.Json;
using OpenBanking.POC.Domain.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Business
{
    public class CurrentAccountBusiness
    {
        private readonly CurrentAccountRepository _CurrentAccountRepository = new CurrentAccountRepository();

        public Tuple<int, string> GetBalance(string user)
        {
            var account = AccountIM.GetAccount(user);
            if (string.IsNullOrWhiteSpace(account) || account.Equals("0"))
                return Tuple.Create((int)HttpStatusCode.NoContent, JsonConvert.SerializeObject(new PartyResult()));

            var amount = _CurrentAccountRepository.GetBalance(account);

            var balance = new BalanceResult { Data = new DataBalance() };
            var listBalance = new List<Balance>();
            listBalance.Add(new Balance
            {
                AccountId = account,
                DateTime = DateTime.Now,
                Amount = new AmountBalance
                {
                    Amount = ConvertAmount(amount),
                    Currency = Constant.BRL
                }
            });

            balance.Data.Balance = listBalance;
            return Tuple.Create((int)HttpStatusCode.OK, JsonConvert.SerializeObject(balance));
        }

        public Tuple<int, string> GetTransactions(string user, DateTime initialDate, DateTime endDate)
        {
            var account = AccountIM.GetAccount(user);
            if (string.IsNullOrWhiteSpace(account) || account.Equals("0"))
                return Tuple.Create((int)HttpStatusCode.NoContent, JsonConvert.SerializeObject(new PartyResult()));

            var firstBalance = _CurrentAccountRepository.GetBalance(account, initialDate);
            var statements = _CurrentAccountRepository.GetTransactions(account, initialDate, endDate);
            var amount = new AmountTransaction { Amount = ConvertAmount(firstBalance), Currency = Constant.BRL };

            var transaction = new TransactionResult { Data = new Data { Transaction = new List<Transaction>() } };
            transaction.Data.Transaction.Add(new Transaction
            {
                AccountId = account,
                Amount = amount,
                Balance = new BalanceTransaction { Amount = amount },
                ValueDateTime = initialDate.Date,
                TransactionReference = "0"
            });

            var index = 1;
            foreach (var statement in statements)
            {
                transaction.Data.Transaction.Add(new Transaction
                {
                    AccountId = statement.AccountId,
                    Amount = new AmountTransaction { Amount = ConvertAmount(statement.Amount), Currency = Constant.BRL },
                    CreditDebitIndicator = statement.CreditDebitIndicator,
                    TransactionId = statement.TransactionReference,
                    TransactionReference = index.ToString(),
                    ValueDateTime = statement.ValueDateTime
                });
                index++;
            }

            return Tuple.Create((int)HttpStatusCode.OK, JsonConvert.SerializeObject(transaction));
        }
       
        private string ConvertAmount(decimal? amount)
        {
            return amount.HasValue ? amount.Value.ToString(CultureInfo.InvariantCulture) : "0";
        }

    }
}
