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
    public class AddListController : Controller
    {
        private IListRepository _repository;
        ActiveApi _activeService = new ActiveApi();

        public AddListController(IListRepository listRepository)
        {
            _repository = listRepository;
        }
        
        public ActionResult Index()
        {
            return View("AddList");
        }

        [HttpPost]
        public ActionResult CreateList(List list)
        {
            if (ModelState.IsValid)
            {
                list = _activeService.AddList(list);
                _repository.SaveList(list);
                return RedirectToAction("Index", "Home");
            }
            return View("AddList");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}