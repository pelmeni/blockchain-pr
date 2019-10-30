using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class UserBankAccount
    {
        public int UserAccountId { get; set; }
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }

        public string BlockchainAddress { get; set; }

        public DateTime Created { get; set; }

        public bool IsAutoPayAllowed { get; set; }

        public Guid AutoPaySensorId { get; set; }
    }
}
