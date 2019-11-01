using Contracts;
using EnergyConsumption.Business;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EnergyConsumption.GenerateSensorCountersService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            var usops = new UserSensorOperations(new DapperEnergyServicesConnectionStringProvider());

            var sdops = new SensorDataOperations(new DapperEnergyServicesConnectionStringProvider());

            var tzops = new TariffOperations(new DapperEnergyServicesConnectionStringProvider());

            var powerConsumptionTask = Task.Factory.StartNew(async() =>
            {
                while (!cancelTokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("powerConsumptionTask: consumption cycle begin");

                    usops.GeneratePowerConsumptionCycle();

                    Console.WriteLine("powerConsumptionTask: consumption cycle complete");

                    await Task.Delay(1000 * 60*1, cancelTokenSource.Token);
                }
            }, cancelTokenSource.Token);






            var contractAddress = "0xef012a171b50b1b9c6f775a54f54af86ce524685";

            var account = new Account() { Address = "0x8364d57F6511771CBe20aaf1CF8dA73a9B487F3f", PrivateKey = "0xd9309f665b7040ad35f7820a503d2765afa3e7a7e5e72125e8f50ae98905a749" };

            //var url = "http://127.0.0.1:7545";
            //var _account = new Nethereum.Web3.Accounts.Account(privateKey);
            //var _web3 = new Web3(_account, url);
            //_web3.TransactionManager.DefaultGas = 30000;
            //_web3.TransactionManager.DefaultGasPrice = 0;

            var cops = new Business.Blockchain.ContractOperations("http://127.0.0.1:7545", account.PrivateKey, contractAddress);

            var tx = cops.emptyTariffZones().Result;

            var syncTariffZoneTask = Task.Factory.StartNew(async () =>
            {
                while (!cancelTokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("syncTariffZoneTask: consumption cycle begin");

                    var bcTarifChksum = cops.getTariffZonesChkSum().Result;

                    var dbTarifChkSum = tzops.GetTariffZoneCheckSum();

                    if (bcTarifChksum != dbTarifChkSum)
                    {
                        var res1 = cops.setTariffZoneChkSum(dbTarifChkSum).Result;

                        var tariffs = tzops.GetList();

                        foreach (var t in tariffs)
                        {
                            var tx = cops.LoadTariffZone(t.TariffZoneId, t.RatePer1000).Result;

                            Console.WriteLine($"syncTariffZoneTask: txhash: {tx.TransactionHash}");
                        }
                    }

                    Console.WriteLine("syncTariffZoneTask: consumption cycle complete");

                    await Task.Delay(1000 * 15 * 1, cancelTokenSource.Token);
                }
            }, cancelTokenSource.Token);















            var syncSensorsTask = Task.Factory.StartNew(async () =>
            {
                while (!cancelTokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("syncSensorsTask: sensors sync begin");

                    var sensors = usops.GetList();

                    foreach(var s in sensors)
                    {
                        var sDbHash = usops.GetSensorRowChecksum(s.SensorId);

                        var sBcHash = cops.getSensorChkSum(s.SensorId).Result;

                        if(!System.Numerics.BigInteger.Equals(sDbHash, sBcHash))
                        {

                            var tx = await cops.insertSensor(s.SensorId);

                            var res = cops.getSensor(s.SensorId).Result;

                            var tx1 = cops.setSensorChkSum(s.SensorId, sDbHash).Result;
                        }
                        try
                        {
                            var lastCounters = usops.GetLastCounters(s.SensorId);

                            var tx3 = cops.insertLastSensorCounters(lastCounters.SensorId, lastCounters.SensorDataId, lastCounters.Value, lastCounters.Created);

                            var res1 = cops.getLastSensorCounters(lastCounters.SensorId).Result;
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                    }

                    Console.WriteLine("syncSensorsTask: sensors sync complete");

                    await Task.Delay(1000 * 15 * 1, cancelTokenSource.Token);
                }
            }, cancelTokenSource.Token);




            /*var syncSensorsDataTask = Task.Factory.StartNew(async () =>
            {
                while (!cancelTokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("syncSensorsDataTask: sensors sync begin");

                    var sensors = usops.GetList();

                    var sensorsData = sdops.GetList()

                    foreach (var s in sensors)
                    {
                        var sDbHash = usops.GetSensorRowChecksum(s.SensorId);

                        var sBcHash = cops.getSensorChkSum(s.SensorId).Result;

                        if (!System.Numerics.BigInteger.Equals(sDbHash, sBcHash))
                        {

                            var tx = await cops.insertSensor(s.SensorId);

                            var res = cops.getSensor(s.SensorId).Result;
                        }
                    }

                    Console.WriteLine("syncSensorsDataTask: sensors sync complete");

                    await Task.Delay(1000 * 15 * 1);
                }
            }, cancelTokenSource.Token);*/






            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                cancelTokenSource.Cancel();
            }

            Console.WriteLine("End of work detected. Press anykey to exit");
            Console.ReadLine();

        }
    }
}
