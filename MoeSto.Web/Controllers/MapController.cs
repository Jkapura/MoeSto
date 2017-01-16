using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MoeSto.DAC;
using MoeSto.Web.Controllers.UtilsMethods;
using MoeSto.Web.Models.DtoObjects;

namespace MoeSto.Web.Controllers
{
    public class MapController : Controller
    {
        // GET: /Map/
        DataAccessManagerDataContext dbContext = new DataAccessManagerDataContext();
        public string tile(string bbox, string callback)
        {
            
            if (bbox != null)
            {
                var shape = Utils.GetShapeFromBounds(bbox);
                //var result = from Details in dbContext.CompanyDetails
                //                select new
                //                {
                //                    Details.Companies.Id,
                //                    Details.Companies.Latitude,
                //                    Details.Companies.Longitude,
                //                    Details.City
                //                };
                var result = Utils.ConvertCompaniesToDto(
                    dbContext.Companies.Where(
                        x =>
                            shape.LeftBottomLatitude <= x.Latitude && x.Latitude <= shape.RightUpLatitude && shape.LeftBottomLongitude <= x.Longitude && x.Longitude <= shape.RightUpLongitude
                            ).ToList());
                return callback + "(" + new JavaScriptSerializer().Serialize(new { error = "", data = result }) + ")";
            }
            return null;
        }

        public JsonResult GetCompanyDetails(int id)
        {
            if (id != 0)
            {
                var details = dbContext.CompanyDetails.FirstOrDefault(x => x.Id.Equals(id));
                var image = dbContext.Images.FirstOrDefault(x => x.CompanyId.Equals(id));
                var companyDetails = Utils.CompanyDetailsToDto(details, image);
                return Json(companyDetails, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public JsonResult GetCompanyDetailsByCoordinates(string coordinates)
        {
            if (coordinates != null)
            {
                List<double> twoCoords=new List<double>();
                var stringCoords = Utils.GetFromStringCoordinates(coordinates);
                foreach (var item in stringCoords)
                {
                    twoCoords.Add(Utils.GetDouble(item)); 
                }
                var details =
                    dbContext.CompanyDetails.Where(
                        x => x.Longitude.Equals(twoCoords[1]) && x.Latitude.Equals(twoCoords[0])).ToList();
                var image=0;
                //todo search for image
                var companyDetails = Utils.ClusterDetailsToDto(details);
                return Json(companyDetails, JsonRequestBehavior.AllowGet);
            }
            return null;
        }



    }
}
