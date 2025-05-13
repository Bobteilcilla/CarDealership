using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain
{
    public class Car
    {
        public string Make { get; }
        public string Model { get; }
        public int Year { get; }
        public decimal Price { get; }

        public Car(string make, string model, int year, decimal price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;

        }
        public void DisplayInfo(int index)
        {
            Console.WriteLine($"{index}. {Year} {Make} {Model} - ${Price}");
        }

    }
}