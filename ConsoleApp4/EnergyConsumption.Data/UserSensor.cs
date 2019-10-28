using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyConsumption.Data
{
    public class UserSensor
    {
        public int UserSensorId { get; set; }
        public Guid UserId { get; set; }
        public Guid SensorId { get; set; }
        public DateTime Created { get; set; }
    }
}
