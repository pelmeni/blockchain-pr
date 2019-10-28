using System;

namespace WebApplication5.Models
{
    public class EnergySensor
    {
        public Guid SensorId { get; set; }
        public string SensorText { get; set; }
        public DateTime Created { get; set; }
    }
}
