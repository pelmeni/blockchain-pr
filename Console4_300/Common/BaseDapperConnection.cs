using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BaseDapperConnection
    {
        public BaseDapperConnection(IDapperConnectionStringProvider provider)
        {
            ConnectionString = provider.ConnectionString;
        }
        public string ConnectionString { get; private set; }

        protected long GetTableChecksum(string table)
        {
            return ExecuteQuery(db => {
                var r = db.Query<long?>($"select CHECKSUM_AGG(CHECKSUM(*)) chksum from {table} (nolock)");
                return r;
                })?.FirstOrDefault() ?? 0;
        }
        public void Execute(Action<IDbConnection> action)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                try
                {
                    db.Open();

                    action(db);

                }
                finally
                {
                    if (db.State != ConnectionState.Closed)
                        db.Close();
                }
            }
        }

        public T ExecuteQuery<T>(Func<IDbConnection, T> action)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                try
                {
                    db.Open();


                    return action(db);

                }
                finally
                {
                    if (db.State != ConnectionState.Closed)
                        db.Close();
                }
            }
        }
        public T ExecuteQueryOpenTrunc<T>(Func<IDbConnection, T> action, out IDbTransaction trunc)
        {
            trunc = null;

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {

                try
                {
                    db.Open();

                    trunc = db.BeginTransaction();

                    return action(db);

                }
                finally
                {
                    if (trunc == null)
                        if (db.State != ConnectionState.Closed)
                            db.Close();
                }
            }
        }
        public Task<T> ExecuteQueryAsync<T>(Func<IDbConnection, Task<T>> action)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();


                return action(db);

            }
        }
    }
}
