using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataManager
{
    public class OrderData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
        public float Days { get; set; }
        public int ProductId { get; set; }
    }
}