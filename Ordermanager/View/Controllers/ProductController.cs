using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ordermanager_Logic.Collections;
using Ordermanager_Logic.Dto;
using View.Models;

namespace View.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCollection orderCollection = new ProductCollection(new Ordermanager_DAL.ProductDal());

        // GET: ProductController
        public ActionResult Index()
        {
            IReadOnlyCollection<ProductDto> products = orderCollection.GetAllProducts();
            if (products.Count == 0)
            {
                throw new Exception("Geen gegevens gevonden.");
            }
            List<ProductViewModel> productView = new List<ProductViewModel>();
            foreach (var product in products)
            {
                ProductViewModel input = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price

                };
                productView.Add(input);
            }
            return View(productView);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
