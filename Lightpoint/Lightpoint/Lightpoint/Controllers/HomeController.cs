using Lightpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lightpoint.Controllers
{
    public class HomeController : Controller
    {
        ShopContext db = new ShopContext();

        public ActionResult Index()
        {
            IEnumerable<Shop> shops = db.Shops;
            ViewBag.Shops = shops;

            return View();
        }

        [HttpGet]
        public ActionResult ShowItems(int id)
        {
            ViewBag.ShopName = (from str in db.Shops
                    where str.Id == id
                    select str.Name).First();

            ViewBag.ItemInfo = (from str in db.Items
                                where str.Shops.Any(c => c.Id == id)
                                select str).ToList();

            return View();
        }
    }
}