using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Nethereum.Util;
using Nethereum.Web3;

namespace ConsoleApp4
{
    class Program
    {
        public static void Deploy(Web3 web3, string senderAddress)
        {
            var receipt = web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(
                ContractOperations._abi,
                ContractOperations._contractByteCode, 
                senderAddress,
                new Nethereum.Hex.HexTypes.HexBigInteger(2000000),
                //0,
                default)
                .Result;
        }
        static void Main(string[] args)
        {


            var privateKey = "0xd9309f665b7040ad35f7820a503d2765afa3e7a7e5e72125e8f50ae98905a749";

            var senderAddress = "0x8364d57F6511771CBe20aaf1CF8dA73a9B487F3f";

            var contractAddress = "0xEf012A171B50b1B9c6f775a54F54Af86CE524685";

            var url = "http://127.0.0.1:7545";

            var _account = new Nethereum.Web3.Accounts.Account(privateKey);

            var _web3 = new Web3(_account, url);
            _web3.TransactionManager.DefaultGas = 30000;
            _web3.TransactionManager.DefaultGasPrice = 0;
            

            Deploy(_web3, senderAddress);
            

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
