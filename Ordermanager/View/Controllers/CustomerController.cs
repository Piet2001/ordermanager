using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ordermanager_Logic.Collections;
using Ordermanager_Logic.Dto;
using View.Models;

namespace View.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerCollection customerCollection = new CustomerCollection(new Ordermanager_DAL.CustomerDal());

        // GET: CustomerController
        public ActionResult Index()
        {
            IReadOnlyCollection<CustomerDto> customers = customerCollection.GetAllCustomers();
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
                CustomerDto customer = customerCollection.GetCustomerById(id);
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
                CustomerCreateDto dto = new CustomerCreateDto();
                {
                    dto.Name = model.Name;
                    dto.Adress = model.Adress;

                }
                customerCollection.AddCustomer(dto);
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
            CustomerDto product = customerCollection.GetCustomerById(id);
            CustomerUpdateModel update = new CustomerUpdateModel();
            {
                update.Id = product.Id;
                update.Adress = product.Adress;

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
                CustomerUpdateDto dto = new CustomerUpdateDto();
                {
                    dto.Id = model.Id;
                    dto.Adress = model.Adress;
                }
                customerCollection.UpdateAdress(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
