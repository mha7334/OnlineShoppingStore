﻿using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using OnlineShoppingStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.UI.Controllers
{
    public class CartController : Controller
    {
       private IProductRepository repository;

       public CartController(IProductRepository repo)
       {
           repository = repo;
       }

        public ViewResult Index(Cart cart, string returnUrl)
       {
           return View(
               new CartIndexViewModel {Cart = cart, ReturnUrl = returnUrl }
               );
       }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
       {
           Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if(product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
       }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

       
    }
}