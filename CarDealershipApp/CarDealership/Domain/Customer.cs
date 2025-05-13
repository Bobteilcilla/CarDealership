using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Domain
{
     public class Customer
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
    
        public Customer(string name, decimal budget)
        {
            Name = name;
            Budget = budget;
        }
        public void DisplayInfo(int index)
        {
            Console.WriteLine($"{index}. Customer Name: {Name} Budget: {Budget}");
        }
    }
}
