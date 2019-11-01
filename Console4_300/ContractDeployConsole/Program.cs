using Blockchain.Business;
using Contracts;
using Nethereum.Web3;
using System;
using System.Diagnostics;

namespace ContractDeployConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account() { Address = "0xCf6e63CAA7Fd568D2a9ebBf5Cc166A410Aa3EB03", PrivateKey = "0xc543ec2a26c7698771736d1cf339db5dbace04c11d1198eb6c2f25185bc8a306" };
            //var account = new Account() { Address = "0x8364d57F6511771CBe20aaf1CF8dA73a9B487F3f", PrivateKey = "0xd9309f665b7040ad35f7820a503d2765afa3e7a7e5e72125e8f50ae98905a749" };
            //
            var url = "http://127.0.0.1:7545";

            var _account = new Nethereum.Web3.Accounts.Account(account.PrivateKey);

            var _web3 = new Web3(_account, url);

            _web3.TransactionManager.DefaultGas = 30000;

            _web3.TransactionManager.DefaultGasPrice = 0;
                                 
            var receipt = _web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(
                          ContractOperations._abi,
                          ContractOperations._contractByteCode,
                            account.Address,
                            new Nethereum.Hex.HexTypes.HexBigInteger(3000000),
                            //0,
                            default)
                            .Result;

            var response = $"contract address: {receipt.ContractAddress}\r\ngas used: {receipt.GasUsed.Value}\r\n txh:{receipt.TransactionHash}";

            Debug.WriteLine(response);

            Console.WriteLine(response);

            Console.WriteLine("Contract deploy complete. Press Return to exit.");

            Console.ReadLine();
        }
    }
}
