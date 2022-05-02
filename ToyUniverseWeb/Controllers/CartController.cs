using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToyUniverseWeb.Extensions;
using ToyUniverseWeb.Models;
using ToyUniverseWeb.Services;

namespace ToyUniverseWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IToyService _toyService;

        public CartController(IToyService productService)
        {
            this._toyService = productService;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.Get("cart") == null)
            {
                List<Item> cart = new List<Item>();

                HttpContext.Session.SetObject("cart", cart);
            }

            return View();
        }

        public ActionResult Add(string id)
        {
            if (HttpContext.Session.GetObject<List<Item>>("cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Toy = this._toyService.Find(id), Quantity = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Toy = this._toyService.Find(id), Quantity = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
            int index = isExist(id);
            if(cart[index].Quantity > 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.RemoveAt(index);
            }
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Toy.CToyId.Equals(id))
                    return i;
            return -1;
        }
    }
}
