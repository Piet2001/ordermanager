using System;
using Microsoft.AspNetCore.Mvc;
using Ordermanager_Logic.Collections;
using Ordermanager_Logic.Dto;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using View.Models;

namespace View.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderCollection orderCollection = new OrderCollection(new Ordermanager_DAL.OrderDal());
        private readonly ProductCollection productCollection = new ProductCollection(new Ordermanager_DAL.ProductDal());


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
            OrderViewModel orderview = new OrderViewModel();
            try
            {
                OrderDto order = orderCollection.GetOrderById(id);
                orderview.OrderNr = order.OrderNr;
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
            OrderCreateModel model = new OrderCreateModel {Products = productCollection.GetAllProducts()};
            return View(model);
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreateModel model)
        {
            try
            {
                CreateDto dto = new CreateDto();
                {
                    dto.OrderNr = model.OrderNr;
                    dto.Product = model.Product;
                    dto.OrderDate = model.OrderDate;
                    dto.DeliveryDate = model.DeliveryDate;
                    dto.Customer = model.Customer;
                    dto.Status = model.Status;
                }
                
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
