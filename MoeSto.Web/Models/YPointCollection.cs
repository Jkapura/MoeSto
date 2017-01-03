using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoeSto.Web.Models
{
    public class YPointCollection
    {
        public string Type { get; set; }
        public List<YPoint> Features { get; set; }
    }
}