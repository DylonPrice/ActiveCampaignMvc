using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Main_Controllers
{
    public class MessageController : Controller
    {   
        private readonly IMessageRepository _repository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public MessageController(IMessageRepository messageRepo)
        {
            _repository = messageRepo;
        }

        public ActionResult Index()
        {
            return View("Messages", _repository.Messages);
        }

        // Currently fails to see any existing messages.
        // Messages do not show up on their end either.
        public ActionResult GetMessages(string id)
        {
            if (Request["messageId"] != null)
            {
                id = Request["messageId"];
            }
            _repository.ClearMessages();
            var messages = _activeService.GetMessages(id);

            foreach (var message in messages)
            {
                _repository.SaveMessage(message);
            }

            return View("Messages", _repository.Messages);
        }

        public ActionResult EditMessage(Message message)
        {
            return RedirectToAction("Index", "EditMessage", message);
        }

        public ActionResult DeleteMessage(Message message)
        {
            var result = _activeService.DeleteMessage(message);
            if (result)
            {
                _repository.DeleteMessage(message.Id);
                return View("Messages", _repository.Messages);
            }
            return View("Messages", _repository.Messages);
        }

        public ActionResult CreateMessage()
        {
           return RedirectToAction("Index", "AddMessage");
        }
    }
}