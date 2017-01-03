using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoeSto.Web.Models
{
    public class Company
    {
        public string Name { get; set; }
        public int Unp { get; set; }
        public string Address { get; set; }
        public string Email  { get; set; }
        public string Phones { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
