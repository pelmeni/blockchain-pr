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


            var privateKey = Contract14._privateKey;

            var senderAddress = Contract14._senderAddress;

            //var contractAddress = "0xEf012A171B50b1B9c6f775a54F54Af86CE524685";

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
