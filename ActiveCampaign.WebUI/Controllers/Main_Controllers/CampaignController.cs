using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Main_Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignRepository _repository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public CampaignController(ICampaignRepository campaignRepo)
        {
            _repository = campaignRepo;
        }

        public ActionResult Index()
        {
            return View("campaigns", _repository.Campaigns);
        }

        public ActionResult CreateCampaign()
        {
            return RedirectToAction("Index", "AddCampaign");
        }

        public ActionResult GetCampaigns(string id)
        {
            if (Request["campaignId"] != null)
            {
                id = Request["campaignId"];
            }
            _repository.ClearCampaigns();
            var campaigns = _activeService.GetCampaigns(id);

            foreach (var campaign in campaigns)
            {
                _repository.SaveCampaign(campaign);
            }

            return View("Campaigns", _repository.Campaigns);
        }

        public ActionResult DeleteCampaign(Campaign campaign)
        {
            var result = _activeService.DeleteCampaign(campaign);

            if (result)
            {
                _repository.DeleteCampaign(campaign.Id);
            }

            return View("Campaigns", _repository.Campaigns);
        }

        public ActionResult ViewCampaign(Campaign campaign)
        {
            return RedirectToAction("Index", "ViewCampaign", campaign);
        }
    }
}