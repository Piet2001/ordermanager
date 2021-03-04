﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ProductCollection _productCollection;

        public ProductController(IProductProvider product)
        {
            _productCollection = new ProductCollection(product);
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IReadOnlyCollection<Product> products = _productCollection.GetAllProducts();
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
                Product product = _productCollection.GetProductById(id);
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
                if (model.Price.Contains("."))
                    model.Price = model.Price.Replace(".",",");
                
                Product product = new Product
                (
                    model.Name,
                    Convert.ToDecimal(model.Price)
                );
                _productCollection.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.message = "Controleer of invoer in format 1,23 staat!";
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productCollection.GetProductById(id);
            ProductUpdateModel update = new ProductUpdateModel();
            {
                update.Id = product.Id;
                update.Price = Convert.ToString(product.Price);

            }
            //ViewBag.message = " ";
            return View(update);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductUpdateModel model)
        {
            try
            {
                if (model.Price.Contains("."))
                    model.Price = model.Price.Replace(".", ",");

                _productCollection.UpdatePrice(model.Id, Convert.ToDecimal(model.Price));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.message = "Controleer of invoer in format 1,23 staat!";
                return View();
            }
        }
    }
}
