using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystemWebApplication
{
    public class DapperUsersConnectionStringProvider //: IDapperConnectionStringProvider
    {
        //public string ConnectionString =>  "Data Source = 10.1.41.60; Initial Catalog = NNK.Messenger.Test; Integrated Security = True; ";
        public string ConnectionString => "Server=newamber;Database=banksystem;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa; Password=qazwsx;";
    }
}
