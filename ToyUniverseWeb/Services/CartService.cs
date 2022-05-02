using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ToyUniverseData.Models;
using ToyUniverseWeb.Models;

namespace ToyUniverseWeb.Services
{
    public interface ICartService
    {
        public PagedResults<Item> GetCartPage(int currentPage);
    }
    public class CartService : GenericServices
    {

        public CartService()
        {
        }

        /*public PagedResults<Item> GetCartPage(int currentPage)
        {
            List<Item> items = Context.Session.GetObject<List<Item>>("cart");
            return GetPaged<Item>(Context.Session.GetObject<List<Item>>("cart"), currentPage, 10);
        }*/
    }
}
