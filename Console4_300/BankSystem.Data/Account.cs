using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Data
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
