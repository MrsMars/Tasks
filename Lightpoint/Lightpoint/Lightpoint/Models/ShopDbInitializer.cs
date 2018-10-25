using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Lightpoint.Models;

namespace Lightpoint.Models
{
    public class ShopDbInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {

            Item item_1 = new Item { Name = "item_1", Description = "Some description for item #1" };
            Item item_2 = new Item { Name = "item_2", Description = "Some description for item #2" };
            Item item_3 = new Item { Name = "item_3", Description = "Some description for item #3" };
            Item item_4 = new Item { Name = "item_4", Description = "Some description for item #4" };
            Item item_5 = new Item { Name = "item_5", Description = "Some description for item #5" };
            Item item_6 = new Item { Name = "item_6", Description = "Some description for item #6" };
            Item item_7 = new Item { Name = "item_7", Description = "Some description for item #7" };
            Item item_8 = new Item { Name = "item_8", Description = "Some description for item #8" };
            Item item_9 = new Item { Name = "item_9", Description = "Some description for item #9" };
            Item item_10 = new Item { Name = "item_10", Description = "Some description for item #10" };
            Item item_11 = new Item { Name = "item_11", Description = "Some description for item #11" };
            Item item_12 = new Item { Name = "item_12", Description = "Some description for item #12" };
            Item item_13 = new Item { Name = "item_13", Description = "Some description for item #13" };
            Item item_14 = new Item { Name = "item_14", Description = "Some description for item #14" };
            Item item_15 = new Item { Name = "item_15", Description = "Some description for item #15" };

            db.Items.AddRange(new List<Item> { item_1, item_2, item_3, item_4, item_5 });
            db.SaveChanges();

            Shop shop_1 = new Shop { Name = "FirstShop", Address = "1 WS street", WorkShedules = "9-18" };
            shop_1.Items.Add(item_3);
            shop_1.Items.Add(item_4);
            shop_1.Items.Add(item_5);
            shop_1.Items.Add(item_6);
            shop_1.Items.Add(item_7);
            shop_1.Items.Add(item_11);
            db.Shops.Add(shop_1);

            Shop shop_2 = new Shop { Name = "SecondShop", Address = "1 WS street", WorkShedules = "9-18" };
            shop_2.Items.Add(item_1);
            shop_2.Items.Add(item_7);
            shop_2.Items.Add(item_10);
            shop_2.Items.Add(item_12);
            shop_2.Items.Add(item_13);
            shop_2.Items.Add(item_14);
            shop_2.Items.Add(item_15);
            db.Shops.Add(shop_2);

            Shop shop_3 = new Shop { Name = "ThirdShop", Address = "1 WS street", WorkShedules = "9-18" };
            shop_3.Items.Add(item_3);
            shop_3.Items.Add(item_4);
            shop_3.Items.Add(item_8);
            shop_3.Items.Add(item_9);
            shop_3.Items.Add(item_15);
            db.Shops.Add(shop_3);


            db.SaveChanges();

            base.Seed(db);
        }
    }
}