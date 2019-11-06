using System;
using System.Threading.Tasks;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace Blockchain.Business
{
    public class ContractOperations
    {
        public static string _abi = @"[
	{
		""constant"": true,
		""inputs"": [
			{
				""internalType"": ""bytes16"",
				""name"": ""sensor_id"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""uint16"",
				""name"": ""year"",
				""type"": ""uint16""
			},
			{
				""internalType"": ""uint8"",
				""name"": ""month"",
				""type"": ""uint8""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""index"",
				""type"": ""uint256""
			}
		],
		""name"": ""get_data"",
		""outputs"": [
			{
				""internalType"": ""uint64"",
				""name"": ""value"",
				""type"": ""uint64""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""constant"": false,
		""inputs"": [
			{
				""internalType"": ""bytes16"",
				""name"": ""_sensor_id"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""uint64"",
				""name"": ""_counter"",
				""type"": ""uint64""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""_created"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint8"",
				""name"": ""_month"",
				""type"": ""uint8""
			},
			{
				""internalType"": ""uint16"",
				""name"": ""_year"",
				""type"": ""uint16""
			}
		],
		""name"": ""add_data"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [
			{
				""internalType"": ""bytes16"",
				""name"": ""sensor_id"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""uint16"",
				""name"": ""year"",
				""type"": ""uint16""
			},
			{
				""internalType"": ""uint8"",
				""name"": ""month"",
				""type"": ""uint8""
			}
		],
		""name"": ""get_data_len"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""value"",
				""type"": ""uint256""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	}
]";
        public static string _contractByteCode = "608060405260006008806101000a81548160ff02191690831515021790555034801561002a57600080fd5b5060006008806101000a81548160ff0219169083151502179055506000600860096101000a81548163ffffffff021916908363ffffffff1602179055506000600860006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff16021790555061094e806100a36000396000f3fe608060405234801561001057600080fd5b50600436106100415760003560e01c80638343130c14610046578063d04ac74114610076578063f80e381214610092575b600080fd5b610060600480360361005b9190810190610705565b6100c2565b60405161006d9190610818565b60405180910390f35b610090600480360361008b9190810190610768565b610158565b005b6100ac60048036036100a791908101906106b6565b610472565b6040516100b991906107fd565b60405180910390f35b600060046000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008460ff16860261ffff1663ffffffff168152602001908152602001600020828154811061012857fe5b906000526020600020906004020160010160109054906101000a900467ffffffffffffffff169050949350505050565b606060046000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008460ff16840261ffff1663ffffffff168152602001908152602001600020805480602002602001604051908101604052809291908181526020016000905b828210156102c557838290600052602060002090600402016040518060c0016040529081600082015481526020016001820160009054906101000a900460801b6fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020016001820160109054906101000a900467ffffffffffffffff1667ffffffffffffffff1667ffffffffffffffff168152602001600282015481526020016003820160009054906101000a900460ff1660ff1660ff1681526020016003820160019054906101000a900461ffff1661ffff1661ffff1681525050815260200190600101906101d3565b5050505090506102d36105f3565b6040518060c0016040528060018451018152602001886fffffffffffffffffffffffffffffffff191681526020018767ffffffffffffffff1681526020018681526020018560ff1681526020018461ffff16815250905060046000886fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008560ff16850261ffff1663ffffffff16815260200190815260200160002081908060018154018082558091505090600182039060005260206000209060040201600090919290919091506000820151816000015560208201518160010160006101000a8154816fffffffffffffffffffffffffffffffff021916908360801c021790555060408201518160010160106101000a81548167ffffffffffffffff021916908367ffffffffffffffff1602179055506060820151816002015560808201518160030160006101000a81548160ff021916908360ff16021790555060a08201518160030160016101000a81548161ffff021916908361ffff16021790555050505050505050505050565b6000606060046000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008460ff16860261ffff1663ffffffff168152602001908152602001600020805480602002602001604051908101604052809291908181526020016000905b828210156105e157838290600052602060002090600402016040518060c0016040529081600082015481526020016001820160009054906101000a900460801b6fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020016001820160109054906101000a900467ffffffffffffffff1667ffffffffffffffff1667ffffffffffffffff168152602001600282015481526020016003820160009054906101000a900460ff1660ff1660ff1681526020016003820160019054906101000a900461ffff1661ffff1661ffff1681525050815260200190600101906104ef565b50505050905080519150509392505050565b6040518060c001604052806000815260200160006fffffffffffffffffffffffffffffffff19168152602001600067ffffffffffffffff16815260200160008152602001600060ff168152602001600061ffff1681525090565b60008135905061065c81610898565b92915050565b600081359050610671816108af565b92915050565b600081359050610686816108c6565b92915050565b60008135905061069b816108dd565b92915050565b6000813590506106b0816108f4565b92915050565b6000806000606084860312156106cb57600080fd5b60006106d98682870161064d565b93505060206106ea86828701610662565b92505060406106fb868287016106a1565b9150509250925092565b6000806000806080858703121561071b57600080fd5b60006107298782880161064d565b945050602061073a87828801610662565b935050604061074b878288016106a1565b925050606061075c87828801610677565b91505092959194509250565b600080600080600060a0868803121561078057600080fd5b600061078e8882890161064d565b955050602061079f8882890161068c565b94505060406107b088828901610677565b93505060606107c1888289016106a1565b92505060806107d288828901610662565b9150509295509295909350565b6107e88161086d565b82525050565b6107f781610877565b82525050565b600060208201905061081260008301846107df565b92915050565b600060208201905061082d60008301846107ee565b92915050565b60007fffffffffffffffffffffffffffffffff0000000000000000000000000000000082169050919050565b600061ffff82169050919050565b6000819050919050565b600067ffffffffffffffff82169050919050565b600060ff82169050919050565b6108a181610833565b81146108ac57600080fd5b50565b6108b88161085f565b81146108c357600080fd5b50565b6108cf8161086d565b81146108da57600080fd5b50565b6108e681610877565b81146108f157600080fd5b50565b6108fd8161088b565b811461090857600080fd5b5056fea365627a7a72315820fc9422b975291375a36d86a74b10c72645b0fe7bf501650f4fdc217010387ee36c6578706572696d656e74616cf564736f6c634300050b0040";
        //function add_data(bytes16 _sensor_id, uint64 _counter, uint256 _created, uint8 _month, uint16 _year) public
        public async Task<TransactionReceipt> AddData(Guid sensorId, long value, DateTime created, byte month, short year)
        {
            try
            {
                var f = _contract.GetFunction("add_data");

                var r = await f.SendTransactionAndWaitForReceiptAsync(_account.Address,
                    new Nethereum.Hex.HexTypes.HexBigInteger(2000000), new HexBigInteger(0), default, sensorId,
                    value, created.ToBinary(), month, year);

                return r;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<dynamic> GetData(Guid sensorId, short year, byte month, long index)
        {
            var f = _contract.GetFunction("get_data");

            return await f.CallAsync<dynamic>(sensorId, year, month, index);
        }
        public async Task<dynamic> GetDataLength(Guid sensorId, short year, byte month)
        {
            var f = _contract.GetFunction("get_data_len");

            return await f.CallAsync<dynamic>(sensorId, year, month);
        }

        public async Task<TransactionReceipt> insertBankAccount(uint userAccountId, Guid autopaySensorId)
        {
            try
            {
                var f = _contract.GetFunction("insertBankAccount");

                var r = await f.SendTransactionAndWaitForReceiptAsync(_account.Address,
                    new Nethereum.Hex.HexTypes.HexBigInteger(2000000), new HexBigInteger(0), default, userAccountId,
                    autopaySensorId);

                return r;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [FunctionOutput]
        public class GetBankAccountOutput
        {
            [Parameter("uint32", "user_account_id", 1)]
            public virtual uint UserAccountId { get; set; }
            [Parameter("bytes16", "autopay_sensor_id", 2)]
            public virtual Guid AutoPaySensorId { get; set; }
        }
        public async Task<dynamic> getBankAccount(uint userAccountId)
        {
            var f = _contract.GetFunction("getBankAccount");

            return await f.CallDeserializingToObjectAsync<GetBankAccountOutput>(userAccountId);
        }
        [FunctionOutput]
        public class GetCurrentInvoiceOutput
        {
            [Parameter("uint32", "user_account_id", 1)]
            public virtual uint UserAccountId { get; set; }
            [Parameter("uint64", "value", 2)]
            public virtual long Value { get; set; }
        }
        public async Task<dynamic> getCurrentInvoice(uint userAccountId)
        {
            var f = _contract.GetFunction("getCurrentInvoice");

            return await f.CallDeserializingToObjectAsync<GetCurrentInvoiceOutput>(userAccountId);
        }

        public async Task<TransactionReceipt> insertLastSensorCounters(Guid sensorId, Guid sensorDataId, long lastCountersValue, DateTime lastCountersDateTime)
        {
            var f = _contract.GetFunction("insertLastSensorCounters");

            return await f.SendTransactionAndWaitForReceiptAsync(_account.Address, new Nethereum.Hex.HexTypes.HexBigInteger(2000000), new HexBigInteger(0), default, sensorId, sensorDataId, lastCountersValue,lastCountersDateTime.ToBinary());
        }
        [FunctionOutput]
        public class GetLastSensorCountersOutput
        {
            [Parameter("bytes16", "_sensorDataId", 1)]
            public virtual Guid SensorDataId { get; set; }
            [Parameter("uint64", "_lastCountersValue", 2)]
            public virtual long LastCountersValue { get; set; }
            [Parameter("uint256", "_lastCountersDateTime", 3)]
            public virtual long LastCountersDateTime { get; set; }
        }
        //bytes16 _sensorDataId, uint64 _lastCountersValue, uint256 _lastCountersDateTime
        public async Task<dynamic> getLastSensorCounters(Guid sensorId)
        {
            var f = _contract.GetFunction("getLastSensorCounters");

            return await f.CallDeserializingToObjectAsync<GetLastSensorCountersOutput>(sensorId);
        }
        public async Task<TransactionReceipt> insertSensor(Guid sensorId)
        {
            var f = _contract.GetFunction("insertSensor");


            return await f.SendTransactionAndWaitForReceiptAsync(_account.Address, new Nethereum.Hex.HexTypes.HexBigInteger(2000000), new HexBigInteger(0), default, sensorId);
        }
        [FunctionOutput]
        public class GetSensorOutput
        {
            [Parameter("bytes16", "_sensor_id", 1)]
            public virtual Guid SensorId { get; set; }
            [Parameter("uint8", "_zone_id", 2)]
            public virtual byte Zone_id { get; set; }
            [Parameter("int64", "_sensor_data_hash", 3)]
            public virtual long Sensor_data_hash { get; set; }
        }
        public async Task<dynamic> getSensor(Guid sensorId)
        {
            try
            {
                var f = _contract.GetFunction("getSensor");

                return await f.CallDeserializingToObjectAsync<GetSensorOutput>(sensorId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<long> getSensorDataChkSum(Guid sensorId)
        {
            return await _contract.GetFunction("getSensorDataHash").CallAsync<dynamic>(sensorId);
        }
        public async Task<TransactionReceipt> setSensorDataChkSum(Guid sensorId, long chksum)
        {
            var f = _contract.GetFunction("setSensorDataHash");

            return await f.SendTransactionAndWaitForReceiptAsync(_account.Address, new Nethereum.Hex.HexTypes.HexBigInteger(2000000), new HexBigInteger(0), default, sensorId, chksum);
        }
        public async Task<dynamic> getSensorChkSum(Guid sensorId)
        {
            try
            {
                var f = _contract.GetFunction("getSensorHash");

                return await f.CallAsync<dynamic>(sensorId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TransactionReceipt> setSensorChkSum(Guid sensorId, long chksum)
        {
            var f = _contract.GetFunction("setSensorHash");

            return await f.SendTransactionAndWaitForReceiptAsync(_account.Address, new Nethereum.Hex.HexTypes.HexBigInteger(2000000), new HexBigInteger(0), default, sensorId, chksum);
        }
        public async Task<long> getTariffZonesChkSum()
        {
            return await _contract.GetFunction("getTariffZoneChkSum").CallAsync<long>();
        }
        public async Task<TransactionReceipt> setTariffZoneChkSum(long chksum)
        {
            var f = _contract.GetFunction("setTariffZoneChkSum");

            return await f.SendTransactionAndWaitForReceiptAsync(_account.Address, new Nethereum.Hex.HexTypes.HexBigInteger(2000000), new HexBigInteger(0), default, chksum);
        }
        public async Task<TransactionReceipt> emptyTariffZones()
        {
            var f = _contract.GetFunction("emptyTariffZoneChkSum");

            return await f.SendTransactionAndWaitForReceiptAsync(_account.Address, new Nethereum.Hex.HexTypes.HexBigInteger(2000000), new HexBigInteger(0), default);
        }
        private readonly string _url;
        private readonly string _privateKey;
        private readonly string _contractAddress;
        private readonly Web3 _web3;
        private readonly Account _account;
        private readonly Contract _contract;


        
        public ContractOperations(string url, string privateKey, string contractAddress)
        {
            _url = url;

            _privateKey = privateKey;

            _contractAddress = contractAddress;

            _account = new Nethereum.Web3.Accounts.Account(privateKey);

            _web3 = new Web3(_account, url);

            _contract = _web3.Eth.GetContract(_abi, contractAddress);

        }

        public Contract Contract => _contract;

        public Web3 Web3 => _web3;

        public Account Account => _account;


        public async Task<int> GetTariffZonesCount()
        {
           return await _contract.GetFunction("getTariffZones").CallAsync<int>();
        }
        //loadTariffZone
        public async Task<TransactionReceipt> LoadTariffZone(int zoneId, long ratePer1000)
        {
            var f =  _contract.GetFunction("loadTariffZone");

            //var receipt = web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(
            //    ContractOperations._abi,
            //    ContractOperations._contractByteCode,
            //    senderAddress,
            //    new Nethereum.Hex.HexTypes.HexBigInteger(2000000),
            //    //0,
            //    default)

            return await f.SendTransactionAndWaitForReceiptAsync(_account.Address, new Nethereum.Hex.HexTypes.HexBigInteger(2000000),new HexBigInteger(0),default, zoneId, ratePer1000);
        }
    }
}
