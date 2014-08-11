using System.Web.Mvc;
using MrCMS.Helpers;
using MrCMS.Web.Apps.Ecommerce.Areas.Admin.ModelBinders;
using MrCMS.Web.Apps.Ecommerce.Areas.Admin.Services;
using MrCMS.Web.Apps.Ecommerce.Settings;
using MrCMS.Website.Binders;
using MrCMS.Website.Controllers;

namespace MrCMS.Web.Apps.Ecommerce.Areas.Admin.Controllers
{
    public class ShippingMethodController : MrCMSAppAdminController<EcommerceApp>
    {
        private readonly IShippingMethodAdminService _shippingMethodAdminService;

        public ShippingMethodController(IShippingMethodAdminService shippingMethodAdminService)
        {
            _shippingMethodAdminService = shippingMethodAdminService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(_shippingMethodAdminService.GetAll());
        }

        [HttpPost]
        public RedirectToRouteResult Index(
            [IoCModelBinder(typeof(ShippingMethodSettingsModelBinder))] ShippingMethodSettings settings)
        {
            _shippingMethodAdminService.UpdateSettings(settings);
            TempData.SuccessMessages().Add("Settings saved.");
            return RedirectToAction("Index");
        }
    }
}