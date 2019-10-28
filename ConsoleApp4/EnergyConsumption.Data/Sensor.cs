using System;

namespace EnergyConsumption.Data
{
    public class Sensor
    {
        public Guid SensorId { get; set; }
        public string SensorText { get; set; }
        public DateTime Created { get; set; }
    }
}
