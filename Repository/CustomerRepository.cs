using Dapper;
using Domain.Entity;
using System.Data.SqlClient;

namespace Repository
{
    public class CustomerRepository
    {
        public PartyEntity GetCustomer(string account)
        {
            using (var connection = new SqlConnection("connection string"))
            {
                return connection.QuerySingleOrDefault<PartyEntity>(QUERY_GET_PARTY, new { account });
            }
        }

        private const string QUERY_GET_PARTY = @"
            SELECT *
            FROM Party
            Where AccountId = @accountId
        ";
    }
}
