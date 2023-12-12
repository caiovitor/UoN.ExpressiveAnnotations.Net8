using Microsoft.AspNetCore.Mvc;
using UoN.ExpressiveAnnotations.Net8Sample.Misc;

namespace UoN.ExpressiveAnnotations.Net8Sample.Controllers
{
    public class SystemController : Controller
    {
        public ActionResult SetCulture(string lang, string returnUrl)
        {
            CultureManager.Instance.Save(lang, HttpContext);
            return Redirect(returnUrl);
        }

        public ActionResult SetValidation(string type, string returnUrl)
        {
            ValidationManager.Instance.Save(type, HttpContext);
            return Redirect(returnUrl);
        }

        public ActionResult SetIndication(string value, string returnUrl)
        {
            IndicationsManager.Instance.Save(value, HttpContext);
            return Redirect(returnUrl);
        }

        [HttpPost]
        public JsonResult SetTriggers([FromBody] string events)
        {
            TriggersManager.Instance.Save(events, HttpContext);
            return Json(new {success = true});
        }

        [HttpPost]
        public JsonResult SetVerbosity([FromBody] bool value)
        {
            VerbosityManager.Instance.Save(value, HttpContext);
            return Json(new {success = true});
        }
    }
}