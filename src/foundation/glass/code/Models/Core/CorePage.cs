using System;
using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Common.Foundation.Glass.Models.Core.Abstract;
using Common.Foundation.Glass.Models.Items;

namespace Common.Foundation.Glass.Models.Core
{

    [SitecoreType(TemplateId = "{75351283-E49B-408B-A605-8B394AF646B2}", AutoMap = true)]
    public partial class CorePage : CoreFolder, ICorePage
    {
        // IText
        public virtual String SummaryText { get; set; }
        public virtual String MainText { get; set; }
        public virtual String MoreLinkText { get; set; }

        // IMetaData
        public virtual String MetaTitle { get; set; }
        public virtual String MetaDescription { get; set; }
        public virtual String MetaKeywords { get; set; }
        public virtual IEnumerable<MetaTag> MetaTags { get; set; }
        private List<String> _metaKeywordList;
        
        private String _url = null;
        private Boolean _attemptedUrl = false;

        /// <summary>
        /// Lazy Load Url
        /// </summary>
        [SitecoreIgnore]
        public virtual String Url
        {
            get
            {
                if (_url == null && !_attemptedUrl)
                {
                    _attemptedUrl = true;
                    _url = Sitecore.Links.LinkManager.GetItemUrl(this.InnerItem);
                }
                return _url;
            }
            set
            {
                _url = value;
            }
        }


        [SitecoreIgnore]
        public virtual List<String> MetaKeywordList
        {
            get
            {
                if (_metaKeywordList != null)
                    return _metaKeywordList;

                _metaKeywordList = new List<String>();

                // Parse Field as list
                if (!String.IsNullOrWhiteSpace(this.MetaKeywords))
                { 
                    // Accept new line or comma separated
                    var rawList = this.MetaKeywords.Split(new string[] { Environment.NewLine, "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (var keyword in rawList)
                    {
                        _metaKeywordList.Add(keyword.Trim().ToLower());
                    }
                }

                return _metaKeywordList;
            }
            set { _metaKeywordList = new List<String>(value); }
        }

    }
}