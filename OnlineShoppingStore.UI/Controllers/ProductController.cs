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
        public int pageSize = 2;
        public ProductController(IProductRepository repo)
        {
            repository = repo;

        }

        public ViewResult List(int page = 1)
        {

            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                            .OrderBy(p => p.ProductId)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = page,
                    TotalItems = repository.Products.Count()
                }
            };
            return View(model);
        }
    }
}