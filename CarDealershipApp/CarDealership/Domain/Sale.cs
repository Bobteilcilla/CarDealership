using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain
{
    public class Sale
    {
        public DateTime SaleDate { get; }
        public Car CarSold { get;}
        public Customer Buyer { get; }
        public decimal SalePrice { get; }

        public Sale(Car carSold, Customer buyer, decimal salePrice)
        {
            SaleDate = DateTime.Now;
            CarSold = carSold ?? throw new ArgumentNullException(nameof(carSold));
            Buyer = buyer ?? throw new ArgumentNullException(nameof(buyer));
            SalePrice = salePrice;
        }
        public void PrintReceipt()
        {
            Console.WriteLine("--------SALE RECEIPT-------------");
            Console.WriteLine($"Date:                 {SaleDate}");
            Console.WriteLine($"Customer:           {Buyer.Name}"); 
            Console.WriteLine($"Car                 {CarSold.Year} {CarSold.Make} {CarSold.Model}");
            Console.WriteLine($"Price                {SalePrice}");
            Console.WriteLine("---------------------------------");
        }
            
    }
}
