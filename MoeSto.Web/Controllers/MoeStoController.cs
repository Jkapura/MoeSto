using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using MoeSto.DAC;
using MoeSto.Web.Models;

namespace MoeSto.Web.Controllers
{
    public class MoeStoController : Controller
    {
        //
        // GET: /MoeSto/
        DataAccessManagerDataContext dbContext = new DataAccessManagerDataContext();
        public ActionResult Main()
        {
            return View();
        }
        
        public JsonResult GetObjectsByBounds(string bounds)
        {
            if (bounds!=null)
            {
                var shape = GetShapeFromBounds(bounds);
                var result =
                    dbContext.Companies.Where(
                        x =>
                            shape.LeftBottomLatitude <= x.Latitude && x.Latitude <= shape.RightUpLatitude &&shape.LeftBottomLongitude <= x.Longitude && x.Longitude <= shape.RightUpLongitude
                            ).ToList();
                return Json(result,JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        //Example of string:[[53.79388,27.374416],[53.971588,28.063091]]
        private Shape GetShapeFromBounds(string bounds)
        {
            Shape shape = new Shape();
            var strArray = Regex.Split(bounds, @"[^0-9\.]+")
                .Where(c => c != "." && c.Trim() != "");
            shape.LeftBottomLatitude = GetDouble(strArray.ElementAtOrDefault(0));
            shape.LeftBottomLongitude = GetDouble(strArray.ElementAtOrDefault(1));
            shape.RightUpLatitude = GetDouble(strArray.ElementAtOrDefault(2));
            shape.RightUpLongitude = GetDouble(strArray.ElementAtOrDefault(3));
            return shape;
        }

        private static double GetDouble(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                double result;
                if (double.TryParse(s, out result))
                {
                    return result;
                }
            }
            return 0;
        }
    }
}
