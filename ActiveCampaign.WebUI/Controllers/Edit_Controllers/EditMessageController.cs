using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Edit_Controllers
{
    public class EditMessageController : Controller
    {
        private readonly IMessageRepository _repository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public EditMessageController(IMessageRepository messageRepo)
        {
            _repository = messageRepo;
        }
        
        public ActionResult Index(Message message)
        {
            TempData.Clear();
            return View("EditMessage", message);
        }

        [HttpPost]
        public ActionResult EditMessage(Message message)
        {
            message.Id = (string) TempData["Id"];
            TempData.Clear();
            if (ModelState.IsValid)
            {
                var result = _activeService.EditMessage(message);
                if (result)
                {
                    _repository.SaveMessage(message);
                    return RedirectToAction("Index", "Message");
                }
            }
            return View("EditMessage");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Message");
        }
    }
}