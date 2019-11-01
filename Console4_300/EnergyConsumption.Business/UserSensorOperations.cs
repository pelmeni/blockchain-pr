

using Common;
using Dapper;
using EnergyConsumption.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyConsumption.Business
{
    public class UserSensorOperations:BaseDapperConnection
    {
        public UserSensorOperations(IDapperConnectionStringProvider provider) : base(provider)
        {
        }
        public UserSensor AddOne(Guid userId, string sensorText)
        {
            var sensorId = Guid.NewGuid();

            var userSensor = new UserSensor()
            {
                UserId = userId,
                SensorId = sensorId,
                SensorText=sensorText
                
            };

            Execute(
                (db) =>
                    db.Execute("insert into dbo.[UserSensor] (SensorId, UserId, SensorText) values(@SensorId, @UserId, @SensorText)", userSensor));

            var created = ExecuteQuery(db =>
                    db.Query<UserSensor>("select * from dbo.[UserSensor] (nolock) where SensorId=@SensorId and UserId=@UserId",
                        userSensor))?.FirstOrDefault();

            return created;

        }
        public IEnumerable<UserSensor> GetList(Guid userId)
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<UserSensor>("select * from dbo.[UserSensor] (nolock) where UserId=@userId",
                            new { userId }))?.ToArray();
        }

        public IEnumerable<UserSensor> GetList()
        {
            return ExecuteQuery(db =>db.Query<UserSensor>("select * from dbo.[UserSensor] (nolock)"))?.ToArray();
        }
        public SensorData GetLastCounters(Guid sensorId)
        {
            return ExecuteQuery(db => db.Query<SensorData>("select SensorId, SensorDataId, lastCountersValue Value, lastCountersDateTime Created from dbo.[vw_UserSensors] (nolock) where SensorId=@sensorId", new { sensorId }))?.FirstOrDefault();
        }
        public void UpdateUserSensorText(Guid userId, string sensorText)
        {
            Execute(
                (db) =>
                    db.Execute("update dbo.[UserSensor] set SensorText=@sensorText where UserId=@userId", new { userId, sensorText }));

        }

        public void Delete(int userSensorId)
        {
            Execute(
                (db) =>
                    db.Execute("delete from dbo.[UserSensor] where UserSensorId=@userSensorId",new { userSensorId}));

        }

        public UserSensor GetOne(Guid sensorId, Guid userId)
        {
            return ExecuteQuery(db =>
                               db.Query<UserSensor>("select * from dbo.[UserSensor] (nolock) where SensorId=@sensorId and UserId=@userId",
                                   new {sensorId, userId }))?.FirstOrDefault();
        }


        public void GeneratePowerConsumptionCycle()
        {
            Execute((db) =>db.Execute("dbo.sp_generate_sensor_power_consumption_values"));
        }


        public long GetSensorDataCheckSum()
        {
            return GetTableChecksum("SensorData");
        }
        public long GetSensorCheckSum()
        {
            return GetTableChecksum("Sensor");
        }
        public long GetUserSensorCheckSum()
        {
            return GetTableChecksum("UserSensor");
        }
        public long GetSensorRowChecksum(Guid sensorId)
        {
            return ExecuteQuery(db => {
                var r = db.Query<long?>($"select CHECKSUM(*) chksum from dbo.UserSensor (nolock) where SensorId=@sensorId", new { sensorId });
                return r;
            })?.FirstOrDefault() ?? 0;
        }

    }

}
