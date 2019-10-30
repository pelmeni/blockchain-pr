using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class UserBankAccountDetails : UserBankAccount
    {
        public IEnumerable<BankTransaction> Transactions { get; set; }

        public IEnumerable<BankInvoice> Invoices { get; set; }

        public BankAccountBalance Balance { get; set; }
    }
}
