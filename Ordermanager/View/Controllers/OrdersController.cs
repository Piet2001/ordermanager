using System;
using Microsoft.AspNetCore.Mvc;
using Ordermanager_Logic.Collections;
using Ordermanager_Logic.Dto;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using View.Models;

namespace View.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderCollection orderCollection = new OrderCollection(new Ordermanager_DAL.OrderDal());

        // GET: OrdersController
        public ActionResult Index()
        {
            IReadOnlyCollection<OrderDto> orders = orderCollection.GetAllOrders();
            if (orders.Count == 0)
            {
                throw new Exception("Geen gegevens gevonden.");
            }
            List<OrderViewModel> orderModel = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                OrderViewModel input = new OrderViewModel()
                {
                    OrderNr = order.OrderNr,
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
            OrderDto order = orderCollection.GetOrderById(id);
            OrderViewModel orderview = new OrderViewModel();
            orderview.OrderNr = order.OrderNr;
            orderview.OrderDate = order.OrderDate;
            orderview.DeliveryDate = order.DeliveryDate;
            orderview.Customer = order.Customer.Name;
            orderview.Product = order.Product.Name;
            orderview.Status = order.Status;

            if (orderview.Customer == null)
            {
                throw new DataException("Order not found");
            }

            return View(orderview);
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateDto dto)
        {
            try
            {
                orderCollection.AddOrder(dto);
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
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateDto update)
        {
            try
            {
                orderCollection.UpdateStatus(update);
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
            IReadOnlyCollection<OrderDto> orders = orderCollection.GetOnStatus(id);
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
                    OrderNr = order.OrderNr,
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
