﻿using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public int pageSize = 3;
        public ProductController(IProductRepository repo)
        {
            repository = repo;

        }

        public ViewResult List(string category, int page = 1)
        {

            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                            .Where(p => category == null || p.Category == category)
                            .OrderBy(p => p.ProductId)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? 
                                repository.Products.Count() : 
                                repository.Products.Where(a => a.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}