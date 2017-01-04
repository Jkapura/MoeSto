using System.Linq;
using System.Text.RegularExpressions;
using MoeSto.Web.Models;
using MoeSto.Web.Models.DtoObjects;

namespace MoeSto.Web.Controllers.UtilsMethods
{
    public static class Utils
    {
        public static YPointCollection ConvertCompaniesToDto(System.Collections.Generic.List<DAC.Company> list)
        {
            if (list != null)
            {
                YPointCollection points = new YPointCollection();
                foreach (var item in list)
                {
                    YPoint point = new YPoint();
                    point.id = item.Id;
                    YPointGeometry _geometry = new YPointGeometry();
                    _geometry.coordinates.Add(item.Latitude);
                    _geometry.coordinates.Add(item.Longitude);
                    point.geometry = _geometry;
                   // YPointProperties _properties = new YPointProperties();
                  //  point.properties = _properties;

                    points.features.Add(point);
                }
                return points;
            }
            return null;
        }

        //Example of string:[[53.79388,27.374416],[53.971588,28.063091]]
        public static Shape GetShapeFromBounds(string bounds)
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

        public static double GetDouble(string s)
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