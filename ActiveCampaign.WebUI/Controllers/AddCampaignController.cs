using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers
{
    public class AddCampaignController : Controller
    {
        private ICampaignRepository _repository;
        private ActiveApi _activeService = new ActiveApi();

        public AddCampaignController(ICampaignRepository campaignRepo)
        {
            _repository = campaignRepo;
        }

        public ActionResult Index()
        {
            return View("AddCampaign");
        }

        public ActionResult CreateCampaign(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                var isPublic = Request["isPublic"];
                campaign = _activeService.AddCampaign(campaign, isPublic);
                _repository.SaveCampaign(campaign);
                return RedirectToAction("Index", "Home");
            }
            return View("AddCampaign");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}