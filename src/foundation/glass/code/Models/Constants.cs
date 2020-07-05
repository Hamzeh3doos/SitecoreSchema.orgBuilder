using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;

namespace Common.Foundation.Glass.Models
{

    public static partial class Constants
    {
        #region Field IDs
        /// <summary>
        /// Field ID constants to limit typos and ease GUID changes
        /// </summary>
        public static partial class FieldIDs
        {
            public static readonly ID MetaTitle = new ID("{0CBCD7F7-7CE1-4A93-A0BA-4C119792AA6A}");
            public static readonly ID MetaDescription = new ID("{3B18B6A7-B8B7-40C7-9AA4-50BD4E0B980F}");
            public static readonly ID MetaKeywords = new ID("{0F9050FE-37C2-4944-875B-719A293829B3}");
            public static readonly ID MetaTags = new ID("{1FD9B331-796E-4048-A092-CCC36BDD40C7}");

        }
        #endregion


        #region Rendering IDs
        /// <summary>
        /// Rendering ID constants
        /// </summary>
        public static partial class RenderingIDs
        {
            public const string MetaData = "{DB735180-ED2F-48AA-844F-A0A46F8327C6}";
            public const string Sitemap = "{863AE5D7-36D5-4C0F-AF95-B9E48D00EEE1}";
            public const string InferredItem = "{1C85DD15-1390-49BE-87BC-8F126B06DCA4}";
        }
        #endregion
    }
}
