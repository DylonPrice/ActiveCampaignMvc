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
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public ContactController(IContactRepository repository)
        {
            _contactRepository = repository;
        }

        public ActionResult Index()
        {
            return View("Contacts", _contactRepository.Contacts);
        }

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

            return View("Contacts", _contactRepository.Contacts);
        }

        public ActionResult DeleteContact(Contact contact)
        {
            var result = _activeService.DeleteContact(contact);
            if (result)
            {
                _contactRepository.DeleteContact(contact.Id);
            }
            
            return View("Contacts", _contactRepository.Contacts);
        }

        public ActionResult CreateContact()
        {
            return RedirectToAction("Index", "AddContact");
        }
    }
}