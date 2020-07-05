using System;
using System.ComponentModel;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Common.Foundation.Glass.Models.Core.Abstract
{
    public partial interface ICoreInferred : ICoreGlass
    {

        [IndexField("_template")]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        ID TemplateId { get; set; }

        [IndexField("_name")]
        String Name { get; set; }
        
        /// <summary>
        /// Display Name - defaults to Name when DisplayName is Empty
        /// </summary>
        /// <returns></returns>
        [SitecoreIgnore]
        String DisplayName { get;set;}

        Item InnerItem { get; set; }

    }
}