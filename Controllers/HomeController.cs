using System.Web.Mvc;
using XMLExternalEntity.Models;
using XMLExternalEntity.Utility;
using System.Collections.Generic;

namespace XMLExternalEntity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Preview()
        {
            List<Offer> offers = new List<Offer>();

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    ViewBag.FileName = file.FileName;
                    offers = OfferParser.GetOffers(file.InputStream);
                }
            }
            else
            {
                ViewBag.FileName = "No file is uploaded";
            }

            return View(offers);
        }
    }
}