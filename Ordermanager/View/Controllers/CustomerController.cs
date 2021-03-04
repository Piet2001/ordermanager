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
    public class CustomerController : Controller
    {
        private readonly CustomerCollection _customerCollection;

        public CustomerController(ICustomerProvider customer)
        {
            _customerCollection = new CustomerCollection(customer);
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            IReadOnlyCollection<Customer> customers = _customerCollection.GetAllCustomers();
            if (customers.Count == 0)
            {
                throw new Exception("Geen gegevens gevonden.");
            }
            List<CustomerViewModel> customerView = new List<CustomerViewModel>();
            foreach (var customer in customers)
            {
                CustomerViewModel input = new CustomerViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Adress = customer.Adress

                };
                customerView.Add(input);
            }
            return View(customerView);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            CustomerViewModel customerView = new CustomerViewModel();
            try
            {
                Customer customer = _customerCollection.GetCustomerById(id);
                customerView.Id = customer.Id;
                customerView.Name = customer.Name;
                customerView.Adress = customer.Adress;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw new Exception("Geen details gevonden!");
            }
            return View(customerView);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreateModel model)
        {
            try
            {
                Customer customer = new Customer
                (
                   model.Name,
                   model.Adress

                );
                _customerCollection.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = _customerCollection.GetCustomerById(id);
            CustomerUpdateModel update = new CustomerUpdateModel();
            {
                update.Id = customer.Id;
                update.Adress = customer.Adress;

            }
            return View(update);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerUpdateModel model)
        {
            try
            {
                _customerCollection.UpdateAdress(model.Id, model.Adress);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
