using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyConsumption.Data
{
    public class TariffZone
    {
        public int TariffZoneId { get; set; }
        public int RatePer1000 { get; set; }
        public DateTime Created { get; set; }
    }
}
