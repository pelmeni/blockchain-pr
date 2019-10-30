using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Data
{
    public class Invoice
    {
        public Guid InvoiceId { get; set;}
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
