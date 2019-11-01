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


            var contractAddress = "0x8d242e4c6bc2a11b799d1978551f6985a2727cdc";

            //var account = new Account() { Address = "0x8364d57F6511771CBe20aaf1CF8dA73a9B487F3f", PrivateKey = "0xd9309f665b7040ad35f7820a503d2765afa3e7a7e5e72125e8f50ae98905a749" };
            var account = new Account() { Address = "0xCf6e63CAA7Fd568D2a9ebBf5Cc166A410Aa3EB03", PrivateKey = "0xc543ec2a26c7698771736d1cf339db5dbace04c11d1198eb6c2f25185bc8a306" };

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

                        var res = cops.getBankAccount((uint)a.UserAccountId).Result;

                        var res1 = cops.getCurrentInvoice((uint)a.UserAccountId).Result;

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
