using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoeSto.Web.Models
{
    public class YPointGeometry
    {
        private string _type;
        public string Type {
            get { return _type; }
            set { _type = "Point"; }
        }


    }
}