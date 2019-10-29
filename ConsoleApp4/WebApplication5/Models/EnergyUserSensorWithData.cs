using EnergyConsumption.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5.Models
{
    public class EnergyUserSensorWithData
    {
        public int UserSensorId { get; set; }
        public Guid UserId { get; set; }
        public Guid SensorId { get; set; }
        public string SensorText { get; set; }
        public DateTime Created { get; set; }

        public IEnumerable<SensorData> SensorData { get; set; }
    }
}
