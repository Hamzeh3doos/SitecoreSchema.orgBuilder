using Glass.Mapper.Sc;
using Sitecore.Mvc.Presentation;
using Common.Foundation.Glass.Models.Core;

namespace Common.Foundation.Glass.Models.ViewModels
{

    public class InferredItem : RenderingModel
    {
        public CoreInferred Inferred { get; set; }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            var contextItem = Rendering.Item; // AE.Core.PageContext.Current.DataItem
            var glassService = new SitecoreContext();
            Inferred = glassService.Cast<CoreInferred>(contextItem, true, true);

        }
    }
}
