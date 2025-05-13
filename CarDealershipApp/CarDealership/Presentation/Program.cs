using CarDealership.Application;
using CarDealership.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Presentation
{
    class Program
    {
        static void Main()
        {
            Dealership dealership = new Dealership();

            do
            {
                Console.WriteLine("\n--- Car Dealership Managment ---");
                Console.WriteLine("1. Add Car to inventory");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Remove Car from Inventory");
                Console.WriteLine("4. Add Customer");
                Console.WriteLine("5. Sell Car to a Customer");
                Console.WriteLine("6. Show total Cars Sold");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Choose an option:");

                string? choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.Clear();
                        AddCar(dealership);
                        break;
                    case "2":
                        Console.Clear();
                        dealership.ShowInventory();
                        break;
                    case "3":
                        Console.Clear();
                        RemoveCar(dealership);
                        break;
                    case "4":
                        Console.Clear();
                        AddCustomer(dealership);
                        break;
                    case "5":
                        Console.Clear();
                        SellCar(dealership);
                        break;
                    case "6":
                        Console.Clear();
                        dealership.ShowSalesHistory();
                        break;
                    case "7":
                        Console.WriteLine("Exiting... ");
                        return;
                    default:
                        Console.WriteLine("That was an invalid option. Please try again");
                        break;

                }
           
            } while (true);

        }
        private static void SellCar(Dealership dealership)
        {

            string? indexText, customerOption, customerName, customerBudgetText, customerIndexText;
            bool isValidNumber;
            int indexCar, indexCustomer;
            decimal budget;

            Console.WriteLine("Here is the inventory of cars");
            do
            {
                Console.WriteLine("Please introduce the index: ");
                indexText = Console.ReadLine();
                isValidNumber = int.TryParse(indexText, out indexCar);

            } while (isValidNumber == false);
            
            if( indexCar >= dealership.CountInventory())
            {
                Console.WriteLine("The car index doesnt exist");
                return;
            }
            do
            {
                Customer customer;
                Console.WriteLine("Is this a new customer? (Y/N) :");
                customerOption = Console.ReadLine();

                    switch (customerOption)
                    {
                        case "Y":
                        case "y":
                            Console.WriteLine("We will create the new customer now:");
                            do
                            {
                                Console.WriteLine("Please enter the customers name: ");
                                customerName = Console.ReadLine();

                            } while (string.IsNullOrWhiteSpace(customerName));
                            do
                            {
                                Console.WriteLine("Please enter the customers budget: ");
                                customerBudgetText = Console.ReadLine();
                                isValidNumber = decimal.TryParse(customerBudgetText, out budget);

                            } while (isValidNumber == false);

                            customer = new Customer(customerName, budget);
                            dealership.AddCustomer(customer);
                            dealership.SellCar(indexCar, customer);

                            break;
                        case "N":
                        case "n":

                            do
                            {
                                Console.WriteLine("Please let me know the index of the customer:");
                                dealership.ShowCustomersList();
                                Console.WriteLine();
                                
                                customerIndexText = Console.ReadLine();
                                isValidNumber = int.TryParse(customerIndexText, out indexCustomer);

                            } while (isValidNumber == false);

                             customer = dealership.RetrieveCustomer(indexCustomer);
                             if (customer == null)
                                {
                                    Console.WriteLine("Error retrieving the customer. Please try again");
                                }
                            else
                                dealership.SellCar(indexCar, customer);
                            
                            break;

                        default:
                            Console.WriteLine("You chose the wrong option. Please try again");
                            break;
                    }

            } while (customerOption != "Y" && customerOption != "y" && customerOption != "n" && customerOption != "N");
        }
        private static void AddCustomer(Dealership dealership)
        {
            string? nameText, budgetText;
            decimal budget;
            bool isValidNumber;

            Console.WriteLine("Please give me the following information to create the customer:");
            do
            {
                Console.WriteLine("Customer Name:");
                nameText = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(nameText));
            do
            {
                Console.WriteLine("Budget of the customer:");
                budgetText = Console.ReadLine();
                isValidNumber = decimal.TryParse(budgetText, out budget);

            } while (isValidNumber == false);

            Customer customer = new Customer(nameText, budget);
            dealership.AddCustomer(customer);
            Console.WriteLine("The customer has beed succesfully added to the Customers List");
        }
        private static void RemoveCar(Dealership dealership)
        {
            if (dealership.CountInventory() == 0)
            {
                Console.WriteLine("The inventory is empty");
                return;
            }
            bool isValidNumber;
            int result;
            Console.WriteLine("Hier is the inventory");
            dealership.ShowInventory();

            Console.WriteLine();
            do
            {
                Console.WriteLine("Enter Car Index to remove");
                string? carIndexText = Console.ReadLine();
                isValidNumber = int.TryParse(carIndexText, out result);

            } while (isValidNumber == false);

            dealership.RemoveCar(result);
            
        }
        private static void AddCar(Dealership dealership)    
        {
            string? makeText, modelText, yearText, priceText;
            int year;
            decimal price;
            bool isValidNumber;

            Console.WriteLine("Please give me the following information to create the car:");
            do
            {
                Console.WriteLine("Make of the car:");
                makeText = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(makeText));
            do
            {
                Console.WriteLine("Model of the car:");
                modelText = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(modelText));
            do
            {
                Console.WriteLine("Year of the car:");
                yearText = Console.ReadLine();
                isValidNumber = int.TryParse(yearText, out year);

            } while (isValidNumber == false);
            do
            {
                Console.WriteLine("Price of the car:");
                priceText = Console.ReadLine();
                isValidNumber = decimal.TryParse(priceText, out price);

            } while (isValidNumber == false);

            Car car = new Car(makeText, modelText, year, price);
            dealership.AddCar(car);
            Console.WriteLine();
            Console.WriteLine("Car added to the Inventory");
                
        }
    }
}
