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
    public class EditContactController : Controller
    {
        private readonly IContactRepository _repository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public EditContactController(IContactRepository contactRepository)
        {
            _repository = contactRepository;
        }

        public ActionResult Index(Contact contact)
        {
            TempData.Clear();
            return View("EditContact", contact);
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            contact.Id = (string) TempData["Id"];
            TempData.Clear();
            if (ModelState.IsValid)
            {
                var result = _activeService.EditContact(contact);
                if (result)
                {
                    _repository.SaveContact(contact);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View("EditContact", contact);
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}