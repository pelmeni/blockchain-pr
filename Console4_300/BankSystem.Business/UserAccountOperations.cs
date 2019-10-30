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

        public void UpdateIsAutoPay(int userAccountId, bool isAutoPay)
        {
            Execute(
                (db) =>
                    db.Execute(
                        "update dbo.UserAccount set IsAutoPay=@isAutoPay where UserAccountId =@userAccountId", 
                        new {userAccountId, isAutoPay }));
        }

        public void Update(int userAccountId, bool isAutoPay, Guid autopaySensorId)
        {
            Execute(
                (db) =>
                    db.Execute(
                        "update dbo.UserAccount set IsAutoPayAllowed=@isAutoPay, AutoPaySensorId = @autopaySensorId where UserAccountId =@userAccountId",
                        new { userAccountId, isAutoPay, autopaySensorId }));
        }
    }
}
