using Common;
using Dapper;
using EnergyConsumption.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyConsumption.Business
{
    public class UserSensorDataOperations : BaseDapperConnection
    {
        public UserSensorDataOperations(IDapperConnectionStringProvider provider) : base(provider)
        {
        }
        public IEnumerable<SensorData> GetList(Guid sensorId)
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<SensorData>("select * from dbo.[SensorData] (nolock) where SensorId=@sensorId",
                            new { sensorId }))?.ToArray();
        }

        public SensorData AddOne(Guid sensorId, int value)
        {
            var data = new SensorData
            {
                SensorDataId = Guid.NewGuid(),
                SensorId = sensorId,
                Value = value
            };

            Execute(
                (db) =>
                    db.Execute("insert into dbo.[SensorData] (SensorDataId, SensorId, Value) values(SensorDataId, SensorId, Value)", data));

            var created = ExecuteQuery(db =>
                    db.Query<SensorData>("select * from dbo.[SensorData] (nolock) where SensorId=@SensorId",
                        data))?.FirstOrDefault();

            return created;

        }
    }
}
