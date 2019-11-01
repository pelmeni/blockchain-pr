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
				""name"": ""_user_account_id"",
				""type"": ""uint32""
			},
			{
				""name"": ""_autopay_sensor_id"",
				""type"": ""bytes16""
			}
		],
		""name"": ""insertBankAccount"",
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
		""constant"": true,
		""inputs"": [
			{
				""name"": ""_user_account_id"",
				""type"": ""uint32""
			}
		],
		""name"": ""getBankAccount"",
		""outputs"": [
			{
				""name"": ""user_account_id"",
				""type"": ""uint32""
			},
			{
				""name"": ""autopay_sensor_id"",
				""type"": ""bytes16""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
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
		""inputs"": [
			{
				""name"": ""_user_account_id"",
				""type"": ""uint32""
			}
		],
		""name"": ""getCurrentInvoice"",
		""outputs"": [
			{
				""name"": ""user_account_id"",
				""type"": ""uint32""
			},
			{
				""name"": ""value"",
				""type"": ""uint64""
			}
		],
		""payable"": false,
		""stateMutability"": ""view"",
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
        public static string _contractByteCode = "60806040526000600560006101000a81548160ff0219169083151502179055506000600b5534801561003057600080fd5b506000600560006101000a81548160ff0219169083151502179055506000600560016101000a81548163ffffffff021916908363ffffffff1602179055506000600260006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff160217905550612537806100aa6000396000f3fe608060405260043610610143576000357c010000000000000000000000000000000000000000000000000000000090048063284192501461014857806329434e331461015f5780632cb527aa1461019c578063314d4d03146101c55780633792572d146101ee57806346c6b3421461021757806359173594146102405780635b34b9661461027e5780636851a5d3146102955780636f77926b146102be57806370ef11e3146102fd5780637413ce991461033a578063780eb19d14610365578063845ab3e91461038e5780639201de55146103b9578063a24042c5146103f6578063a87d942c14610434578063b3fa11ec1461045f578063c06c65111461049c578063c6774edd146104d9578063c950b22914610518578063d6ef5d9914610557578063dd87ec1814610580578063e76fcc11146105bf578063f5c5ad83146105e8575b600080fd5b34801561015457600080fd5b5061015d6105ff565b005b34801561016b57600080fd5b5061018660048036036101819190810190611e97565b610673565b60405161019391906122f8565b60405180910390f35b3480156101a857600080fd5b506101c360048036036101be9190810190612119565b6107db565b005b3480156101d157600080fd5b506101ec60048036036101e79190810190611f9a565b610956565b005b3480156101fa57600080fd5b50610215600480360361021091908101906120b4565b610a4b565b005b34801561022357600080fd5b5061023e60048036036102399190810190611ffd565b610b30565b005b34801561024c57600080fd5b506102676004803603610262919081019061208b565b610bea565b60405161027592919061232e565b60405180910390f35b34801561028a57600080fd5b50610293610c67565b005b3480156102a157600080fd5b506102bc60048036036102b79190810190611f4b565b610c7a565b005b3480156102ca57600080fd5b506102e560048036036102e09190810190611e6e565b610df8565b6040516102f4939291906122ba565b60405180910390f35b34801561030957600080fd5b50610324600480360361031f9190810190611ee6565b610f6e565b604051610331919061227d565b60405180910390f35b34801561034657600080fd5b5061034f610fc1565b60405161035c9190612313565b60405180910390f35b34801561037157600080fd5b5061038c60048036036103879190810190611ee6565b610fdb565b005b34801561039a57600080fd5b506103a3611259565b6040516103b0919061227d565b60405180910390f35b3480156103c557600080fd5b506103e060048036036103db9190810190612039565b611270565b6040516103ed9190612298565b60405180910390f35b34801561040257600080fd5b5061041d6004803603610418919081019061208b565b611476565b60405161042b929190612357565b60405180910390f35b34801561044057600080fd5b50610449611666565b6040516104569190612262565b60405180910390f35b34801561046b57600080fd5b5061048660048036036104819190810190611ee6565b611670565b604051610493919061227d565b60405180910390f35b3480156104a857600080fd5b506104c360048036036104be91908101906120f0565b61171c565b6040516104d09190612313565b60405180910390f35b3480156104e557600080fd5b5061050060048036036104fb9190810190611f0f565b611752565b60405161050f939291906121f4565b60405180910390f35b34801561052457600080fd5b5061053f600480360361053a9190810190611ee6565b6118fa565b60405161054e9392919061222b565b60405180910390f35b34801561056357600080fd5b5061057e60048036036105799190810190611ffd565b6119f6565b005b34801561058c57600080fd5b506105a760048036036105a29190810190611ee6565b611ab0565b6040516105b6939291906121f4565b60405180910390f35b3480156105cb57600080fd5b506105e660048036036105e19190810190612062565b611baa565b005b3480156105f457600080fd5b506105fd611bd9565b005b6000600260006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055506000600560016101000a81548163ffffffff021916908363ffffffff160217905550600560016101000a81549063ffffffff0219169055600460006106719190611bec565b565b600061067e83611270565b600960008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060000190805190602001906106d3929190611c14565b5081600960008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600101819055506001600a8590806001815401808255809150509060018203906000526020600020016000909192909190916101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555003600960008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600201819055506001600a805490500390509392505050565b600360008360ff1660ff16815260200190815260200160002060000160059054906101000a900460ff1615156108a657600482908060018154018082558091505090600182039060005260206000209060209182820401919006909192909190916101000a81548160ff021916908360ff160217905550506001600560018282829054906101000a900463ffffffff160192506101000a81548163ffffffff021916908363ffffffff1602179055506001600560006101000a81548160ff0219169083151502179055505b6060604051908101604052808360ff1681526020018263ffffffff16815260200160011515815250600360008460ff1660ff16815260200190815260200160002060008201518160000160006101000a81548160ff021916908360ff16021790555060208201518160000160016101000a81548163ffffffff021916908363ffffffff16021790555060408201518160000160056101000a81548160ff0219169083151502179055509050505050565b606060405190810160405280846fffffffffffffffffffffffffffffffff191681526020018367ffffffffffffffff1681526020018281525060076000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff02191690837001000000000000000000000000000000009004021790555060208201518160000160106101000a81548167ffffffffffffffff021916908367ffffffffffffffff1602179055506040820151816001015590505050505050565b6060604051908101604052808363ffffffff168152602001826fffffffffffffffffffffffffffffffff19168152602001600115158152506000808463ffffffff1663ffffffff16815260200190815260200160002060008201518160000160006101000a81548163ffffffff021916908363ffffffff16021790555060208201518160000160046101000a8154816fffffffffffffffffffffffffffffffff02191690837001000000000000000000000000000000009004021790555060408201518160000160146101000a81548160ff0219169083151502179055509050505050565b60066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff1615610be6578060066000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060030160006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055505b5050565b6000806000808463ffffffff1663ffffffff16815260200190815260200160002060000160009054906101000a900463ffffffff1691506000808463ffffffff1663ffffffff16815260200190815260200160002060000160049054906101000a9004700100000000000000000000000000000000029050915091565b6001600b60008282540192505081905550565b60066000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff1615610df357606060405190810160405280836fffffffffffffffffffffffffffffffff191681526020018267ffffffffffffffff1681526020014281525060066000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff02191690837001000000000000000000000000000000009004021790555060208201518160000160106101000a81548167ffffffffffffffff021916908367ffffffffffffffff160217905550604082015181600101559050505b505050565b6060600080600960008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600001600960008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060010154600960008773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060020154828054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610f5a5780601f10610f2f57610100808354040283529160200191610f5a565b820191906000526020600020905b815481529060010190602001808311610f3d57829003601f168201915b505050505092509250925092509193909250565b600060066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060030160009054906101000a900460070b9050919050565b6000600560019054906101000a900463ffffffff16905090565b60066000826fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff16151561109757600881908060018154018082558091505090600182039060005260206000209060029182820401919006601002909192909190916101000a8154816fffffffffffffffffffffffffffffffff021916908370010000000000000000000000000000000090040217905550505b60c060405190810160405280826fffffffffffffffffffffffffffffffff19168152602001600160ff168152602001600115158152602001600060070b815260200160006040519080825280602002602001820160405280156111095781602001602082028038833980820191505090505b508152602001600060070b81525060066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff02191690837001000000000000000000000000000000009004021790555060208201518160000160106101000a81548160ff021916908360ff16021790555060408201518160000160116101000a81548160ff02191690831515021790555060608201518160000160126101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055506080820151816002019080519060200190611220929190611c94565b5060a08201518160030160006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff16021790555090505050565b6000600260009054906101000a900460070b905090565b60608060206040519080825280601f01601f1916602001820160405280156112a75781602001600182028038833980820191505090505b509050600080905060008090505b60208110156113765760008160080260020a866001900402600102905060007f010000000000000000000000000000000000000000000000000000000000000002817effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff19161415156113685780848481518110151561132f57fe5b9060200101907effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916908160001a90535082806001019350505b5080806001019150506112b5565b506060816040519080825280601f01601f1916602001820160405280156113ac5781602001600182028038833980820191505090505b50905060008090505b828160ff16101561146a57838160ff168151811015156113d157fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f010000000000000000000000000000000000000000000000000000000000000002828260ff1681518110151561142d57fe5b9060200101907effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916908160001a90535080806001019150506113b5565b50809350505050919050565b6000806000808463ffffffff1663ffffffff16815260200190815260200160002060000160149054906101000a900460ff16156116615760008060008563ffffffff1663ffffffff16815260200190815260200160002060000160049054906101000a900470010000000000000000000000000000000002905060007001000000000000000000000000000000000260076000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160009054906101000a9004700100000000000000000000000000000000026fffffffffffffffffffffffffffffffff191614151561165f57600060076000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900467ffffffffffffffff169050600060066000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900460ff1690506000600360008360ff1660ff16815260200190815260200160002060000160019054906101000a900463ffffffff169050869550828163ffffffff160294505050505b505b915091565b6000600b54905090565b600060066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff16156117125760066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160129054906101000a900460070b9050611717565b600090505b919050565b6000600360008360ff1660ff16815260200190815260200160002060000160019054906101000a900463ffffffff169050919050565b600080600060066000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160009054906101000a90047001000000000000000000000000000000000260066000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900467ffffffffffffffff1660066000886fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff19168152602001908152602001600020600101549250925092509250925092565b600080600060066000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff16156119ee578360066000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900460ff1660066000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160129054906101000a900460070b9250925092506119ef565b5b9193909250565b60066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff1615611aac578060066000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160126101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055505b5050565b600080600060076000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160009054906101000a900470010000000000000000000000000000000002925060076000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900467ffffffffffffffff16915060076000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001015490509193909250565b80600260006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff16021790555050565b6001600b60008282540392505081905550565b50805460008255601f016020900490600052602060002090810190611c119190611d6a565b50565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f10611c5557805160ff1916838001178555611c83565b82800160010185558215611c83579182015b82811115611c82578251825591602001919060010190611c67565b5b509050611c909190611d6a565b5090565b82805482825590600052602060002090600101600290048101928215611d595791602002820160005b83821115611d1b57835183826101000a8154816fffffffffffffffffffffffffffffffff0219169083700100000000000000000000000000000000900402179055509260200192601001602081600f01049283019260010302611cbd565b8015611d575782816101000a8154906fffffffffffffffffffffffffffffffff0219169055601001602081600f01049283019260010302611d1b565b505b509050611d669190611d8f565b5090565b611d8c91905b80821115611d88576000816000905550600101611d70565b5090565b90565b611dcb91905b80821115611dc757600081816101000a8154906fffffffffffffffffffffffffffffffff021916905550600101611d95565b5090565b90565b6000611dda8235612429565b905092915050565b6000611dee823561243b565b905092915050565b6000611e028235612467565b905092915050565b6000611e168235612471565b905092915050565b6000611e2a823561247e565b905092915050565b6000611e3e8235612488565b905092915050565b6000611e528235612498565b905092915050565b6000611e6682356124ac565b905092915050565b600060208284031215611e8057600080fd5b6000611e8e84828501611dce565b91505092915050565b600080600060608486031215611eac57600080fd5b6000611eba86828701611dce565b9350506020611ecb86828701611df6565b9250506040611edc86828701611e1e565b9150509250925092565b600060208284031215611ef857600080fd5b6000611f0684828501611de2565b91505092915050565b60008060408385031215611f2257600080fd5b6000611f3085828601611de2565b9250506020611f4185828601611de2565b9150509250929050565b600080600060608486031215611f6057600080fd5b6000611f6e86828701611de2565b9350506020611f7f86828701611de2565b9250506040611f9086828701611e46565b9150509250925092565b60008060008060808587031215611fb057600080fd5b6000611fbe87828801611de2565b9450506020611fcf87828801611de2565b9350506040611fe087828801611e46565b9250506060611ff187828801611e1e565b91505092959194509250565b6000806040838503121561201057600080fd5b600061201e85828601611de2565b925050602061202f85828601611e0a565b9150509250929050565b60006020828403121561204b57600080fd5b600061205984828501611df6565b91505092915050565b60006020828403121561207457600080fd5b600061208284828501611e0a565b91505092915050565b60006020828403121561209d57600080fd5b60006120ab84828501611e32565b91505092915050565b600080604083850312156120c757600080fd5b60006120d585828601611e32565b92505060206120e685828601611de2565b9150509250929050565b60006020828403121561210257600080fd5b600061211084828501611e5a565b91505092915050565b6000806040838503121561212c57600080fd5b600061213a85828601611e5a565b925050602061214b85828601611e32565b9150509250929050565b61215e8161238b565b82525050565b61216d816123b7565b82525050565b61217c816123c1565b82525050565b600061218d82612380565b8084526121a18160208601602086016124b9565b6121aa816124ec565b602085010191505092915050565b6121c1816123ee565b82525050565b6121d0816123f8565b82525050565b6121df81612408565b82525050565b6121ee8161241c565b82525050565b60006060820190506122096000830186612155565b61221660208301856121d6565b61222360408301846121b8565b949350505050565b60006060820190506122406000830186612155565b61224d60208301856121e5565b61225a6040830184612173565b949350505050565b60006020820190506122776000830184612164565b92915050565b60006020820190506122926000830184612173565b92915050565b600060208201905081810360008301526122b28184612182565b905092915050565b600060608201905081810360008301526122d48186612182565b90506122e360208301856121b8565b6122f060408301846121b8565b949350505050565b600060208201905061230d60008301846121b8565b92915050565b600060208201905061232860008301846121c7565b92915050565b600060408201905061234360008301856121c7565b6123506020830184612155565b9392505050565b600060408201905061236c60008301856121c7565b61237960208301846121d6565b9392505050565b600081519050919050565b60007fffffffffffffffffffffffffffffffff0000000000000000000000000000000082169050919050565b6000819050919050565b60008160070b9050919050565b600073ffffffffffffffffffffffffffffffffffffffff82169050919050565b6000819050919050565b600063ffffffff82169050919050565b600067ffffffffffffffff82169050919050565b600060ff82169050919050565b6000612434826123ce565b9050919050565b60007fffffffffffffffffffffffffffffffff0000000000000000000000000000000082169050919050565b6000819050919050565b60008160070b9050919050565b6000819050919050565b600063ffffffff82169050919050565b600067ffffffffffffffff82169050919050565b600060ff82169050919050565b60005b838110156124d75780820151818401526020810190506124bc565b838111156124e6576000848401525b50505050565b6000601f19601f830116905091905056fea265627a7a7230582093eb894fc95150e526c0fa10228222a4db2fcf78b5594361009d659c1759f8e76c6578706572696d656e74616cf50037";


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
            public virtual Guid UserAccountId { get; set; }
            [Parameter("bytes16", "autopay_sensor_id", 2)]
            public virtual byte AutoPaySensorId { get; set; }
        }
        public async Task<dynamic> getBankAccount(int userAccountId)
        {
            var f = _contract.GetFunction("getBankAccount");

            return await f.CallDeserializingToObjectAsync<GetBankAccountOutput>(userAccountId);
        }
        [FunctionOutput]
        public class GetCurrentInvoiceOutput
        {
            [Parameter("uint32", "user_account_id", 1)]
            public virtual Guid UserAccountId { get; set; }
            [Parameter("uint64", "value", 2)]
            public virtual byte Value { get; set; }
        }
        public async Task<dynamic> getCurrentInvoice(int userAccountId)
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
