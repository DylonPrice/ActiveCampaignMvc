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
    public class HomeController : Controller
    {
        private readonly IListRepository _listRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public HomeController(IListRepository listRepo, IContactRepository contactRepo, ICampaignRepository campaignRepo)
        {
            _listRepository = listRepo;
            _contactRepository = contactRepo;
            _campaignRepository = campaignRepo;
        }

        public ActionResult Index()
        {
            var tuple = Tuple.Create(_listRepository.Lists, _contactRepository.Contacts, _campaignRepository.Campaigns);
            return View("Home", tuple);
        }

        // Contacts

        public ActionResult EditContact(Contact contact)
        {
            return RedirectToAction("Index", "EditContact", contact);
        }

        public ActionResult GetContacts(string id)
        {
            if (Request["contactId"] != null)
            {
                id = Request["contactId"];
            }
            _contactRepository.ClearContacts();
            var contacts = _activeService.GetContacts(id);

            foreach (var contact in contacts)
            {
                _contactRepository.SaveContact(contact);
            }

            var tuple = Tuple.Create(_listRepository.Lists, _contactRepository.Contacts, _campaignRepository.Campaigns);
            return View("Home", tuple);
        }

        public ActionResult DeleteContact(Contact contact)
        {
            var result = _activeService.DeleteContact(contact);
            if (result)
            {
                _contactRepository.DeleteContact(contact.Id);
            }
            var tuple = Tuple.Create(_listRepository.Lists, _contactRepository.Contacts, _campaignRepository.Campaigns);
            return View("Home", tuple);
        }

        public ActionResult CreateContact()
        {
            return RedirectToAction("Index", "AddContact");
        }

        // Lists

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

            var tuple = Tuple.Create(_listRepository.Lists, _contactRepository.Contacts, _campaignRepository.Campaigns);
            return View("Home", tuple);
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
            var tuple = Tuple.Create(_listRepository.Lists, _contactRepository.Contacts, _campaignRepository.Campaigns);
            return View("Home", tuple);
        }

        // Campaigns

        public ActionResult CreateCampaign()
        {
            return RedirectToAction("Index", "AddCampaign");
        }

        public ActionResult GetCampaigns(string id)
        {
            return View("Home");
        }

        public ActionResult DeleteCampaign(string id)
        {
            return View("Home");
        }

        public ActionResult ViewCampaign(string id)
        {
            return View("Home");
        }
    }
}