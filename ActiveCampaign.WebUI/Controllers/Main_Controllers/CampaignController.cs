using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Main_Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public CampaignController(ICampaignRepository repository)
        {
            _campaignRepository = repository;
        }

        public ActionResult Index()
        {
            return View("campaigns", _campaignRepository.Campaigns);
        }

        public ActionResult CreateCampaign()
        {
            return RedirectToAction("Index", "AddCampaign");
        }

        public ActionResult GetCampaigns(string id)
        {
            return View("Campaigns");
        }

        public ActionResult DeleteCampaign(string id)
        {
            return View("Campaigns");
        }

        public ActionResult ViewCampaign(string id)
        {
            return View("Campaigns");
        }
    }
}