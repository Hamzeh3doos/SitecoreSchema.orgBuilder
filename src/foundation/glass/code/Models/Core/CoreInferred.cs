using System;
using System.ComponentModel;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.Data.Items;
using Common.Foundation.Glass.Models.Core.Abstract;
using Common.Foundation.Utilities.Core;

namespace Common.Foundation.Glass.Models.Core
{
    [SitecoreType(TemplateId = "{7438E8D7-AC51-43AB-BFF5-CF0E7C816D11}", AutoMap = true)]
    public partial class CoreInferred : CoreGlass, ICoreInferred
    {

        [IndexField("_template")]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        public virtual ID TemplateId { get; set; }

        [IndexField("_name")]
        public virtual String Name { get; set; }

        [SitecoreInfo(SitecoreInfoType.DisplayName)]
        public virtual String InternalDisplayName { get; set; }

        [SitecoreItem]
        public virtual Item InnerItem { get; set; }

        /// <summary>
        /// Display Name - defaults to Name when DisplayName is Empty
        /// </summary>
        /// <returns></returns>
        [SitecoreIgnore]
        public String DisplayName
        {
            get
            {
                if (String.IsNullOrEmpty(InternalDisplayName))
                    return Name;
                return InternalDisplayName;
            }
            set
            {
                InternalDisplayName = value;
            }
        }
                
        /// <summary>
        /// Lazy load Related Sitecore Item
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use InnerItem property instead",false)]
        public Item AsItem()
        {
            return InnerItem;
        }

    }
}