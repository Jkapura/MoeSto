using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MoeSto.DAC;
using MoeSto.Web.Controllers.UtilsMethods;
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
                var result = Utils.ConvertCompaniesToDto(
                    dbContext.Companies.Where(
                        x =>
                            shape.LeftBottomLatitude <= x.Latitude && x.Latitude <= shape.RightUpLatitude && shape.LeftBottomLongitude <= x.Longitude && x.Longitude <= shape.RightUpLongitude
                            ).ToList());
                return callback + "(" + new JavaScriptSerializer().Serialize(new { error = "", data = result }) + ")";
            }
            return null;
        }

    }
}
