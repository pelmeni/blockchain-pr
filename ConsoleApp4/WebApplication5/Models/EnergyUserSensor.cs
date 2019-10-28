using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5.Models
{
    public class EnergyUserSensor
    {
        public int UserSensorId { get; set; }
        public Guid UserId { get; set; }
        public Guid SensorId { get; set; }
        public DateTime Created { get; set; }
    }
}
