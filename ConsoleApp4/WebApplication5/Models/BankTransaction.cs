using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class BankTransaction
    {
        public Guid TransactionId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public byte StatusId { get; set; }
        public string Comment { get; set; }
        public string Purpose { get; set; }

        public DateTime Created { get; set; }


    }
}
