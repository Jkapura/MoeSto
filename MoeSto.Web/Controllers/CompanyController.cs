using System.Linq;
using System.Web.Mvc;
using MoeSto.DAC;

namespace MoeSto.Web.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        DataAccessManagerDataContext dbContext = new DataAccessManagerDataContext();
        public ActionResult View(int id)
        {
            ViewBag.CompanyDetails = dbContext.CompanyDetails.FirstOrDefault(x => x.Id.Equals(id));
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Cities = dbContext.CompanyDetails.Where(x => x.City != null && x.City != "").Select(x => x.City).Distinct().ToList();
            ViewBag.CompanyDetails = dbContext.CompanyDetails.FirstOrDefault(x => x.Id.Equals(id));
            return View();
        }

    }
}
