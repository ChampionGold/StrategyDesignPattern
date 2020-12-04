using StrategyPattern.Models.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Models
{
    public class Order
    {
        public ShippingDetails shippingDetails { get; set; }
        public List<Item> Items { get; set; }

        private ISalesTaxStrategy _taxcontext;

        //public Order(ISalesTaxStrategy context)
        //{
        //    _taxcontext = context;
        //}

        public void SetContext(ISalesTaxStrategy taxcontext)
        {
            this._taxcontext = taxcontext;
        }

        public decimal TotalPrice() {
            decimal total = 0m;
            foreach (Item item in Items)
            {
                total += item.Price;
            }
            return total;
        }

        public decimal GetTax()
        {
            if(_taxcontext == null) { return 0m; }
            return _taxcontext.GetTaxFor(this);
        }


    }
}
