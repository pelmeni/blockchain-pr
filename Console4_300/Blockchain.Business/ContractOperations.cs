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
				""internalType"": ""address"",
				""name"": ""userAddress"",
				""type"": ""address""
			},
			{
				""internalType"": ""bytes32"",
				""name"": ""email"",
				""type"": ""bytes32""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""age"",
				""type"": ""uint256""
			}
		],
		""name"": ""insertUser"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
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
				""internalType"": ""uint8"",
				""name"": ""_zone_id"",
				""type"": ""uint8""
			},
			{
				""internalType"": ""uint32"",
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
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""bytes16"",
				""name"": ""_sensorDataId"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""uint64"",
				""name"": ""_lastCountersValue"",
				""type"": ""uint64""
			},
			{
				""internalType"": ""uint256"",
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
				""internalType"": ""uint32"",
				""name"": ""_user_account_id"",
				""type"": ""uint32""
			},
			{
				""internalType"": ""bytes16"",
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
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""int64"",
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
				""internalType"": ""uint32"",
				""name"": ""_user_account_id"",
				""type"": ""uint32""
			}
		],
		""name"": ""getBankAccount"",
		""outputs"": [
			{
				""internalType"": ""uint32"",
				""name"": ""user_account_id"",
				""type"": ""uint32""
			},
			{
				""internalType"": ""bytes16"",
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
		""inputs"": [
			{
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""bytes16"",
				""name"": ""_sensorDataId"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""uint64"",
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
				""internalType"": ""address"",
				""name"": ""userAddress"",
				""type"": ""address""
			}
		],
		""name"": ""getUser"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": ""userEmail"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""userAge"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""uint256"",
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
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getSensorHash"",
		""outputs"": [
			{
				""internalType"": ""int64"",
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
				""internalType"": ""uint32"",
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
				""internalType"": ""bytes16"",
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
				""internalType"": ""int64"",
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
				""internalType"": ""bytes32"",
				""name"": ""x"",
				""type"": ""bytes32""
			}
		],
		""name"": ""bytes32ToString"",
		""outputs"": [
			{
				""internalType"": ""string"",
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
				""internalType"": ""uint32"",
				""name"": ""_user_account_id"",
				""type"": ""uint32""
			}
		],
		""name"": ""getCurrentInvoice"",
		""outputs"": [
			{
				""internalType"": ""uint32"",
				""name"": ""user_account_id"",
				""type"": ""uint32""
			},
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
		""constant"": true,
		""inputs"": [
			{
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getSensorDataHash"",
		""outputs"": [
			{
				""internalType"": ""int64"",
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
				""internalType"": ""uint8"",
				""name"": ""zone_id"",
				""type"": ""uint8""
			}
		],
		""name"": ""getTariffZoneByZoneId"",
		""outputs"": [
			{
				""internalType"": ""uint32"",
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
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""bytes16"",
				""name"": ""_sensorDataId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getSensorData"",
		""outputs"": [
			{
				""internalType"": ""bytes16"",
				""name"": """",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""uint64"",
				""name"": """",
				""type"": ""uint64""
			},
			{
				""internalType"": ""uint256"",
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
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getSensor"",
		""outputs"": [
			{
				""internalType"": ""bytes16"",
				""name"": ""_sensor_id"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""uint8"",
				""name"": ""_zone_id"",
				""type"": ""uint8""
			},
			{
				""internalType"": ""int64"",
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
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""int64"",
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
				""internalType"": ""bytes16"",
				""name"": ""_sensorId"",
				""type"": ""bytes16""
			}
		],
		""name"": ""getLastSensorCounters"",
		""outputs"": [
			{
				""internalType"": ""bytes16"",
				""name"": ""_sensorDataId"",
				""type"": ""bytes16""
			},
			{
				""internalType"": ""uint64"",
				""name"": ""_lastCountersValue"",
				""type"": ""uint64""
			},
			{
				""internalType"": ""uint256"",
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
				""internalType"": ""int64"",
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
		""inputs"": [],
		""payable"": false,
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	}
]";
        public static string _contractByteCode = "60806040526000600560006101000a81548160ff02191690831515021790555034801561002b57600080fd5b506000600560006101000a81548160ff0219169083151502179055506000600560016101000a81548163ffffffff021916908363ffffffff1602179055506000600260006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff160217905550612289806100a56000396000f3fe608060405234801561001057600080fd5b50600436106101425760003560e01c8063780eb19d116100b8578063c06c65111161007c578063c06c651114610389578063c6774edd146103b9578063c950b229146103eb578063d6ef5d991461041d578063dd87ec1814610439578063e76fcc111461046b57610142565b8063780eb19d146102be578063845ab3e9146102da5780639201de55146102f8578063a24042c514610328578063b3fa11ec1461035957610142565b806346c6b3421161010a57806346c6b342146101d557806359173594146101f15780636851a5d3146102225780636f77926b1461023e57806370ef11e3146102705780637413ce99146102a057610142565b8063284192501461014757806329434e33146101515780632cb527aa14610181578063314d4d031461019d5780633792572d146101b9575b600080fd5b61014f610487565b005b61016b60048036036101669190810190611bbc565b6104fb565b6040516101789190611ff6565b60405180910390f35b61019b60048036036101969190810190611e3e565b610663565b005b6101b760048036036101b29190810190611cbf565b6107db565b005b6101d360048036036101ce9190810190611dd9565b6108be565b005b6101ef60048036036101ea9190810190611d22565b610991565b005b61020b60048036036102069190810190611db0565b610a4b565b60405161021992919061202c565b60405180910390f35b61023c60048036036102379190810190611c70565b610ab8565b005b61025860048036036102539190810190611b93565b610c24565b60405161026793929190611fb8565b60405180910390f35b61028a60048036036102859190810190611c0b565b610d9a565b6040516102979190611f7b565b60405180910390f35b6102a8610ded565b6040516102b59190612011565b60405180910390f35b6102d860048036036102d39190810190611c0b565b610e07565b005b6102e2611060565b6040516102ef9190611f7b565b60405180910390f35b610312600480360361030d9190810190611d5e565b611077565b60405161031f9190611f96565b60405180910390f35b610342600480360361033d9190810190611db0565b611213565b604051610350929190612055565b60405180910390f35b610373600480360361036e9190810190611c0b565b6113d1565b6040516103809190611f7b565b60405180910390f35b6103a3600480360361039e9190810190611e15565b61147d565b6040516103b09190612011565b60405180910390f35b6103d360048036036103ce9190810190611c34565b6114b3565b6040516103e293929190611f0d565b60405180910390f35b61040560048036036104009190810190611c0b565b61164b565b60405161041493929190611f44565b60405180910390f35b61043760048036036104329190810190611d22565b611747565b005b610453600480360361044e9190810190611c0b565b611801565b60405161046293929190611f0d565b60405180910390f35b61048560048036036104809190810190611d87565b6118eb565b005b6000600260006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055506000600560016101000a81548163ffffffff021916908363ffffffff160217905550600560016101000a81549063ffffffff0219169055600460006104f9919061191a565b565b600061050683611077565b600960008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600001908051906020019061055b929190611942565b5081600960008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600101819055506001600a8590806001815401808255809150509060018203906000526020600020016000909192909190916101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555003600960008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600201819055506001600a805490500390509392505050565b600360008360ff1660ff16815260200190815260200160002060000160059054906101000a900460ff1661072c57600482908060018154018082558091505090600182039060005260206000209060209182820401919006909192909190916101000a81548160ff021916908360ff160217905550506001600560018282829054906101000a900463ffffffff160192506101000a81548163ffffffff021916908363ffffffff1602179055506001600560006101000a81548160ff0219169083151502179055505b60405180606001604052808360ff1681526020018263ffffffff16815260200160011515815250600360008460ff1660ff16815260200190815260200160002060008201518160000160006101000a81548160ff021916908360ff16021790555060208201518160000160016101000a81548163ffffffff021916908363ffffffff16021790555060408201518160000160056101000a81548160ff0219169083151502179055509050505050565b6040518060600160405280846fffffffffffffffffffffffffffffffff191681526020018367ffffffffffffffff1681526020018281525060076000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff021916908360801c021790555060208201518160000160106101000a81548167ffffffffffffffff021916908367ffffffffffffffff1602179055506040820151816001015590505050505050565b60405180606001604052808363ffffffff168152602001826fffffffffffffffffffffffffffffffff19168152602001600115158152506000808463ffffffff1663ffffffff16815260200190815260200160002060008201518160000160006101000a81548163ffffffff021916908363ffffffff16021790555060208201518160000160046101000a8154816fffffffffffffffffffffffffffffffff021916908360801c021790555060408201518160000160146101000a81548160ff0219169083151502179055509050505050565b60066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff1615610a47578060066000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060030160006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055505b5050565b6000806000808463ffffffff1663ffffffff16815260200190815260200160002060000160009054906101000a900463ffffffff1691506000808463ffffffff1663ffffffff16815260200190815260200160002060000160049054906101000a900460801b9050915091565b60066000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff1615610c1f576040518060600160405280836fffffffffffffffffffffffffffffffff191681526020018267ffffffffffffffff1681526020014281525060066000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff021916908360801c021790555060208201518160000160106101000a81548167ffffffffffffffff021916908367ffffffffffffffff160217905550604082015181600101559050505b505050565b6060600080600960008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600001600960008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060010154600960008773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060020154828054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610d865780601f10610d5b57610100808354040283529160200191610d86565b820191906000526020600020905b815481529060010190602001808311610d6957829003601f168201915b505050505092509250925092509193909250565b600060066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060030160009054906101000a900460070b9050919050565b6000600560019054906101000a900463ffffffff16905090565b60066000826fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff16610eb057600881908060018154018082558091505090600182039060005260206000209060029182820401919006601002909192909190916101000a8154816fffffffffffffffffffffffffffffffff021916908360801c0217905550505b6040518060c00160405280826fffffffffffffffffffffffffffffffff19168152602001600160ff168152602001600115158152602001600060070b81526020016000604051908082528060200260200182016040528015610f215781602001602082028038833980820191505090505b508152602001600060070b81525060066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060008201518160000160006101000a8154816fffffffffffffffffffffffffffffffff021916908360801c021790555060208201518160000160106101000a81548160ff021916908360ff16021790555060408201518160000160116101000a81548160ff02191690831515021790555060608201518160000160126101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff16021790555060808201518160020190805190602001906110279291906119c2565b5060a08201518160030160006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff16021790555090505050565b6000600260009054906101000a900460070b905090565b60608060206040519080825280601f01601f1916602001820160405280156110ae5781602001600182028038833980820191505090505b509050600080905060008090505b60208110156111585760008160080260020a8660001c0260001b9050600060f81b817effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff19161461114a578084848151811061111257fe5b60200101907effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916908160001a90535082806001019350505b5080806001019150506110bc565b506060816040519080825280601f01601f19166020018201604052801561118e5781602001600182028038833980820191505090505b50905060008090505b828160ff16101561120757838160ff16815181106111b157fe5b602001015160f81c60f81b828260ff16815181106111cb57fe5b60200101907effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916908160001a9053508080600101915050611197565b50809350505050919050565b6000806000808463ffffffff1663ffffffff16815260200190815260200160002060000160149054906101000a900460ff16156113cc5760008060008563ffffffff1663ffffffff16815260200190815260200160002060000160049054906101000a900460801b9050600060801b60076000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160009054906101000a900460801b6fffffffffffffffffffffffffffffffff1916146113ca57600060076000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900467ffffffffffffffff169050600060066000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900460ff1690506000600360008360ff1660ff16815260200190815260200160002060000160019054906101000a900463ffffffff169050869550828163ffffffff160294505050505b505b915091565b600060066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff16156114735760066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160129054906101000a900460070b9050611478565b600090505b919050565b6000600360008360ff1660ff16815260200190815260200160002060000160019054906101000a900463ffffffff169050919050565b600080600060066000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160009054906101000a900460801b60066000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900467ffffffffffffffff1660066000886fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001016000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff19168152602001908152602001600020600101549250925092509250925092565b600080600060066000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff161561173f578360066000866fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900460ff1660066000876fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160129054906101000a900460070b925092509250611740565b5b9193909250565b60066000836fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160119054906101000a900460ff16156117fd578060066000846fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160126101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff1602179055505b5050565b600080600060076000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160009054906101000a900460801b925060076000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff1916815260200190815260200160002060000160109054906101000a900467ffffffffffffffff16915060076000856fffffffffffffffffffffffffffffffff19166fffffffffffffffffffffffffffffffff191681526020019081526020016000206001015490509193909250565b80600260006101000a81548167ffffffffffffffff021916908360070b67ffffffffffffffff16021790555050565b50805460008255601f01602090049060005260206000209081019061193f9190611a87565b50565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061198357805160ff19168380011785556119b1565b828001600101855582156119b1579182015b828111156119b0578251825591602001919060010190611995565b5b5090506119be9190611a87565b5090565b82805482825590600052602060002090600101600290048101928215611a765791602002820160005b83821115611a3857835183826101000a8154816fffffffffffffffffffffffffffffffff021916908360801c02179055509260200192601001602081600f010492830192600103026119eb565b8015611a745782816101000a8154906fffffffffffffffffffffffffffffffff0219169055601001602081600f01049283019260010302611a38565b505b509050611a839190611aac565b5090565b611aa991905b80821115611aa5576000816000905550600101611a8d565b5090565b90565b611ae891905b80821115611ae457600081816101000a8154906fffffffffffffffffffffffffffffffff021916905550600101611ab2565b5090565b90565b600081359050611afa8161218e565b92915050565b600081359050611b0f816121a5565b92915050565b600081359050611b24816121bc565b92915050565b600081359050611b39816121d3565b92915050565b600081359050611b4e816121ea565b92915050565b600081359050611b6381612201565b92915050565b600081359050611b7881612218565b92915050565b600081359050611b8d8161222f565b92915050565b600060208284031215611ba557600080fd5b6000611bb384828501611aeb565b91505092915050565b600080600060608486031215611bd157600080fd5b6000611bdf86828701611aeb565b9350506020611bf086828701611b15565b9250506040611c0186828701611b3f565b9150509250925092565b600060208284031215611c1d57600080fd5b6000611c2b84828501611b00565b91505092915050565b60008060408385031215611c4757600080fd5b6000611c5585828601611b00565b9250506020611c6685828601611b00565b9150509250929050565b600080600060608486031215611c8557600080fd5b6000611c9386828701611b00565b9350506020611ca486828701611b00565b9250506040611cb586828701611b69565b9150509250925092565b60008060008060808587031215611cd557600080fd5b6000611ce387828801611b00565b9450506020611cf487828801611b00565b9350506040611d0587828801611b69565b9250506060611d1687828801611b3f565b91505092959194509250565b60008060408385031215611d3557600080fd5b6000611d4385828601611b00565b9250506020611d5485828601611b2a565b9150509250929050565b600060208284031215611d7057600080fd5b6000611d7e84828501611b15565b91505092915050565b600060208284031215611d9957600080fd5b6000611da784828501611b2a565b91505092915050565b600060208284031215611dc257600080fd5b6000611dd084828501611b54565b91505092915050565b60008060408385031215611dec57600080fd5b6000611dfa85828601611b54565b9250506020611e0b85828601611b00565b9150509250929050565b600060208284031215611e2757600080fd5b6000611e3584828501611b7e565b91505092915050565b60008060408385031215611e5157600080fd5b6000611e5f85828601611b7e565b9250506020611e7085828601611b54565b9150509250929050565b611e83816120ac565b82525050565b611e92816120e2565b82525050565b6000611ea38261207e565b611ead8185612089565b9350611ebd81856020860161214a565b611ec68161217d565b840191505092915050565b611eda8161210f565b82525050565b611ee981612119565b82525050565b611ef881612129565b82525050565b611f078161213d565b82525050565b6000606082019050611f226000830186611e7a565b611f2f6020830185611eef565b611f3c6040830184611ed1565b949350505050565b6000606082019050611f596000830186611e7a565b611f666020830185611efe565b611f736040830184611e89565b949350505050565b6000602082019050611f906000830184611e89565b92915050565b60006020820190508181036000830152611fb08184611e98565b905092915050565b60006060820190508181036000830152611fd28186611e98565b9050611fe16020830185611ed1565b611fee6040830184611ed1565b949350505050565b600060208201905061200b6000830184611ed1565b92915050565b60006020820190506120266000830184611ee0565b92915050565b60006040820190506120416000830185611ee0565b61204e6020830184611e7a565b9392505050565b600060408201905061206a6000830185611ee0565b6120776020830184611eef565b9392505050565b600081519050919050565b600082825260208201905092915050565b60006120a5826120ef565b9050919050565b60007fffffffffffffffffffffffffffffffff0000000000000000000000000000000082169050919050565b6000819050919050565b60008160070b9050919050565b600073ffffffffffffffffffffffffffffffffffffffff82169050919050565b6000819050919050565b600063ffffffff82169050919050565b600067ffffffffffffffff82169050919050565b600060ff82169050919050565b60005b8381101561216857808201518184015260208101905061214d565b83811115612177576000848401525b50505050565b6000601f19601f8301169050919050565b6121978161209a565b81146121a257600080fd5b50565b6121ae816120ac565b81146121b957600080fd5b50565b6121c5816120d8565b81146121d057600080fd5b50565b6121dc816120e2565b81146121e757600080fd5b50565b6121f38161210f565b81146121fe57600080fd5b50565b61220a81612119565b811461221557600080fd5b50565b61222181612129565b811461222c57600080fd5b50565b6122388161213d565b811461224357600080fd5b5056fea365627a7a723158202d885118b0bacba375afa8be22ff274c36ad3b09de283a0f83ed4928ff0d899b6c6578706572696d656e74616cf564736f6c634300050b0040";


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
