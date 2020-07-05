using System;
using System.Linq;
using Sitecore.Collections;
using Sitecore.ContentSearch.Security;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.SecurityModel;
using Common.Foundation.Glass.Helpers;
using Common.Foundation.Glass.Models.Core;
using Common.Foundation.Glass.Models.Core.Abstract;
using Common.Foundation.Glass.Models.Items;
using Common.Foundation.Glass.Models.SearchTypes;
using Common.Foundation.Utilities.Core;
using Common.Foundation.Utilities.Helpers;

namespace Common.Foundation.Glass.Models.Helpers
{
    public static class CoreExtensions
    {
        
        /// <summary>
        /// Helper function to return the nearest Core Section ancestor or self, if self is a Core Section and has children. Core Home is a Core Section.
        /// </summary>
        public static CoreSection NearestSection(this ICoreDataItem thisPage)
        {
            dynamic startPage = thisPage;

            // Traverse self and ancestors until a CoreSection is reached
            while (
                startPage.Parent is CoreDataItem    // Parent exists, was inferred, and...
                && (
                    !(startPage is CoreSection)     // either this is not a section page (home pages are also section pages)
                    ||                              // or this is a section page, but does not have any children (so go up to next section page)
                       startPage.Children == null
                    || startPage.Children.Count == 0
                )
            )
            {
                startPage = startPage.Parent; // Continue up the tree
            }

            return startPage as CoreSection;
        }


        /// <summary>
        /// Returns the first non-empty string from list of parameters
        /// </summary>
        /// <param name="model"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static String Coalesce(this CoreInferred model, params String[] values)
        {
            foreach (var val in values)
            {
                if (!String.IsNullOrWhiteSpace(val))
                    return val;
            }
            return String.Empty;
        }

        public static ID MicroSiteHomeId(this Item item)
        {
            ID id = null;

            if (Mode.IsRebuildingIndex())
            {
                // SiteFolders belong to the site of it's home page
                if (item.UsesTemplate(typeof (SiteFolder)))
                    item = item.Children.FirstOrDefault(i => i.UsesTemplate(typeof(CoreHome)));

                var home = CoreHelper.NearestHome(item);
                if (
                    home != null
                    && !home.Paths.FullPath.Equals(item.GetSite().StartPath, StringComparison.OrdinalIgnoreCase) // Micro site must be different than Site 
                )
                    id = home.ID;
            }
            else
            {
                using (new SecurityDisabler())
                {
                    var index = ContentSearchManager.GetIndex((SitecoreIndexableItem)item);
                    using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
                    {
                        var results = context.GetQueryable<CoreResultItem>()
                            .Where(i => i.ItemId == item.ID)
                            .GetResults();


                        if (results != null)
                        {
                            if (results.Hits.Any())
                            {
                                id = results.Hits.Select(x => x.Document.MicroSiteHomeId).FirstOrDefault();
                            }
                        }
                    }
                }
            }
            return id;

        }


    }

}
