using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APRO_Software.Models
{
    public class Car
    {
        public int Id { get; set; }


        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }


        public int? VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }


        public string TypeCoupe { get; set; }

        public int Year { get; set; }

        public int Power { get; set; }

        public decimal Cost { get; set; }     
    }

    public class VehicleType
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }


        public ICollection<Car> Cars { get; set; }
        public VehicleType()
        {
            Cars = new List<Car>();
        }
    }

    public class Manufacturer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<VehicleType> VehicleTypes { get; set; }
        public Manufacturer()
        {
            VehicleTypes = new List<VehicleType>();
        }
        public bool isCheck { get; set; }
    }

    public class CarInfo
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string VehicleType { get; set; }
        public string TypeCoupe { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public decimal Cost { get; set; }
        public bool isCheck { get; set; }
    }
}