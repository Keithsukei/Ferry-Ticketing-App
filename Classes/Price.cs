using Ferry_Ticketing_App.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Price
    {
        public decimal BasePrice { get; set; }
        public decimal ServiceCharge { get; set; }


        public Price(decimal basePrice, decimal serviceCharge)
        {
            BasePrice = basePrice;
            ServiceCharge = serviceCharge;
        }

        public decimal CalculateFinalPrice()
        {

            return BasePrice + ServiceCharge;
        }
    }
}
