using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Models
{
    public class ShippingDetails
    {
        public string OriginCountry { get; set; }
        public string OriginState { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationState { get; set; }
    }
}
