using System;
using System.Collections.Generic;
using Common.Foundation.Glass.Models.Items;

namespace Common.Foundation.Glass.Models.Fields
{
    public interface IMetaData
    {
        String MetaTitle { get; set; }
        String MetaDescription { get; set; }
        String MetaKeywords { get; set; }
        IEnumerable<MetaTag> MetaTags { get; set; }
    }
}
