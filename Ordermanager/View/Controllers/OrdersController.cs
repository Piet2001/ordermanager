using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordermanager_Logic.Collections;
using Ordermanager_Logic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using View.Models;

namespace View.Controllers
{
    public class OrdersController : Controller
    {
        OrderCollection orderCollection = new OrderCollection(new Ordermanager_DAL.OrderDal());

        // GET: OrdersController
        public ActionResult Index()
        {
            IReadOnlyCollection<OrderDto> orders = orderCollection.GetAllOrders();
            List<OrderViewModel> orderModel = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                OrderViewModel input = new OrderViewModel()
                {
                    OrderNr = order.OrderNr,
                    Product = order.Product,
                    OrderDate = order.OrderDate,
                    DeliveryDate = order.DeliveryDate,
                    Customer = order.Customer,
                    Status = order.Status
                };
                orderModel.Add(input);
            }
            return View(orderModel);
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
