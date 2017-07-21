using System.Web.Mvc;

namespace ActiveCampaign.WebUI.Controllers.Main_Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Home");
        }
    }
}