using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APRO_Software.Models;

namespace APRO_Software.Controllers
{
    public class AdminController : Controller
    {
        CarContext db = new CarContext();

        [HttpGet]
        public ActionResult Create()
        {
            Car newCar = new Car();
            
            return View(newCar);
        }

        [HttpPost]
        public ActionResult Create(Car newCar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isNewManufacturer = (from str in db.Manufacturers
                                             where str.Name == newCar.Manufacturer.Name
                                             select str).FirstOrDefault();

                    if (isNewManufacturer == null)
                    {
                        Manufacturer newManufacturer = new Manufacturer() { Name = newCar.Manufacturer.Name };
                        db.Manufacturers.Add(newManufacturer);

                        db.SaveChanges();
                    }
                    else { newCar.Manufacturer = isNewManufacturer; }


                    var isNewVehicleType = (from str in db.VehicleTypes
                                            where str.Name == newCar.VehicleType.Name
                                            select str).FirstOrDefault();

                    if (isNewVehicleType == null)
                    {
                        VehicleType newVehicleType = new VehicleType() { Name = newCar.VehicleType.Name, Manufacturer = newCar.Manufacturer };
                        db.VehicleTypes.Add(newVehicleType);

                        db.SaveChanges();
                    }
                    else { newCar.VehicleType = isNewVehicleType; }

                    db.Cars.Add(newCar);
                    db.SaveChanges(); 
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
                return View(newCar);
            }            
        }

        [HttpGet]
        public ActionResult Edit(int carId)
        {
            Car editCar = db.Cars.FirstOrDefault(c => c.Id == carId);
            editCar.Manufacturer = db.Manufacturers.FirstOrDefault(m => m.Id == editCar.ManufacturerId);
            editCar.VehicleType = db.VehicleTypes.FirstOrDefault(v => v.Id == editCar.VehicleTypeId);
            
            return View(editCar);
        }

        [HttpPost]
        public ActionResult Edit(int carId, Car editCar)
        {
            Car dbcar = (from str in db.Cars
                         where str.Id == carId
                         select str).First();
            try
            {
                var isNewManufacturer = (from str in db.Manufacturers
                                         where str.Name == editCar.Manufacturer.Name
                                         select str).FirstOrDefault();

                if (isNewManufacturer == null)
                {
                    Manufacturer newManufacturer = new Manufacturer() { Name = editCar.Manufacturer.Name };
                    db.Manufacturers.Add(newManufacturer);

                    db.SaveChanges();
                }
                else { dbcar.Manufacturer = isNewManufacturer; }


                var isNewVehicleType = (from str in db.VehicleTypes
                                        where str.Name == editCar.VehicleType.Name
                                        select str).FirstOrDefault();

                if (isNewVehicleType == null)
                {
                    VehicleType newVehicleType = new VehicleType() { Name = editCar.VehicleType.Name, Manufacturer = editCar.Manufacturer };
                    db.VehicleTypes.Add(newVehicleType);
                }
                else { dbcar.VehicleType = isNewVehicleType; }

                dbcar.Cost = editCar.Cost;
                dbcar.Power = editCar.Power;
                dbcar.TypeCoupe = dbcar.TypeCoupe;
                dbcar.Year = editCar.Year;       
                
                db.Entry(dbcar).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch(Exception)
            {
                return View();
            }
        }
    }
}