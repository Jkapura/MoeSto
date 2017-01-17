using System.Linq;
using System.Web.Mvc;
using MoeSto.DAC;

namespace MoeSto.Web.Controllers
{
    public class MoeStoController : Controller
    {
        //
        // GET: /MoeSto/
        DataAccessManagerDataContext dbContext = new DataAccessManagerDataContext();
        public ActionResult Map()
        {
            ViewBag.Cities = dbContext.CompanyDetails.Where(x => x.City != null && x.City!= "").Select(x => x.City).Distinct().ToList();
            return View();
        }
        
    }
}
