using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;

namespace Common.Foundation.Glass.Models.Core.Abstract
{
    /// <summary>
    /// Base Glass Class (http://glass.lu/docs/tutorial/index.html)
    /// that supports Page Editor (Tutorial 5) 
    /// and Sitecore Search API with Glass Index Mapper (Tutorial 25)
    /// </summary>
    public partial interface ICoreGlass
    {
        [SitecoreId]
        [IndexField("_id")]
        ID Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        [IndexField("_language")]
        String Language { get; set; }

        [TypeConverter(typeof(IndexFieldItemUriValueConverter))]
        [XmlIgnore]
        [IndexField("_uniqueid")]
        ItemUri Uri { get; set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        int Version { get; }
    }
}