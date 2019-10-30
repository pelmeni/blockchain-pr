using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyConsumption.Data
{
    public class SensorData
    {
        public Guid SensorId { get; set; }
        public Guid SensorDataId { get; set; }
        public int Value { get; set; }
        public DateTime Created { get; set; }

    }
}
