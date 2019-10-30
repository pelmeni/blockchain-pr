using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class BankInvoice
    {
            public Guid InvoiceId { get; set; }
            public Guid AccountId { get; set; }

            public string IssuerName { get; set; }
            public string IssuerAddress { get; set; }
            public DateTime IssueDate { get; set; }

            public decimal Amount { get; set; }
            public Guid PaymentAccountId { get; set; }
            public DateTime Created { get; set; }
            public byte StatusId { get; set; }
            public DateTime? StatusChanged { get; set; }
    }
}
