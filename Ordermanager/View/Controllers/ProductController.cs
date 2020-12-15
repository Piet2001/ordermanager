using Microsoft.AspNetCore.Mvc;
using Ordermanager_Logic.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ordermanager_Logic;
using Ordermanager_Logic.Interfaces;
using View.Models;

namespace View.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCollection productCollection;

        public ProductController(IProductProvider product)
        {
            productCollection = new ProductCollection(product);
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IReadOnlyCollection<Product> products = productCollection.GetAllProducts();
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
            ProductViewModel productView = new ProductViewModel();
            try
            {
                Product product = productCollection.GetProductById(id);
                productView.Id = product.Id;
                productView.Name = product.Name;
                productView.Price = product.Price;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw new Exception("Geen details gevonden!");
            }
            return View(productView);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateModel model)
        {
            try
            {
                Product product = new Product
                (
                    model.Name,
                    model.Price
                );
                productCollection.AddProduct(product);
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
            Product product = productCollection.GetProductById(id);
            ProductUpdateModel update = new ProductUpdateModel();
            {
                update.Id = product.Id;
                update.Price = product.Price;

            }
            return View(update);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductUpdateModel model)
        {
            try
            {
                productCollection.UpdatePrice(model.Id, model.Price);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
