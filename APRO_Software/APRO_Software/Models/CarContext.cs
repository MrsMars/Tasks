using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APRO_Software.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}