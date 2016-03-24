using System.Web.Mvc;
using ApplicationMVC.ViewModels;

namespace ApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var aboutModel = new AboutModel
            {
                Title = "About",
                Message = "Your application description page."
            };

            return View(aboutModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}