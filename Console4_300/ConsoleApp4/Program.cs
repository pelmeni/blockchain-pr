using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Contracts;
using Nethereum.Util;
using Nethereum.Web3;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {


            var privateKey = "c543ec2a26c7698771736d1cf339db5dbace04c11d1198eb6c2f25185bc8a306";

            var senderAddress = "0xCf6e63CAA7Fd568D2a9ebBf5Cc166A410Aa3EB03";

            var contractAddress = "0x8d242e4c6bc2a11b799d1978551f6985a2727cdc";

            var url = "http://127.0.0.1:7545";

            var _account = new Nethereum.Web3.Accounts.Account(privateKey);

            var _web3 = new Web3(_account, url);
            _web3.TransactionManager.DefaultGas = 30000;
            _web3.TransactionManager.DefaultGasPrice = 0;
            

           

            var ops = new ContractOperations("http://127.0.0.1:7545", privateKey, contractAddress);

            //ops.Web3.Eth.GasPrice = Nethereum.Web3.Web3.Convert.ToWei(25, UnitConversion.EthUnit.Gwei);
            
            ////var account = new Nethereum.Web3.Accounts.Account(privateKey);

            ////var web3 = new Web3(account,"http://127.0.0.1:7545");




            //var contract = web3.Eth.GetContract(abi, "0xEf012A171B50b1B9c6f775a54F54Af86CE524685");

            //var task = contract.GetFunction("getTariffZones").CallAsync<int>();

            //var r = task.Result;

            int tarifs = ops.GetTariffZones().Result;

            var res=ops.LoadTariffZone(1, 1100).Result;

                       
           // receipt = await MineAndGetReceiptAsync(web3, transactionHash);

        }
    }
}
