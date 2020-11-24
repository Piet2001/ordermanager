using System;
using System.Collections.Generic;
using Ordermanager_DAL;
using Ordermanager_Logic;
using Ordermanager_Logic.Dto;

namespace ConsoleView
{
    static class Program
    {
        static void Main(string[] args)
        {
            OrderDal dal = new OrderDal();
            IReadOnlyCollection<OrderDto> orders = dal.GetAllOrders();

            Console.WriteLine("Output: \n ");

            foreach (var orderDto in orders)
            {
                Order order = new Order(orderDto);
                Console.WriteLine(order);
            }
            Console.ReadLine();
        }
    }
}
