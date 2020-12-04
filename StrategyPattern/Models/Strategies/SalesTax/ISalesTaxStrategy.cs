using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Models.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);

    }
}
