using Common;

namespace BankSystem.BankingService.Providers
{
    public class DapperBankSystemConnectionStringProvider : IDapperConnectionStringProvider
    {
        //public string ConnectionString =>  "Data Source = 10.1.41.60; Initial Catalog = NNK.Messenger.Test; Integrated Security = True; ";
        public string ConnectionString => "Server=::1;Database=banksystem;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa; Password=qazWSX123;";
    }
}
