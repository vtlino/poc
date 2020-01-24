using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Domain.Entity;

namespace Repository
{
    public class CurrentAccountRepository
    {
        public decimal? GetBalance(string accountId, DateTime? initialDate = null)
        {
            var balanceFilter = initialDate.HasValue ? " AND DateTime <= @initialDate" : "";

            using (var connection = new SqlConnection("connection string"))
            {
                return connection.QuerySingle<decimal?>(String.Format(QUERY_GET_BALANCE, balanceFilter), new { accountId, initialDate });
            }
        }

        public List<StatementEntity> GetTransactions(string accountId, DateTime initialDate, DateTime endDate)
        {
            using (var connection = new SqlConnection("connection string"))
            {
                return connection.Query<StatementEntity>(QUERY_GET_TRANSACTIONS, new { accountId, initialDate, endDate })?.ToList();
            }
        }

        private const string QUERY_GET_BALANCE = @"
            SELECT TOP 1 Amount
            FROM Balance
            Where AccountId = @accountId
            {0}
            ORDER BY DateTime DESC
        ";

        private const string QUERY_GET_TRANSACTIONS = @"
            SELECT * 
            FROM Statement
            Where AccountId = @accountId
            AND ValueDateTime >= @initialDate
            AND ValueDateTime <= @endDate
            ORDER BY ValueDateTime
        ";
    }
}