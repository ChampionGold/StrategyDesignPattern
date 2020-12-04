using StrategyPattern.Models;
using StrategyPattern.Models.Strategies.SalesTax;
using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Order mexicoOrder = MexicoTest();
            SetSalexTaxStrategy(ref mexicoOrder);
            ProcessOrder(mexicoOrder);
            
            //Change 4/Dec/20 Testing usa taxes
            Order usaOrder = USATest();
            SetSalexTaxStrategy(ref usaOrder);
            ProcessOrder(usaOrder);

        }

        public static void ProcessOrder(Order order)
        {

            Console.WriteLine("This is the invoice for the following order");
            Console.WriteLine("Origin {0},{1}", order.shippingDetails.OriginState, order.shippingDetails.OriginCountry);
            Console.WriteLine("Destination {0},{1}", order.shippingDetails.DestinationState, order.shippingDetails.DestinationCountry);
            Console.WriteLine("The following products are listed for this order:");

            foreach (Item item in order.Items)
            {
                Console.WriteLine("Item : " + item.Name + ", Price : $" + item.Price);
            }
            Console.WriteLine("Total before taxes : $" + order.TotalPrice().ToString("N2"));
            Console.WriteLine("Taxes : $" + order.GetTax().ToString("N2"));

            decimal totalfinal = order.GetTax() + order.TotalPrice();

            Console.WriteLine("Final Total : $" + totalfinal.ToString("N2"));


            Console.ReadKey();
        }

        public static void SetSalexTaxStrategy(ref Order order)
        {
            string invoiceCountry = order.shippingDetails.DestinationCountry.ToLowerInvariant();
            if (invoiceCountry == "mexico")
            {
                order.SetContext(new MexicoSalesTaxStrategy());
            }
            else if(invoiceCountry == "usa")
            {
                order.SetContext(new USASalesTaxStrategy());
            }
        }

        public static Order MexicoTest()
        {
            Order order = new Order {
                shippingDetails = new ShippingDetails
                {
                    OriginCountry = "Mexico",
                    OriginState = "NL",
                    DestinationCountry = "Mexico",
                    DestinationState = "BC"
                }
            };

            order.Items = new List<Item>();
            order.Items.Add(new Item { Name = "Cheetos Puff", Price = 12.00m });
            order.Items.Add(new Item { Name = "Botella de 500ml Cerveza Indio", Price = 19.50m });
            return order;
        }

        public static Order USATest()
        {
            Order order = new Order
            {
                shippingDetails = new ShippingDetails
                {
                    OriginCountry = "USA",
                    OriginState = "CA",
                    DestinationCountry = "USA",
                    DestinationState = "TX"
                }
            };

            order.Items = new List<Item>();
            order.Items.Add(new Item { Name = "Doritos Pizzerolla", Price = 0.75m });
            order.Items.Add(new Item { Name = "A can of Bud Light Beer", Price = 1.50m });
            
            return order;
        }

    }
}
    

