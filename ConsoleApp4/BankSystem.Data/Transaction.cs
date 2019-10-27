using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Data
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Value { get; set; }
        public byte StatusId { get; set; }
        public string Comment { get; set; }
        public string Purpose { get; set; }

        public DateTime Created { get; set; }


    }
}
