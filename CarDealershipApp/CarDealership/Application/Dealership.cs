using CarDealership.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Application
{
    public class Dealership
    {
        private List<Car> Inventory = new List<Car>();
        private List<Sale> SalesHistory = new List<Sale>();
        private List<Customer> CustomersList = new List<Customer>();

    public void AddCar(Car car) => Inventory.Add(car);

    public void AddCustomer(Customer customer) => CustomersList.Add(customer);
    
    public void ShowInventory()
    {
        if(Inventory.Count == 0)
        {
            Console.WriteLine("The inventory is empty");
            return;
        }
        for(int i=0; i< Inventory.Count; i++)
        {
            Inventory[i].DisplayInfo(i);
        }   
    }
    public void RemoveCar(int index)
    {
        if(index < 0 || index >= Inventory.Count)
        {
            Console.WriteLine("Invalid index");
            return;
        }
        Inventory.RemoveAt(index);
        Console.WriteLine("Car removed from the inventory");
    }
        public void SellCar(int index, Customer customer)
        {
            if (index < 0 || index >= Inventory.Count)
            {
                Console.WriteLine("Invalid Car index");
                return;
            }

            Car car = Inventory[index];
            if(customer.Budget >= car.Price)
            {
                customer.Budget -= car.Price;
                Inventory.RemoveAt(index);
            
                var sale = new Sale(car, customer, car.Price);
                SalesHistory.Add(sale);

                Console.WriteLine("Car sold successfuly");
                sale.PrintReceipt();
            }
            else
            {
                Console.WriteLine("Customer cannot afford the car");
            }

        }
        public void RemoveCustomer(int index)
        {
            if (index < 0 || index >= Inventory.Count)
            {
                Console.WriteLine("Invalid Customer index");
                return;
            }
            CustomersList.RemoveAt(index);
            Console.WriteLine("Customer removed from the CustomersList");

        }
        public void ShowSalesHistory()
        {
            if(SalesHistory.Count == 0)
            {
                Console.WriteLine("No sales");
                return;
            }
            foreach (var sale in SalesHistory)
            {
                sale.PrintReceipt();
            }        
        }
        public void ShowCustomersList()
        {
            if (CustomersList.Count == 0)
            {
                Console.WriteLine("No customers");
                return;
            }
            for (int i = 0; i < CustomersList.Count; i++)
            {
                CustomersList[i].DisplayInfo(i);
            }
        }
        public Customer RetrieveCustomer(int index)
        {
            if (index >= 0 && index < CustomersList.Count)
            {
                Customer customer = CustomersList[index];
                Console.WriteLine($"Customer at index {index}: {customer.Name}");
                return customer;
            }
            else
            {
                Console.WriteLine("Invalid Customer index");
                return null; // Ensure all code paths return a value
            }
        }
        public int CountInventory()
        {
            return Inventory.Count;
        }



    }
}
