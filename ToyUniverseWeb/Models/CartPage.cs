using System.Collections.Generic;

namespace ToyUniverseWeb.Models
{
    public class CartPage
    {
        public List<Item> ItemList { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
