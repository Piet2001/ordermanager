using Microsoft.AspNetCore.Mvc;
using Ordermanager_Logic;
using Ordermanager_Logic.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using View.Models;

namespace View.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderCollection orderCollection = new OrderCollection(new Ordermanager_DAL.OrderDal());
        private readonly ProductCollection productCollection = new ProductCollection(new Ordermanager_DAL.ProductDal());
        private readonly CustomerCollection customerCollection = new CustomerCollection(new Ordermanager_DAL.CustomerDal());

        // GET: OrdersController
        public ActionResult Index()
        {
            IReadOnlyCollection<Order> orders = orderCollection.GetAllOrders();
            if (orders.Count == 0)
            {
                throw new Exception("Geen gegevens gevonden.");
            }
            List<OrderViewModel> orderModel = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                OrderViewModel input = new OrderViewModel()
                {
                    OrderNr = order.OrderNumber,
                    Product = order.Product.Name,
                    OrderDate = order.OrderDate,
                    DeliveryDate = order.DeliveryDate,
                    Customer = order.Customer.Name,
                    Status = order.Status
                };
                orderModel.Add(input);
            }
            return View(orderModel);
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            OrderViewModel orderview = new OrderViewModel();
            try
            {
                Order order = orderCollection.GetOrderById(id);
                orderview.OrderNr = order.OrderNumber;
                orderview.OrderDate = order.OrderDate;
                orderview.DeliveryDate = order.DeliveryDate;
                orderview.Customer = order.Customer.Name;
                orderview.CustomerAdress = order.Customer.Adress;
                orderview.Product = order.Product.Name;
                orderview.ProductPrice = order.Product.Price;
                orderview.Status = order.Status;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw new Exception("Geen details gevonden!");
            }
            return View(orderview);
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            OrderCreateModel model = new OrderCreateModel();
            model.Products = productCollection.GetAllProducts();
            model.Customers = customerCollection.GetAllCustomers();
            return View(model);
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreateModel model)
        {
            try
            {
                Order order = new Order(
                    productCollection.GetProductById(model.Product),
                    model.OrderDate,
                    model.DeliveryDate,
                    customerCollection.GetCustomerById(model.Customer),
                    model.Status
                    );

                orderCollection.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = orderCollection.GetOrderById(id);
            OrderUpdateModel update = new OrderUpdateModel();
            {
                update.Id = order.OrderNumber;
                update.Status = order.Status;

            }
            return View(update);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderUpdateModel update)
        {
            try
            {
                orderCollection.UpdateStatus(update.Id, update.Status);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: OrdersController/Status/5
        public ActionResult Status(int id)
        {
            IReadOnlyCollection<Order> orders = orderCollection.GetOnStatus(id);
            if (id > 0 && id < 6)
            {
                ViewBag.Message = "Status " + id + "(" + orders.Count + ")";
            }
            else
            {
                ViewBag.Message = "Onbekende Status" + "(" + orders.Count + ")";
            }

            List<OrderViewModel> orderModel = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                OrderViewModel input = new OrderViewModel()
                {
                    OrderNr = order.OrderNumber,
                    Product = order.Product.Name,
                    OrderDate = order.OrderDate,
                    DeliveryDate = order.DeliveryDate,
                    Customer = order.Customer.Name,
                    Status = order.Status
                };
                orderModel.Add(input);
            }
            return View(orderModel);
        }
    }
}
