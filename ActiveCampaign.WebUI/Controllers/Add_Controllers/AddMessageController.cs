using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Add_Controllers
{
    public class AddMessageController : Controller
    {
        private readonly IMessageRepository _repository;
        private readonly ActiveApi _activeService = new ActiveApi();
    
        public AddMessageController(IMessageRepository messageRepo)
        {
            _repository = messageRepo;
        }

        public ActionResult Index()
        {
            return View("AddMessage");
        }

        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message = _activeService.AddMessage(message);
                _repository.SaveMessage(message);
                return RedirectToAction("Index", "Message");
            }
            return View("AddMessage");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Message");
        }
    }
}