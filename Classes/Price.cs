using Ferry_Ticketing_App.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    public class Price
    {
        protected decimal _basePrice;
        protected decimal _serviceCharge;
        
        public virtual decimal BasePrice 
        { 
            get => _basePrice;
            protected set => _basePrice = value;
        }
        
        public virtual decimal ServiceCharge
        {
            get => _serviceCharge;
            protected set => _serviceCharge = value;
        }

        public Price(decimal basePrice, decimal serviceCharge)
        {
            _basePrice = basePrice;
            _serviceCharge = serviceCharge;
        }
            
        public virtual decimal ApplyDiscount(string passengerType, int age)
        {
            decimal discountedPrice = _basePrice;

            switch (passengerType.ToLower())
            {
                case "student":
                    discountedPrice *= 0.85m; // 15% discount
                    break;
                case "senior citizen":
                    if (age >= 60)
                        discountedPrice *= 0.80m; // 20% discount
                    break;
                case "pwd":
                    discountedPrice *= 0.80m; // 20% discount
                    break;
                case "child":
                    if (age <= 2)
                        discountedPrice = 0; // Free
                    else if (age <= 11)
                        discountedPrice *= 0.50m; // 50% discount
                    break;
                case "adult":
                default:
                    break; // Regular price
            }

            return discountedPrice;
        }

        public virtual decimal CalculateFinalPrice()
        {
            return _basePrice + _serviceCharge;
        }
    }
}
