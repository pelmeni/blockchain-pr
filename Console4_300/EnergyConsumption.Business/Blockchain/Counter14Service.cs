using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;

namespace EnergyConsumption.Business.Blockchain
{

    public partial class Counter14Service
    {
        public static Task DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, Counter14Deployment counter14Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<Counter14Deployment>().SendRequestAndWaitForReceiptAsync(counter14Deployment, cancellationTokenSource.Token);
        }

        public static Task DeployContractAsync(Nethereum.Web3.Web3 web3, Counter14Deployment counter14Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<Counter14Deployment>().SendRequestAsync(counter14Deployment);
        }

        public static async Task DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, Counter14Deployment counter14Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            Task<dynamic> task = await DeployContractAndWaitForReceiptAsync(web3, counter14Deployment, cancellationTokenSource);
            var receipt = task;
            return new Counter14Service(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public Counter14Service(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task EmptyTariffZoneChkSumRequestAsync(EmptyTariffZoneChkSumFunction emptyTariffZoneChkSumFunction)
        {
            return ContractHandler.SendRequestAsync(emptyTariffZoneChkSumFunction);
        }

        public Task EmptyTariffZoneChkSumRequestAsync()
        {
            return ContractHandler.SendRequestAsync();
        }

        public Task EmptyTariffZoneChkSumRequestAndWaitForReceiptAsync(EmptyTariffZoneChkSumFunction emptyTariffZoneChkSumFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(emptyTariffZoneChkSumFunction, cancellationToken);
        }

        public Task EmptyTariffZoneChkSumRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(null, cancellationToken);
        }

        public Task InsertUserRequestAsync(InsertUserFunction insertUserFunction)
        {
            return ContractHandler.SendRequestAsync(insertUserFunction);
        }

        public Task InsertUserRequestAndWaitForReceiptAsync(InsertUserFunction insertUserFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(insertUserFunction, cancellationToken);
        }

        public Task InsertUserRequestAsync(string userAddress, byte[] email, BigInteger age)
        {
            var insertUserFunction = new InsertUserFunction();
            insertUserFunction.UserAddress = userAddress;
            insertUserFunction.Email = email;
            insertUserFunction.Age = age;

            return ContractHandler.SendRequestAsync(insertUserFunction);
        }

        public Task InsertUserRequestAndWaitForReceiptAsync(string userAddress, byte[] email, BigInteger age, CancellationTokenSource cancellationToken = null)
        {
            var insertUserFunction = new InsertUserFunction();
            insertUserFunction.UserAddress = userAddress;
            insertUserFunction.Email = email;
            insertUserFunction.Age = age;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(insertUserFunction, cancellationToken);
        }

        public Task LoadTariffZoneRequestAsync(LoadTariffZoneFunction loadTariffZoneFunction)
        {
            return ContractHandler.SendRequestAsync(loadTariffZoneFunction);
        }

        public Task LoadTariffZoneRequestAndWaitForReceiptAsync(LoadTariffZoneFunction loadTariffZoneFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(loadTariffZoneFunction, cancellationToken);
        }

        public Task LoadTariffZoneRequestAsync(byte zone_id, uint rate_per_1000)
        {
            var loadTariffZoneFunction = new LoadTariffZoneFunction();
            loadTariffZoneFunction.Zone_id = zone_id;
            loadTariffZoneFunction.Rate_per_1000 = rate_per_1000;

            return ContractHandler.SendRequestAsync(loadTariffZoneFunction);
        }

        public Task LoadTariffZoneRequestAndWaitForReceiptAsync(byte zone_id, uint rate_per_1000, CancellationTokenSource cancellationToken = null)
        {
            var loadTariffZoneFunction = new LoadTariffZoneFunction();
            loadTariffZoneFunction.Zone_id = zone_id;
            loadTariffZoneFunction.Rate_per_1000 = rate_per_1000;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(loadTariffZoneFunction, cancellationToken);
        }

        public Task SetSensorHashRequestAsync(SetSensorHashFunction setSensorHashFunction)
        {
            return ContractHandler.SendRequestAsync(setSensorHashFunction);
        }

        public Task SetSensorHashRequestAndWaitForReceiptAsync(SetSensorHashFunction setSensorHashFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setSensorHashFunction, cancellationToken);
        }

        public Task SetSensorHashRequestAsync(byte[] sensorId, long hash)
        {
            var setSensorHashFunction = new SetSensorHashFunction();
            setSensorHashFunction.SensorId = sensorId;
            setSensorHashFunction.Hash = hash;

            return ContractHandler.SendRequestAsync(setSensorHashFunction);
        }

        public Task SetSensorHashRequestAndWaitForReceiptAsync(byte[] sensorId, long hash, CancellationTokenSource cancellationToken = null)
        {
            var setSensorHashFunction = new SetSensorHashFunction();
            setSensorHashFunction.SensorId = sensorId;
            setSensorHashFunction.Hash = hash;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setSensorHashFunction, cancellationToken);
        }

        public Task IncrementCounterRequestAsync(IncrementCounterFunction incrementCounterFunction)
        {
            return ContractHandler.SendRequestAsync(incrementCounterFunction);
        }

        public Task IncrementCounterRequestAsync()
        {
            return ContractHandler.SendRequestAsync();
        }

        public Task IncrementCounterRequestAndWaitForReceiptAsync(IncrementCounterFunction incrementCounterFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementCounterFunction, cancellationToken);
        }

        public Task IncrementCounterRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(null, cancellationToken);
        }

        public Task InsertSensorDataRequestAsync(InsertSensorDataFunction insertSensorDataFunction)
        {
            return ContractHandler.SendRequestAsync(insertSensorDataFunction);
        }

        public Task InsertSensorDataRequestAndWaitForReceiptAsync(InsertSensorDataFunction insertSensorDataFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(insertSensorDataFunction, cancellationToken);
        }

        public Task InsertSensorDataRequestAsync(byte[] sensorId, byte[] sensorDataId, ulong counter)
        {
            var insertSensorDataFunction = new InsertSensorDataFunction();
            insertSensorDataFunction.SensorId = sensorId;
            insertSensorDataFunction.SensorDataId = sensorDataId;
            insertSensorDataFunction.Counter = counter;

            return ContractHandler.SendRequestAsync(insertSensorDataFunction);
        }

        public Task InsertSensorDataRequestAndWaitForReceiptAsync(byte[] sensorId, byte[] sensorDataId, ulong counter, CancellationTokenSource cancellationToken = null)
        {
            var insertSensorDataFunction = new InsertSensorDataFunction();
            insertSensorDataFunction.SensorId = sensorId;
            insertSensorDataFunction.SensorDataId = sensorDataId;
            insertSensorDataFunction.Counter = counter;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(insertSensorDataFunction, cancellationToken);
        }

        public Task GetUserQueryAsync(GetUserFunction getUserFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync(getUserFunction, blockParameter);
        }

        public Task GetUserQueryAsync(string userAddress, BlockParameter blockParameter = null)
        {
            var getUserFunction = new GetUserFunction();
            getUserFunction.UserAddress = userAddress;

            return ContractHandler.QueryDeserializingToObjectAsync(getUserFunction, blockParameter);
        }

        public Task GetSensorHashQueryAsync(GetSensorHashFunction getSensorHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(getSensorHashFunction, blockParameter);
        }


        public Task GetSensorHashQueryAsync(byte[] sensorId, BlockParameter blockParameter = null)
        {
            var getSensorHashFunction = new GetSensorHashFunction();
            getSensorHashFunction.SensorId = sensorId;

            return ContractHandler.QueryAsync(getSensorHashFunction, blockParameter);
        }

        public Task GetTariffZonesQueryAsync(GetTariffZonesFunction getTariffZonesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(getTariffZonesFunction, blockParameter);
        }


        public Task GetTariffZonesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(null, blockParameter);
        }

        public Task InsertSensorRequestAsync(InsertSensorFunction insertSensorFunction)
        {
            return ContractHandler.SendRequestAsync(insertSensorFunction);
        }

        public Task InsertSensorRequestAndWaitForReceiptAsync(InsertSensorFunction insertSensorFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(insertSensorFunction, cancellationToken);
        }

        public Task InsertSensorRequestAsync(byte[] sensorId)
        {
            var insertSensorFunction = new InsertSensorFunction();
            insertSensorFunction.SensorId = sensorId;

            return ContractHandler.SendRequestAsync(insertSensorFunction);
        }

        public Task InsertSensorRequestAndWaitForReceiptAsync(byte[] sensorId, CancellationTokenSource cancellationToken = null)
        {
            var insertSensorFunction = new InsertSensorFunction();
            insertSensorFunction.SensorId = sensorId;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(insertSensorFunction, cancellationToken);
        }

        public Task GetTariffZoneChkSumQueryAsync(GetTariffZoneChkSumFunction getTariffZoneChkSumFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(getTariffZoneChkSumFunction, blockParameter);
        }


        public Task GetTariffZoneChkSumQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(null, blockParameter);
        }

        public Task Bytes32ToStringRequestAsync(Bytes32ToStringFunction bytes32ToStringFunction)
        {
            return ContractHandler.SendRequestAsync(bytes32ToStringFunction);
        }

        public Task Bytes32ToStringRequestAndWaitForReceiptAsync(Bytes32ToStringFunction bytes32ToStringFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(bytes32ToStringFunction, cancellationToken);
        }

        public Task Bytes32ToStringRequestAsync(byte[] x)
        {
            var bytes32ToStringFunction = new Bytes32ToStringFunction();
            bytes32ToStringFunction.X = x;

            return ContractHandler.SendRequestAsync(bytes32ToStringFunction);
        }

        public Task Bytes32ToStringRequestAndWaitForReceiptAsync(byte[] x, CancellationTokenSource cancellationToken = null)
        {
            var bytes32ToStringFunction = new Bytes32ToStringFunction();
            bytes32ToStringFunction.X = x;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(bytes32ToStringFunction, cancellationToken);
        }

        public Task GetCountQueryAsync(GetCountFunction getCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(getCountFunction, blockParameter);
        }


        public Task GetCountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(null, blockParameter);
        }

        public Task GetSensorDataHashQueryAsync(GetSensorDataHashFunction getSensorDataHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(getSensorDataHashFunction, blockParameter);
        }


        public Task GetSensorDataHashQueryAsync(byte[] sensorId, BlockParameter blockParameter = null)
        {
            var getSensorDataHashFunction = new GetSensorDataHashFunction();
            getSensorDataHashFunction.SensorId = sensorId;

            return ContractHandler.QueryAsync(getSensorDataHashFunction, blockParameter);
        }

        public Task GetTariffZoneByZoneIdQueryAsync(GetTariffZoneByZoneIdFunction getTariffZoneByZoneIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync(getTariffZoneByZoneIdFunction, blockParameter);
        }


        public Task GetTariffZoneByZoneIdQueryAsync(byte zone_id, BlockParameter blockParameter = null)
        {
            var getTariffZoneByZoneIdFunction = new GetTariffZoneByZoneIdFunction();
            getTariffZoneByZoneIdFunction.Zone_id = zone_id;

            return ContractHandler.QueryAsync(getTariffZoneByZoneIdFunction, blockParameter);
        }

        public Task GetSensorDataQueryAsync(GetSensorDataFunction getSensorDataFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync(getSensorDataFunction, blockParameter);
        }

        public Task GetSensorDataQueryAsync(byte[] sensorId, byte[] sensorDataId, BlockParameter blockParameter = null)
        {
            var getSensorDataFunction = new GetSensorDataFunction();
            getSensorDataFunction.SensorId = sensorId;
            getSensorDataFunction.SensorDataId = sensorDataId;

            return ContractHandler.QueryDeserializingToObjectAsync(getSensorDataFunction, blockParameter);
        }

        public Task GetSensorQueryAsync(GetSensorFunction getSensorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync(getSensorFunction, blockParameter);
        }

        public Task GetSensorQueryAsync(byte[] sensorId, BlockParameter blockParameter = null)
        {
            var getSensorFunction = new GetSensorFunction();
            getSensorFunction.SensorId = sensorId;

            return ContractHandler.QueryDeserializingToObjectAsync(getSensorFunction, blockParameter);
        }

        public Task SetSensorDataHashRequestAsync(SetSensorDataHashFunction setSensorDataHashFunction)
        {
            return ContractHandler.SendRequestAsync(setSensorDataHashFunction);
        }

        public Task SetSensorDataHashRequestAndWaitForReceiptAsync(SetSensorDataHashFunction setSensorDataHashFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setSensorDataHashFunction, cancellationToken);
        }

        public Task SetSensorDataHashRequestAsync(byte[] sensorId, long hash)
        {
            var setSensorDataHashFunction = new SetSensorDataHashFunction();
            setSensorDataHashFunction.SensorId = sensorId;
            setSensorDataHashFunction.Hash = hash;

            return ContractHandler.SendRequestAsync(setSensorDataHashFunction);
        }

        public Task SetSensorDataHashRequestAndWaitForReceiptAsync(byte[] sensorId, long hash, CancellationTokenSource cancellationToken = null)
        {
            var setSensorDataHashFunction = new SetSensorDataHashFunction();
            setSensorDataHashFunction.SensorId = sensorId;
            setSensorDataHashFunction.Hash = hash;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setSensorDataHashFunction, cancellationToken);
        }

        public Task SetTariffZoneChkSumRequestAsync(SetTariffZoneChkSumFunction setTariffZoneChkSumFunction)
        {
            return ContractHandler.SendRequestAsync(setTariffZoneChkSumFunction);
        }

        public Task SetTariffZoneChkSumRequestAndWaitForReceiptAsync(SetTariffZoneChkSumFunction setTariffZoneChkSumFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setTariffZoneChkSumFunction, cancellationToken);
        }

        public Task SetTariffZoneChkSumRequestAsync(long chksum)
        {
            var setTariffZoneChkSumFunction = new SetTariffZoneChkSumFunction();
            setTariffZoneChkSumFunction.Chksum = chksum;

            return ContractHandler.SendRequestAsync(setTariffZoneChkSumFunction);
        }

        public Task SetTariffZoneChkSumRequestAndWaitForReceiptAsync(long chksum, CancellationTokenSource cancellationToken = null)
        {
            var setTariffZoneChkSumFunction = new SetTariffZoneChkSumFunction();
            setTariffZoneChkSumFunction.Chksum = chksum;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setTariffZoneChkSumFunction, cancellationToken);
        }

        public Task DecrementCounterRequestAsync(DecrementCounterFunction decrementCounterFunction)
        {
            return ContractHandler.SendRequestAsync(decrementCounterFunction);
        }

        public Task DecrementCounterRequestAsync()
        {
            return ContractHandler.SendRequestAsync();
        }

        public Task DecrementCounterRequestAndWaitForReceiptAsync(DecrementCounterFunction decrementCounterFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(decrementCounterFunction, cancellationToken);
        }

        public Task DecrementCounterRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(null, cancellationToken);
        }
    }

}
