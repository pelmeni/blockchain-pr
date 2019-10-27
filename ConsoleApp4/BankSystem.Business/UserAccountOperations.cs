using BankSystem.Data;
using Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem.Business
{
    public class UserAccountOperations : BaseDapperConnection
    {
        private readonly IDapperConnectionStringProvider _provider;
        public UserAccountOperations(IDapperConnectionStringProvider provider) : base(provider)
        {
        }

        public IEnumerable<UserAccount> GetList(Guid userId)
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<UserAccount>("select * from dbo.[UserAccount] (nolock) where UserId=@userId",
                            new { userId }))?.ToArray();
        }

        public UserAccount AddOne(Guid userId, Guid accountId)
        {

            var newAccount = new UserAccount
            {
                UserId = userId,
                AccountId = accountId
            };

            Execute(
                (db) =>
                    db.Execute(
                        "insert dbo.UserAccount (UserId, AccountId) values(@UserId, @AccountId);" +
                        "insert dbo.Account (AccountId) values(@AccountId)",
                        newAccount));

            var created = ExecuteQuery(db =>
                    db.Query<UserAccount>("select * from dbo.[UserAccount] (nolock) where UserId=@UserId and AccountId=@AccountId",
                        newAccount))?.FirstOrDefault();

            return created;

        }

        public UserAccount GetOne(int userAccountId)
        {
            var result = ExecuteQuery(db =>
                    db.Query<UserAccount>("select * from dbo.[UserAccount] (nolock) where UserAccountId=@userAccountId",
                        new { userAccountId }))?.FirstOrDefault();

            return result;

        }
    }
}
