using System.Web.Mvc;
using Common.Foundation.Glass.Models.Core.Abstract;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;

namespace Common.Foundation.Glass.Controllers
{
    /// <summary>
    /// Example Controller... For controller renderings, class does not need to extend SitecoreController
    /// </summary>
    public class PageController : Controller
    {

        private readonly IMvcContext _sitecoreService;
        public PageController(IMvcContext sitecoreService)
        {
            _sitecoreService = sitecoreService ?? throw new System.Exception(nameof(sitecoreService));
        }
        public ActionResult Detail()
        {
            var vm = _sitecoreService.GetContextItem<ICorePage>();
            return PartialView(vm);
        }

    }
}