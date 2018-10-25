using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lightpoint.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Address { get; set; }


        public string WorkShedules { get; set; }


        public ICollection<Item> Items { get; set; }
        public Shop()
        {
            Items = new List<Item>();
        }
    }

    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Shop> Shops { get; set; }
        public Item()
        {
            Shops = new List<Shop>();
        }
    }
}