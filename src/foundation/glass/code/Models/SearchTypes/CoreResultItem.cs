using System.ComponentModel;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace Common.Foundation.Glass.Models.SearchTypes
{
    /// <summary>
    /// Extends standard SearchResultItem to include useful AE.Core computed field values as properties.
    /// </summary>
    public class CoreResultItem : SearchResultItem
    {
        [IndexField("micrositehomeid")]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        public ID MicroSiteHomeId { get; set; }

        [IndexField("nearesthomeid")]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        public ID NearestHomeId { get; set; }
    }
}
