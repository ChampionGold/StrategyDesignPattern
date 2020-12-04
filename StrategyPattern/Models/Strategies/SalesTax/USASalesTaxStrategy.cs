using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Models.Strategies.SalesTax
{
    public class USASalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            switch (order.shippingDetails.DestinationState.ToLowerInvariant())
            {
                case "ca": return order.TotalPrice() * 0.095m;
                case "ny": return order.TotalPrice() * 0.040m;
                case "tx": return order.TotalPrice() * 0.080m;
                default: return 0m;
            }
        }
    }
}
