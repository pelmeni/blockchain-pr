﻿using System;

namespace BankSystem.Data
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
