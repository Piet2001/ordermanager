using Microsoft.AspNetCore.Mvc;
using Ordermanager_Logic;
using Ordermanager_Logic.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ordermanager_Logic.Interfaces;
using View.Models;

namespace View.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderCollection _orderCollection;
        private readonly ProductCollection _productCollection;
        private readonly CustomerCollection _customerCollection;


        public OrdersController(IOrderProvider order, IProductProvider product, ICustomerProvider customer)
        {
            _orderCollection = new OrderCollection(order);
            _productCollection = new ProductCollection(product);
            _customerCollection = new CustomerCollection(customer);
        }

        // GET: OrdersController
        public ActionResult Index()
        {
            IReadOnlyCollection<Order> orders = _orderCollection.GetAllOrders();
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
                    Amount = order.Amount,
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
                Order order = _orderCollection.GetOrderById(id);
                orderview.OrderNr = order.OrderNumber;
                orderview.OrderDate = order.OrderDate;
                orderview.DeliveryDate = order.DeliveryDate;
                orderview.Customer = order.Customer.Name;
                orderview.CustomerAdress = order.Customer.Adress;
                orderview.Product = order.Product.Name;
                orderview.ProductPrice = order.Product.Price;
                orderview.Amount = order.Amount;
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
            model.Products = _productCollection.GetAllProducts();
            model.Customers = _customerCollection.GetAllCustomers();
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
                    _productCollection.GetProductById(model.Product),
                    model.Amount,
                    model.OrderDate,
                    model.DeliveryDate,
                    _customerCollection.GetCustomerById(model.Customer),
                    model.Status
                    );

                _orderCollection.AddOrder(order);
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
            Order order = _orderCollection.GetOrderById(id);
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
                _orderCollection.UpdateStatus(update.Id, update.Status);
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
            IReadOnlyCollection<Order> orders = _orderCollection.GetOnStatus(id);
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
                    Amount = order.Amount,
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
