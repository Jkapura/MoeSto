using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoeSto.Web.Models.DtoObjects
{
    public class YPointCollection
    {
        public string Type { get; set; }
        public YPoint[] Features { get; set; }
    }
}