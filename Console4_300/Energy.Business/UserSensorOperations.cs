using Common;
using Dapper;
using EnergyConsumption.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Energy.Business
{
    public class UserSensorOperations:BaseDapperConnection
    {
        public UserSensorOperations(IDapperConnectionStringProvider provider) : base(provider)
        {

        }
        public IEnumerable<UserSensor> ListSensors(Guid userId)
        {
            return
                ExecuteQuery(
                    db =>
                        db.Query<UserSensor>("select * from dbo.[UserSensor] (nolock) where UserId=@usertId",
                            new { userId }))?.ToArray();
        }
    }
}
