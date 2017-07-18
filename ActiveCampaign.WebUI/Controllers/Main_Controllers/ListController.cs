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
    public class ListController : Controller
    {
        private readonly IListRepository _listRepository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public ListController(IListRepository repository)
        {
            _listRepository = repository;
        }

        public ActionResult Index()
        {
            return View("lists", _listRepository.Lists);
        }

        public ActionResult EditList(List list)
        {
            return RedirectToAction("Index", "EditList", list);
        }

        public ActionResult CreateList()
        {
            return RedirectToAction("Index", "AddList");
        }

        public ActionResult DeleteList(List list)
        {
            var result = _activeService.DeleteList(list);
            if (result)
            {
                _listRepository.DeleteList(list.Id);
            }
            
            return View("lists", _listRepository.Lists);
        }

        public ActionResult GetLists(string id)
        {
            if (Request["listId"] != null)
            {
                id = Request["listId"];
            }
            _listRepository.ClearLists();
            var lists = _activeService.GetLists(id);

            foreach (var list in lists)
            {
                _listRepository.SaveList(list);
            }

            return View("lists", _listRepository.Lists);
        }
    }
}