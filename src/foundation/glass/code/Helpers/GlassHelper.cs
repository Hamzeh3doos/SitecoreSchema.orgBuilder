using System;
using System.Linq;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Sitecore.Data.Items;
using Common.Foundation.Utilities.Helpers;

namespace Common.Foundation.Glass.Helpers
{
    public static class GlassHelper
    {

        /// <summary>
        /// Helper function to return the Template ID from a glass class
        /// </summary>
        public static String GetTemplateId(Type type)
        {
            var attribute =
                type.GetCustomAttributes(typeof (SitecoreTypeAttribute), true).Cast<SitecoreTypeAttribute>().FirstOrDefault();
            return attribute == null ? null : attribute.TemplateId;
        }


        // Shortcut, Get template by type
        public static bool UsesTemplate(this Item item, Type type)
        {
            var templateId = GlassHelper.GetTemplateId(type);
            if (templateId == null)
                return false;

            return ItemHelper.ItemUsesTemplate(item, new ID(templateId));
        }

    }
}
