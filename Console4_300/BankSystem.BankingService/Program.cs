using Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BankSystem.BankingService.Providers;
using BankSystem.Business;
using EnergyConsumption.Business.Blockchain;


namespace BankSystem.BankingService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Banking System Service");

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();


            var contractAddress = "0xef012a171b50b1b9c6f775a54f54af86ce524685";

            var account = new Account() { Address = "0x8364d57F6511771CBe20aaf1CF8dA73a9B487F3f", PrivateKey = "0xd9309f665b7040ad35f7820a503d2765afa3e7a7e5e72125e8f50ae98905a749" };

            var cops = new Blockchain.Business.ContractOperations("http://127.0.0.1:7545", account.PrivateKey, contractAddress);

            var uaops = new UserAccountOperations(new DapperBankSystemConnectionStringProvider());

            //var tx = cops.emptyTariffZones().Result;

            var syncBankAccountsTask = Task.Factory.StartNew(async () =>
            {
                while (!cancelTokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("syncBankAccountsTask: cycle begin");

                    var accounts = uaops.GetListWithLinkedSensors();

                    foreach (var a in accounts)
                    {
                        var tx = cops.insertBankAccount((uint)a.UserAccountId, a.AutoPaySensorId).Result;

                        Console.WriteLine($"syncBankAccountsTask: tx: {tx.TransactionHash}");

                        var res = cops.getBankAccount(a.UserAccountId);

                        var res1 = cops.getCurrentInvoice(a.UserAccountId);

                    }

                    Console.WriteLine("syncBankAccountsTask: cycle complete");

                    await Task.Delay(1000 * 15 * 1);
                }
            }, cancelTokenSource.Token);





















            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                cancelTokenSource.Cancel();
            }

            Console.WriteLine("End of work detected. Press anykey to exit");
            Console.ReadLine();
        }
    }
}
