using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class BankAccountBalance
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }

        public DateTime Modified { get; set; }
    }
}
