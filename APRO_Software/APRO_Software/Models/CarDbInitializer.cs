using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace APRO_Software.Models
{
    public class CarDbInitializer : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            Manufacturer manufacturer_1 = new Manufacturer { Name = "Tesla", isCheck = true };
            Manufacturer manufacturer_2 = new Manufacturer { Name = "Volvo", isCheck = true };
            Manufacturer manufacturer_3 = new Manufacturer { Name = "Audi", isCheck = true };

            context.Manufacturers.AddRange(new List<Manufacturer> { manufacturer_1, manufacturer_2, manufacturer_3 });
            context.SaveChanges();

            VehicleType vehicleType_1 = new VehicleType { Name = "Model S", Manufacturer = manufacturer_1 };
            VehicleType vehicleType_2 = new VehicleType { Name = "Model X", Manufacturer = manufacturer_1 };
            VehicleType vehicleType_3 = new VehicleType { Name = "Model 3", Manufacturer = manufacturer_1 };
            VehicleType vehicleType_4 = new VehicleType { Name = "XC90", Manufacturer = manufacturer_2 };
            VehicleType vehicleType_5 = new VehicleType { Name = "XC70", Manufacturer = manufacturer_2 };
            VehicleType vehicleType_6 = new VehicleType { Name = "A6", Manufacturer = manufacturer_3 };

            context.VehicleTypes.AddRange(new List<VehicleType> { vehicleType_1, vehicleType_2, vehicleType_3, vehicleType_4, vehicleType_5, vehicleType_6 });
            context.SaveChanges();

            Car car_1 = new Car { Manufacturer = manufacturer_1, VehicleType = vehicleType_1, TypeCoupe = "Coupe" , Year = 2017, Power = 520, Cost = 80000 };
            Car car_2 = new Car { Manufacturer = manufacturer_1, VehicleType = vehicleType_2, TypeCoupe = "Coupe" , Year = 2018, Power = 650, Cost = 120000 };
            Car car_3 = new Car { Manufacturer = manufacturer_1, VehicleType = vehicleType_3, TypeCoupe = "Cabriolet", Year = 2016, Power = 410, Cost = 62000 };
            Car car_4 = new Car { Manufacturer = manufacturer_3, VehicleType = vehicleType_1, TypeCoupe = "SUV", Year = 2012, Power = 250, Cost = 65000 };
            Car car_5 = new Car { Manufacturer = manufacturer_3, VehicleType = vehicleType_6, TypeCoupe = "SUV", Year = 2014, Power = 320, Cost = 70000 };
            Car car_6 = new Car { Manufacturer = manufacturer_3, VehicleType = vehicleType_6, TypeCoupe = "SUV", Year = 2014, Power = 360, Cost = 75000 };
            Car car_7 = new Car { Manufacturer = manufacturer_3, VehicleType = vehicleType_6, TypeCoupe = "SUV", Year = 2016, Power = 480, Cost = 80000 };
            Car car_8 = new Car { Manufacturer = manufacturer_2, VehicleType = vehicleType_4, TypeCoupe = "Combi", Year = 2015, Power = 313, Cost = 4200 };
            Car car_9 = new Car { Manufacturer = manufacturer_2, VehicleType = vehicleType_5, TypeCoupe = "Combi", Year = 2016, Power = 250, Cost = 53000 };
            Car car_10 = new Car { Manufacturer = manufacturer_2, VehicleType = vehicleType_4, TypeCoupe = "Combi", Year = 2017, Power = 320, Cost = 63000 };
            Car car_11 = new Car { Manufacturer = manufacturer_1, VehicleType = vehicleType_2, TypeCoupe = "Cabriolet", Year = 2018, Power = 530, Cost = 77000 };
            Car car_12 = new Car { Manufacturer = manufacturer_1, VehicleType = vehicleType_3, TypeCoupe = "Cabriolet", Year = 2018, Power = 425, Cost = 80000 };

            context.Cars.AddRange(new List<Car>{car_1, car_2, car_3, car_4, car_5, car_6, car_7, car_8, car_9, car_10, car_11, car_12 });
            context.SaveChanges();


            base.Seed(context);
        }
    }
}