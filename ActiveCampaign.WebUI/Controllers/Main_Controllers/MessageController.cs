using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Main_Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ActiveApi _activeService = new ActiveApi();

        public MessageController(IMessageRepository repository)
        {
            _messageRepository = repository;
        }

        public ActionResult Index()
        {
            return View("Messages", _messageRepository.Messages);
        }

        public ActionResult GetMessages(string id)
        {
            
        }

        public ActionResult ViewMessage(Message message)
        {
            
        }

        public ActionResult DeleteMessage(Message message)
        {
            _messageRepository.DeleteMessage(message.Id);
            return View("Messages");
        }

        public ActionResult CreateMessage()
        {
           return RedirectToAction("Index", "AddMessage");
        }
    }
}