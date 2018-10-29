using APRO_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APRO_Software.Controllers
{
    public class HomeController : Controller
    {
        CarContext db = new CarContext();

        [HttpGet]
        public ActionResult Index()
        {
            var Cars = (from str in db.Cars
                        select new CarInfo
                        {
                            Id = str.Id,
                            Manufacturer = str.Manufacturer.Name,
                            VehicleType = str.VehicleType.Name,
                            TypeCoupe = str.TypeCoupe,
                            Year = str.Year,
                            Power = str.Power,
                            Cost = str.Cost,
                            isCheck = str.Manufacturer.isCheck
                        }).ToList();

            ViewBag.Manufactures = (from str in db.Manufacturers
                                    select str).ToList();
            ViewBag.ManufacturesCount = (from str in db.Manufacturers
                                         select str).Count();
            return View(Cars);    
        }

        [HttpPost]
        public ActionResult Index(string selected = null)
        {            
            if (selected == null)
            {
                var Cars = (from str in db.Cars
                            select new CarInfo
                            {
                                Id = str.Id,
                                Manufacturer = str.Manufacturer.Name,
                                VehicleType = str.VehicleType.Name,
                                TypeCoupe = str.TypeCoupe,
                                Year = str.Year,
                                Power = str.Power,
                                Cost = str.Cost,
                                isCheck = str.Manufacturer.isCheck
                            }).ToList();

                ViewBag.Manufactures = (from str in db.Manufacturers
                                        select str).ToList();
                ViewBag.ManufacturesCount = (from str in db.Manufacturers
                                             select str).Count();
                return View(Cars);
            }
            else
            {
                int choice = Convert.ToInt32(selected);
                var Cars = (from str in db.Cars
                            where str.ManufacturerId == choice + 1
                            select new CarInfo
                            {
                                Id = str.Id,
                                Manufacturer = str.Manufacturer.Name,
                                VehicleType = str.VehicleType.Name,
                                TypeCoupe = str.TypeCoupe,
                                Year = str.Year,
                                Power = str.Power,
                                Cost = str.Cost,
                                isCheck = str.Manufacturer.isCheck
                            }).ToList();

                ViewBag.Manufactures = (from str in db.Manufacturers
                                        select str).ToList();
                ViewBag.ManufacturesCount = (from str in db.Manufacturers
                                             select str).Count();

                return View(Cars);
            }
        }

        public ActionResult OrderByCost(bool order)
        {
            if (order)
            {
                var Cars = (from str in db.Cars
                            orderby str.Cost
                            select new CarInfo
                            {
                                Id = str.Id,
                                Manufacturer = str.Manufacturer.Name,
                                VehicleType = str.VehicleType.Name,
                                TypeCoupe = str.TypeCoupe,
                                Year = str.Year,
                                Power = str.Power,
                                Cost = str.Cost
                            }).ToList();

                return PartialView(Cars);
            }
            else
            {
                var Cars = (from str in db.Cars
                            orderby str.Cost descending
                            select new CarInfo
                            {
                                Id = str.Id,
                                Manufacturer = str.Manufacturer.Name,
                                VehicleType = str.VehicleType.Name,
                                TypeCoupe = str.TypeCoupe,
                                Year = str.Year,
                                Power = str.Power,
                                Cost = str.Cost
                            }).ToList();

                return PartialView(Cars);
            }
        }
    }
}
