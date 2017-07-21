using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using ActiveCampaign.WebUI.Helpers;

namespace ActiveCampaign.WebUI.Controllers.Edit_Controllers
{
    public class EditListController : Controller
    {
        private IListRepository _repository;
        ActiveApi _activeService = new ActiveApi();

        public EditListController(IListRepository listRepository)
        {
            _repository = listRepository;
        }

        public ActionResult Index(List list)
        {
            return View("EditList", list);
        }

        [HttpPost]
        public ActionResult EditList(List list)
        {
            list.Id = (string)TempData["Id"];
            TempData.Clear();
            if (ModelState.IsValid)
            {
                var result = _activeService.EditList(list);
                if (result)
                {
                    _repository.SaveList(list);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View("EditList", list);
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}