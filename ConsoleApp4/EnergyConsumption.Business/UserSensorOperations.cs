

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
        //public Sensor AddOne()
        //{
        //    var data = new Sensor
        //    {
        //        SensorId = Guid.NewGuid(),
        //    };

        //    Execute(
        //        (db) =>
        //            db.Execute("insert into dbo.[Sensor] (SensorId) values(SensorId)", data));

        //    var created = ExecuteQuery(db =>
        //            db.Query<Sensor>("select * from dbo.[Sensor] (nolock) where SensorId=@SensorId",
        //                data))?.FirstOrDefault();

        //    return created;

        //}
        public IEnumerable<UserSensor> GetList(Guid userId)
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<UserSensor>("select * from dbo.[UserSensor] (nolock) where UserId=@usertId",
                            new { userId }))?.ToArray();
        }
    }
}
