using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Providers
{
    public class DapperEnergyServicesConnectionStringProvider : IDapperConnectionStringProvider
    {
        //public string ConnectionString =>  "Data Source = 10.1.41.60; Initial Catalog = NNK.Messenger.Test; Integrated Security = True; ";
        public string ConnectionString => "Server=newamber;Database=energycompany;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa; Password=qazwsx;";
    }
}
