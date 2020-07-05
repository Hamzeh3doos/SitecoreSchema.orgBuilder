using System;
using Glass.Mapper.Sc.Configuration.Attributes;
using Common.Foundation.Glass.Models.Core.Abstract;

namespace Common.Foundation.Glass.Models.Core
{
    [SitecoreType(TemplateId = "{DEBFFA8B-565A-46CE-9D12-6C2A84C59011}")]
    public partial class CoreFolder : CoreDataItem, ICoreFolder
    {

        // ITitles
        public virtual String Title { get; set; }
        public virtual String ShortTitle { get; set; }
        public virtual String BreadcrumbTitle { get; set; }
    }
}