using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Add_Controllers
{
    public class AddContactController : Controller
    {
        private IContactRepository _repository;
        private ActiveApi _activeService = new ActiveApi();

        public AddContactController(IContactRepository contactRepository)
        {
            _repository = contactRepository;
        }

        public ActionResult Index()
        {
            return View("AddContact");
        }

        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact = _activeService.AddContact(contact);
                _repository.SaveContact(contact);
                return RedirectToAction("Index", "Home");
            }
            return View("AddContact");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}