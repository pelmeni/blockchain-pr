using System;

namespace BankSystem.Data
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }

        public string BlockchainAddress { get; set; }

        public DateTime Created { get; set; }
    }
}
