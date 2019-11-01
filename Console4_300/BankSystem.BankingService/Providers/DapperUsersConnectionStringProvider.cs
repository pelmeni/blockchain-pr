using Common;

namespace BankSystem.BankingService.Providers
{
    public class DapperUsersConnectionStringProvider : IDapperConnectionStringProvider
    {
        //public string ConnectionString =>  "Data Source = 10.1.41.60; Initial Catalog = NNK.Messenger.Test; Integrated Security = True; ";
        public string ConnectionString => "Server=::1;Database=aspnet-WebApplication2-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa; Password=qazWSX123;";
    }
}
