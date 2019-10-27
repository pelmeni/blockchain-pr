using BankSystem.Data;
using Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BankSystem.Business
{
    public class InvoiceOperations : BaseDapperConnection
    {
        private readonly IDapperConnectionStringProvider _provider;
        public InvoiceOperations(IDapperConnectionStringProvider provider) : base(provider)
        {
        }

        public IEnumerable<Invoice> GetList(Guid accountId)
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<Invoice>("select * from dbo.[Invoice] (nolock) where AccountId=@accountId",
                            new { accountId }))?.ToArray();
        }

        public void UpdageInvoiceStatus(Guid invoiceId, byte statusId)
        {
            Execute(
                (db) =>
                    db.Execute(
                        "update dbo.[Invoice] set StatusId=@statusId, StatusChanged=getdate() where InvoiceId=@invoiceId",
                                            new {statusId, invoiceId}));
        }
        public Invoice GetOne(Guid invoiceId)
        {
            var invoice = ExecuteQuery(db =>
                    db.Query<Invoice>("select * from dbo.[Invoice] (nolock) where InvoiceId=@invoiceId",
                        new {invoiceId }))?.FirstOrDefault();

            return invoice;

        }

    }
}
