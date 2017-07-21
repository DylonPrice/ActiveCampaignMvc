using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActiveCampaign.Domain.Entities;

namespace ActiveCampaign.WebUI.Controllers
{
    public class ViewCampaignController : Controller
    {
        public ActionResult Index(Campaign campaign)
        {
            return View("ViewCampaign", campaign);
        }

        public ActionResult back()
        {
            return RedirectToAction("Index", "Campaign");
        }
    }
}