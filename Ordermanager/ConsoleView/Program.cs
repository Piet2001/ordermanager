using System;
using System.Collections.Concurrent;
using Ordermanager_Logic;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {

            Order order = new Order(123456, new DateTime(2020,11,9),new DateTime(2020,12,1), Status.WachtenOpOnderdelen, new Customer("Twan", "Teststraat 1, 1234AB, Teststad"), new Product("Product01", 12.36) );

            Console.WriteLine("Output: \n ");
            Console.WriteLine(order);
            Console.ReadLine();
        }
    }
}
