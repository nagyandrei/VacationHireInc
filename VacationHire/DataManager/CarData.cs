using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataManager
{
    public class CarData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }
        public int Fuel { get; set; }
        public int Availability { get; set; }
        public float Price { get; set; }
        public int UsedFuel { get; set; }
    }
}