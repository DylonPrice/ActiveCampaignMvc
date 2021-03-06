﻿using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Add_Controllers
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
                return RedirectToAction("Index", "Campaign");
            }
            return View("AddCampaign");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Campaign");
        }
    }
}