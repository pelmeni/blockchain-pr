using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Providers
{
    public class DapperEnergyServicesConnectionStringProvider : IDapperConnectionStringProvider
    {
        
        //public string ConnectionString => "Server=newamber;Database=energycompany;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa; Password=qazwsx;";
        public string ConnectionString => "Server=::1;Database=energycompany;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa; Password=qazwsx;";
    }
}
