using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoeSto.DAC;
using MoeSto.Web.Controllers.UtilsMethods;
using MoeSto.Web.Models;

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
            ViewBag.Images = dbContext.Images.Where(x => x.CompanyId.Equals(id));
            return View();
        }
        [HttpPost]
        public ActionResult UploadImgs()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    dbContext.Images.InsertOnSubmit(Utils.GetImgFromRequst(Request, file));
                    dbContext.SubmitChanges();
                }
            }
            //in json result pass needed information for description of image 
            return Json(new { text = "boom!" }, JsonRequestBehavior.AllowGet);
        }

        
    }

}
