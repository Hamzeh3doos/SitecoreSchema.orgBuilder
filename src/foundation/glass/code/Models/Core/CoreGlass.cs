using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Common.Foundation.Glass.Models.Core.Abstract;

namespace Common.Foundation.Glass.Models.Core
{
    /// <summary>
    /// Base Glass Class (http://glass.lu/docs/tutorial/index.html)
    /// that supports Page Editor (Tutorial 5) 
    /// and Sitecore Search API with Glass Inded Mapper (Tutorial 25)
    /// </summary>
    public partial class CoreGlass : ICoreGlass
    {
        [SitecoreId]
        [IndexField("_id")]
        public virtual ID Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        [IndexField("_language")]
        public virtual String Language { get; set; }

        [TypeConverter(typeof(IndexFieldItemUriValueConverter))]
        [XmlIgnore]
        [IndexField("_uniqueid")]
        public virtual ItemUri Uri { get; set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        public virtual int Version
        {
            get
            {
                return Uri == null ? 0 : Uri.Version.Number;
            }
        }
    }
}