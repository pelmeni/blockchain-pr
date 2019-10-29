

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
    }
}
