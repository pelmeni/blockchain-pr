using BankSystem.Data;
using Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem.Business
{
    public class UserOperations:BaseDapperConnection
    {
        private readonly IDapperConnectionStringProvider _provider;
        public UserOperations(IDapperConnectionStringProvider provider) : base(provider)
        {
        }

        public IEnumerable<User> GetList()
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<User>("select Id, UserName, PasswordHash from dbo.[AspNetUsers] (nolock)"))?.ToArray();
        }
        public User GetByName(string userName)
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<User>("select Id, UserName, PasswordHash from dbo.[AspNetUsers] (nolock) where UserName=@userName",new { userName}))?.FirstOrDefault();
        }


    }
}
