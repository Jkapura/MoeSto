using System;
using System.Collections.Generic;

namespace MoeSto.Web.Models.DtoObjects
{
    public class YPointCollection
    {
        public string type { get; set; } 
        public List<YPoint> features { get; set; }

        public YPointCollection()
        {
            type = "FeatureCollection";
            features = new List<YPoint>();
        }
    }
}