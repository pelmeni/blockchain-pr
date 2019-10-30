using BankSystem.Data;
using Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BankSystem.Business
{
    public class TransactionOperations : BaseDapperConnection
    {
        private readonly IDapperConnectionStringProvider _provider;
        public TransactionOperations(IDapperConnectionStringProvider provider) : base(provider)
        {
        }

        public IEnumerable<Transaction> GetList(Guid accountId)
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<Transaction>("select * from dbo.[Transaction] (nolock) where AccountId=@accountId",
                            new { accountId }))?.ToArray();
        }

        public Transaction AddOne(Guid accountId, decimal value, string comment = "", string purpose = "", byte statusId = 0)
        {

            var transaction = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                AccountId = accountId,
                Value = value,
                Purpose = purpose,
                Comment = comment,
                StatusId = statusId
            };

            Execute(
                (db) =>
                    db.Execute(
                        "insert into dbo.[Transaction] (TransactionId, AccountId, Value, StatusId, Purpose, Comment) values(@TransactionId, @AccountId, @Value, @StatusId, @Purpose, @Comment)",
                                            transaction));

            var created = ExecuteQuery(db =>
                    db.Query<Transaction>("select * from dbo.[Transaction] (nolock) where TransactionId=@TransactionId",
                        transaction))?.FirstOrDefault();

            return created;

        }

    }
}
