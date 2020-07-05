using Glass.Mapper.Sc.Configuration.Attributes;
using Common.Foundation.Glass.Models.Fields;
using System;
using System.Collections.Generic;

namespace Common.Foundation.Glass.Models.Core.Abstract
{
    public partial interface ICorePage : ICoreFolder, IText, IMetaData
    {
        /// <summary>
        /// Lazy Load Url
        /// </summary>
        [SitecoreIgnore]
        String Url { get;set; }

        [SitecoreIgnore]
        List<String> MetaKeywordList{ get; set; }

    }
}