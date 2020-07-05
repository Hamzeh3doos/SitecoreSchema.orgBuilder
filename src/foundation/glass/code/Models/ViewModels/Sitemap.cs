using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc;
using Sitecore.Mvc.Presentation;
using Common.Foundation.Glass.Models.Items;
using Common.Foundation.Utilities.Core;
using Common.Foundation.Glass.Models.Core;

namespace Common.Foundation.Glass.Models.ViewModels
{
    public class Sitemap : InferredItem
    {
        public CoreHome HomePage { get; set; }
        public List<CoreHome> MicroSites { get; set; }
        public List<CoreFolder> ContentPages { get; set; }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            var glassService = new SitecoreContext();
            // Set Current Site's Home Page Item
            HomePage = glassService.Cast<CoreInferred>(DatabaseContext.GetItem(Sitecore.Context.Site.StartPath), true, true) as CoreHome;
            if (HomePage == null || !HomePage.Children.Any()) return;

            // Fill First level of content pages
            ContentPages = HomePage.Children.OfType<CoreFolder>().ToList();

            // Fill the Micro Sites
            var microSiteFolders = HomePage.Children.OfType<SiteFolder>().ToList();
            if (!microSiteFolders.Any())
                return;

            // Get home pages under Site Folder
            MicroSites = microSiteFolders.SelectMany(
                    f => f.Children.OfType<CoreHome>(),
                    (f, c) => c
                ).ToList();
        }
    }
}
