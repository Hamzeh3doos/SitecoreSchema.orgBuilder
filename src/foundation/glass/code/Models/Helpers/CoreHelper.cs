using Sitecore.Data.Items;
using Common.Foundation.Glass.Helpers;
using Common.Foundation.Glass.Models.Core;
using Common.Foundation.Glass.Models.Items;
using Common.Foundation.Utilities.Helpers;
using System;
using System.Linq;

namespace Common.Foundation.Glass.Models.Helpers
{
    public static class CoreHelper
    {

        /// <summary>
        /// Returns nearest CoreHome ancestor including self
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item NearestHome(Item item)
        {
            // SiteFolders belong to the site of it's home page
            if (item.UsesTemplate(typeof(SiteFolder)))
                item = item.Children.FirstOrDefault(i => i.UsesTemplate(typeof(CoreHome)));

            return NearestType(typeof(CoreHome), item);
        }

        /// <summary>
        /// Generic nearest item check by Glass Class, including self
        /// TemplateId is extracted from class attribute
        /// This is useful when dependency injection changes which templateId is used
        /// </summary>
        /// <param name="type"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item NearestType(Type type, Item item)
        {
            return ItemHelper.NearestType( GlassHelper.GetTemplateId(type), item );
        }

    }

}
