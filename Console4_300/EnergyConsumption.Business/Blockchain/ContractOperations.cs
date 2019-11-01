using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace EnergyConsumption.Business.Blockchain
{
    public class ContractOperations
    {
        public static string _abi= @"[
	{
		""constant"": false,
		""inputs"": [],
		""name"": ""emptyTariffZoneChkSum"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": false,
		""inputs"": [
			{
				""name"": ""userAddress"",
				""type"": ""address""
			},
			{
				""name"": ""email"",
				""type"": ""bytes32""
			},
			{
				""name"": ""age"",
				""type"": ""uint256""
			}
		],
		""name"": ""insertUser"",
		""outputs"": [
			{
				""name"": ""index"",
				""type"": ""uint256""
			}
		],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": false,
		""inputs"": [
			{
				""name"": ""_zone_id"",
				""type"": ""uint8""
			},
			{
				""name"": ""_rate_per_1000"",
				""type"": ""uint32""
			}
		],
		""name"": ""loadTariffZone"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": false,
		""inputs"": [
			{
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""name"": ""_sensorDataId"",
				""type"": ""bytes16""
			},
			{
				""name"": ""_lastCountersValue"",
				""type"": ""uint64""
			},
			{
				""name"": ""_lastCountersDateTime"",
				""type"": ""uint256""
			}
		],
		""name"": ""insertLastSensorCounters"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": false,
		""inputs"": [
			{
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""name"": ""hash"",
				""type"": ""int64""
			}
		],
		""name"": ""setSensorHash"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": false,
		""inputs"": [],
		""name"": ""incrementCounter"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": false,
		""inputs"": [
			{
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""name"": ""_sensorDataId"",
				""type"": ""bytes16""
			},
			{
				""name"": ""_counter"",
				""type"": ""uint64""
			}
		],
		""name"": ""insertSensorData"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [
			{
				""name"": ""userAddress"",
				""type"": ""address""
			}
		],
		""name"": ""getUser"",
		""outputs"": [
			{
				""name"": ""userEmail"",
				""type"": ""string""
			},
			{
				""name"": ""userAge"",
				""type"": ""uint256""
			},
			{
				""name"": ""index"",
				""type"": ""uint256""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [
			{
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getSensorHash"",
		""outputs"": [
			{
				""name"": """",
				""type"": ""int64""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [],
		""name"": ""getTariffZones"",
		""outputs"": [
			{
				""name"": """",
				""type"": ""uint32""
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
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""insertSensor"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [],
		""name"": ""getTariffZoneChkSum"",
		""outputs"": [
			{
				""name"": """",
				""type"": ""int64""
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
				""name"": ""x"",
				""type"": ""bytes32""
			}
		],
		""name"": ""bytes32ToString"",
		""outputs"": [
			{
				""name"": """",
				""type"": ""string""
			}
		],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [],
		""name"": ""getCount"",
		""outputs"": [
			{
				""name"": """",
				""type"": ""int256""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [
			{
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getSensorDataHash"",
		""outputs"": [
			{
				""name"": """",
				""type"": ""int64""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [
			{
				""name"": ""zone_id"",
				""type"": ""uint8""
			}
		],
		""name"": ""getTariffZoneByZoneId"",
		""outputs"": [
			{
				""name"": """",
				""type"": ""uint32""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [
			{
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""name"": ""_sensorDataId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getSensorData"",
		""outputs"": [
			{
				""name"": """",
				""type"": ""bytes16""
			},
			{
				""name"": """",
				""type"": ""uint64""
			},
			{
				""name"": """",
				""type"": ""uint256""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [
			{
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getSensor"",
		""outputs"": [
			{
				""name"": ""_sensor_id"",
				""type"": ""bytes16""
			},
			{
				""name"": ""_zone_id"",
				""type"": ""uint8""
			},
			{
				""name"": ""_sensor_data_hash"",
				""type"": ""int64""
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
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""name"": ""hash"",
				""type"": ""int64""
			}
		],
		""name"": ""setSensorDataHash"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": true,
		""inputs"": [
			{
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getLastSensorCounters"",
		""outputs"": [
			{
				""name"": ""_sensorDataId"",
				""type"": ""bytes16""
			},
			{
				""name"": ""_lastCountersValue"",
				""type"": ""uint64""
			},
			{
				""name"": ""_lastCountersDateTime"",
				""type"": ""uint256""
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
				""name"": ""chksum"",
				""type"": ""int64""
			}
		],
		""name"": ""setTariffZoneChkSum"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""constant"": false,
		""inputs"": [],
		""name"": ""decrementCounter"",
		""outputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	}
]";

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
            public virtual byte LastCountersValue { get; set; }
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

        public static string _contractByteCode = "60806040526000600360006101000a81548160ff021916908315150217905550600060095534801561003057600080fd5b506000600360006101000a81548160ff0219169083151502179055506000600360016101000a81548163ffffffff021916908363ffffffff16021790555060008060006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff160217905550612065806100a96000396000f3fe608060405260043610610122576000357c010000000000000000000000000000000000000000000000000000000090048063284192501461012757806329434e331461013e5780632cb527aa1461017b578063314d4d03146101a457806346c6b342146101cd5780635b34b966146101f65780636851a5d31461020d5780636f77926b1461023657806370ef11e3146102755780637413ce99146102b2578063780eb19d146102dd578063845ab3e9146103065780639201de5514610331578063a87d942c1461036e578063b3fa11ec14610399578063c06c6511146103d6578063c6774edd14610413578063c950b22914610452578063d6ef5d9914610491578063dd87ec18146104ba578063e76fcc11146104f9578063f5c5ad8314610522575b600080fd5b34801561013357600080fd5b5061013c610539565b005b34801561014a57600080fd5b5061016560048036036101609190810190611a7c565b6105ac565b6040516101729190611e78565b60405180910390f35b34801561018757600080fd5b506101a2600480360361019d9190810190611c99565b610714565b005b3480156101b057600080fd5b506101cb60048036036101c69190810190611b7f565b61088f565b005b3480156101d957600080fd5b506101f460048036036101ef9190810190611be2565b610984565b005b34801561020257600080fd5b5061020b610a3e565b005b34801561021957600080fd5b50610234600480360361022f9190810190611b30565b610a51565b005b34801561024257600080fd5b5061025d60048036036102589190810190611a53565b610bcf565b60405161026c93929190611e3a565b60405180910390f35b34801561028157600080fd5b5061029c60048036036102979190810190611acb565b610d45565b6040516102a99190611dfd565b60405180910390f35b3480156102be57600080fd5b506102c7610d98565b6040516102d49190611e93565b60405180910390f35b3480156102e957600080fd5b5061030460048036036102ff9190810190611acb565b610db2565b005b34801561031257600080fd5b5061031b611030565b6040516103289190611dfd565b60405180910390f35b34801561033d57600080fd5b5061035860048036036103539190810190611c1e565b611046565b6040516103659190611e18565b60405180910390f35b34801561037a57600080fd5b5061038361124c565b6040516103909190611de2565b60405180910390f35b3480156103a557600080fd5b506103c060048036036103bb9190810190611acb565b611256565b6040516103cd9190611dfd565b60405180910390f35b3480156103e257600080fd5b506103fd60048036036103f89190810190611c70565b611302565b60405161040a9190611e93565b60405180910390f35b34801561041f57600080fd5b5061043a60048036036104359190810190611af4565b611338565b60405161044993929190611d74565b60405180910390f35b34801561045e57600080fd5b5061047960048036036104749190810190611acb565b6114e0565b60405161048893929190611dab565b60405180910390f35b34801561049d57600080fd5b506104b860048036036104b39190810190611be2565b6115dc565b005b3480156104c657600080fd5b506104e160048036036104dc9190810190611acb565b611696565b6040516104f093929190611d74565b60405180910390f35b34801561050557600080fd5b50610520600480360361051b9190810190611c47565b611790565b005b34801561052e57600080fd5b506105376117be565b005b60008060006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055506000600360016101000a81548163ffffffff021916908363ffffffff160217905550600360016101000a81549063ffffffff0219169055600260006105aa91906117d1565b565b60006105b783611046565b600760008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600001908051906020019061060c9291906117f9565b5081600760008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060010181905550600160088590806001815401808255809150509060018203906000526020600020016000909192909190916101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555003600760008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206002018190555060016008805490500390509392505050565b600160008360ff1660ff16815260200190815260200160002060000160059054906101000a900460ff1615156107df57600282908060018154018082558091505090600182039060005260206000209060209182820401919006909192909190916101000a81548160ff021916908360ff160217905550506001600360018282829054906101000a900463ffffffff160192506101000a81548163ffffffff021916908363ffffffff1602179055506001600360006101000a81548160ff0219169083151502179055505b6060604051908101604052808360ff1681526020018263ffffffff16815260200160011515815250600160008460ff1660ff16815260200190815260200160002060008201518160000160006101000a81548160ff021916908360ff16021790555060208201518160000160016101000a81548163ffffffff021916908363ffffffff16021790555060408201518160000160056101000a81548160ff0219169083151502179055509050505050565b606060405190810160405280846fffffffffffffffffffffffffffffffff191681526020018367ffffffffffffffff1681526020018281525060056000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff02191690837001000000000000000000000000000000009004021790555060208201518160000160106101000a81548167ffffffffffffffff021916908367ffffffffffffffff1602179055506040820151816001015590505050505050565b60046000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff1615610a3a578060046000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060030160006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055505b5050565b6001600960008282540192505081905550565b60046000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff1615610bca57606060405190810160405280836fffffffffffffffffffffffffffffffff191681526020018267ffffffffffffffff1681526020014281525060046000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff02191690837001000000000000000000000000000000009004021790555060208201518160000160106101000a81548167ffffffffffffffff021916908367ffffffffffffffff160217905550604082015181600101559050505b505050565b6060600080600760008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600001600760008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060010154600760008773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060020154828054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610d315780601f10610d0657610100808354040283529160200191610d31565b820191906000526020600020905b815481529060010190602001808311610d1457829003601f168201915b505050505092509250925092509193909250565b600060046000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060030160009054906101000a900460070b9050919050565b6000600360019054906101000a900463ffffffff16905090565b60046000826fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff161515610e6e57600681908060018154018082558091505090600182039060005260206000209060029182820401919006601002909192909190916101000a8154816fffffffffffffffffffffffffffffffff021916908370010000000000000000000000000000000090040217905550505b60c060405190810160405280826fffffffffffffffffffffffffffffffff19168152602001600160ff168152602001600115158152602001600060070b81526020016000604051908082528060200260200182016040528015610ee05781602001602082028038833980820191505090505b508152602001600060070b81525060046000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff02191690837001000000000000000000000000000000009004021790555060208201518160000160106101000a81548160ff021916908360ff16021790555060408201518160000160116101000a81548160ff02191690831515021790555060608201518160000160126101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055506080820151816002019080519060200190610ff7929190611879565b5060a08201518160030160006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff16021790555090505050565b60008060009054906101000a900460070b905090565b60608060206040519080825280601f01601f19166020018201604052801561107d5781602001600182028038833980820191505090505b509050600080905060008090505b602081101561114c5760008160080260020a866001900402600102905060007f010000000000000000000000000000000000000000000000000000000000000002817effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff191614151561113e5780848481518110151561110557fe5b9060200101907effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916908160001a90535082806001019350505b50808060010191505061108b565b506060816040519080825280601f01601f1916602001820160405280156111825781602001600182028038833980820191505090505b50905060008090505b828160ff16101561124057838160ff168151811015156111a757fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f010000000000000000000000000000000000000000000000000000000000000002828260ff1681518110151561120357fe5b9060200101907effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916908160001a905350808060010191505061118b565b50809350505050919050565b6000600954905090565b600060046000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff16156112f85760046000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160129054906101000a900460070b90506112fd565b600090505b919050565b6000600160008360ff1660ff16815260200190815260200160002060000160019054906101000a900463ffffffff169050919050565b600080600060046000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160009054906101000a90047001000000000000000000000000000000000260046000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900467ffffffffffffffff1660046000886fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff19168152602001908152602001600020600101549250925092509250925092565b600080600060046000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff16156115d4578360046000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900460ff1660046000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160129054906101000a900460070b9250925092506115d5565b5b9193909250565b60046000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff1615611692578060046000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160126101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055505b5050565b600080600060056000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160009054906101000a900470010000000000000000000000000000000002925060056000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900467ffffffffffffffff16915060056000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001015490509193909250565b806000806101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff16021790555050565b6001600960008282540392505081905550565b50805460008255601f0160209004906000526020600020908101906117f6919061194f565b50565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061183a57805160ff1916838001178555611868565b82800160010185558215611868579182015b8281111561186757825182559160200191906001019061184c565b5b509050611875919061194f565b5090565b8280548282559060005260206000209060010160029004810192821561193e5791602002820160005b8382111561190057835183826101000a8154816fffffffffffffffffffffffffffffffff0219169083700100000000000000000000000000000000900402179055509260200192601001602081600f010492830192600103026118a2565b801561193c5782816101000a8154906fffffffffffffffffffffffffffffffff0219169055601001602081600f01049283019260010302611900565b505b50905061194b9190611974565b5090565b61197191905b8082111561196d576000816000905550600101611955565b5090565b90565b6119b091905b808211156119ac57600081816101000a8154906fffffffffffffffffffffffffffffffff02191690555060010161197a565b5090565b90565b60006119bf8235611f57565b905092915050565b60006119d38235611f69565b905092915050565b60006119e78235611f95565b905092915050565b60006119fb8235611f9f565b905092915050565b6000611a0f8235611fac565b905092915050565b6000611a238235611fb6565b905092915050565b6000611a378235611fc6565b905092915050565b6000611a4b8235611fda565b905092915050565b600060208284031215611a6557600080fd5b6000611a73848285016119b3565b91505092915050565b600080600060608486031215611a9157600080fd5b6000611a9f868287016119b3565b9350506020611ab0868287016119db565b9250506040611ac186828701611a03565b9150509250925092565b600060208284031215611add57600080fd5b6000611aeb848285016119c7565b91505092915050565b60008060408385031215611b0757600080fd5b6000611b15858286016119c7565b9250506020611b26858286016119c7565b9150509250929050565b600080600060608486031215611b4557600080fd5b6000611b53868287016119c7565b9350506020611b64868287016119c7565b9250506040611b7586828701611a2b565b9150509250925092565b60008060008060808587031215611b9557600080fd5b6000611ba3878288016119c7565b9450506020611bb4878288016119c7565b9350506040611bc587828801611a2b565b9250506060611bd687828801611a03565b91505092959194509250565b60008060408385031215611bf557600080fd5b6000611c03858286016119c7565b9250506020611c14858286016119ef565b9150509250929050565b600060208284031215611c3057600080fd5b6000611c3e848285016119db565b91505092915050565b600060208284031215611c5957600080fd5b6000611c67848285016119ef565b91505092915050565b600060208284031215611c8257600080fd5b6000611c9084828501611a3f565b91505092915050565b60008060408385031215611cac57600080fd5b6000611cba85828601611a3f565b9250506020611ccb85828601611a17565b9150509250929050565b611cde81611eb9565b82525050565b611ced81611ee5565b82525050565b611cfc81611eef565b82525050565b6000611d0d82611eae565b808452611d21816020860160208601611fe7565b611d2a8161201a565b602085010191505092915050565b611d4181611f1c565b82525050565b611d5081611f26565b82525050565b611d5f81611f36565b82525050565b611d6e81611f4a565b82525050565b6000606082019050611d896000830186611cd5565b611d966020830185611d56565b611da36040830184611d38565b949350505050565b6000606082019050611dc06000830186611cd5565b611dcd6020830185611d65565b611dda6040830184611cf3565b949350505050565b6000602082019050611df76000830184611ce4565b92915050565b6000602082019050611e126000830184611cf3565b92915050565b60006020820190508181036000830152611e328184611d02565b905092915050565b60006060820190508181036000830152611e548186611d02565b9050611e636020830185611d38565b611e706040830184611d38565b949350505050565b6000602082019050611e8d6000830184611d38565b92915050565b6000602082019050611ea86000830184611d47565b92915050565b600081519050919050565b60007fffffffffffffffffffffffffffffffff0000000000000000000000000000000082169050919050565b6000819050919050565b60008160070b9050919050565b600073ffffffffffffffffffffffffffffffffffffffff82169050919050565b6000819050919050565b600063ffffffff82169050919050565b600067ffffffffffffffff82169050919050565b600060ff82169050919050565b6000611f6282611efc565b9050919050565b60007fffffffffffffffffffffffffffffffff0000000000000000000000000000000082169050919050565b6000819050919050565b60008160070b9050919050565b6000819050919050565b600063ffffffff82169050919050565b600067ffffffffffffffff82169050919050565b600060ff82169050919050565b60005b83811015612005578082015181840152602081019050611fea565b83811115612014576000848401525b50505050565b6000601f19601f830116905091905056fea265627a7a7230582034887699a7ccd4fd716b0aeb1bbf24befb2efd18775705ac8c442facb7c096166c6578706572696d656e74616cf50037";
        
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
