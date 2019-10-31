using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyConsumption.GenerateSensorCountersService
{
    public class DapperUsersConnectionStringProvider : IDapperConnectionStringProvider
    {
        //public string ConnectionString =>  "Data Source = 10.1.41.60; Initial Catalog = NNK.Messenger.Test; Integrated Security = True; ";
        public string ConnectionString => "Server=newamber;Database=aspnet-WebApplication2-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa; Password=qazwsx;";
    }
}
