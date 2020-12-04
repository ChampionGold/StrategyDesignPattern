using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Models.Strategies.SalesTax
{
    public class MexicoSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var origin = order.shippingDetails.OriginCountry.ToLowerInvariant();
            var destination = order.shippingDetails.DestinationCountry.ToLowerInvariant();

            if (destination == origin)
            {
                if(order.shippingDetails.DestinationState == "bc" || order.shippingDetails.DestinationState == "ch")
                    return order.TotalPrice() * 0.08m;//iva fronterizo
                else
                    return order.TotalPrice() * 0.16m;//iva normal
            }

            return 0;
        }
    }
}
