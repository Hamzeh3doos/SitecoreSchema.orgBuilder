using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Common.Foundation.Glass.Models.Core.Abstract;
using System.Linq;

namespace Common.Foundation.Glass.Models.Core
{
    [SitecoreType(TemplateId = "{193B76AC-3430-4DD0-BC45-F05562D363CA}", AutoMap = true)]
    public partial class CoreDataItem : CoreInferred, ICoreDataItem
    {
        [SitecoreParent(InferType = true)]
        public virtual CoreInferred Parent { get; set; }

        /// <summary>
        /// Lazy Load Children
        /// </summary>
        [SitecoreChildren(InferType = true)]
        public IEnumerable<CoreInferred> InnerChildren { get; set; }

        private List<CoreDataItem> _children;
        [SitecoreIgnore]
        public List<CoreDataItem> Children {
            get {
                if (_children != null)
                    return _children;
                _children = InnerChildren == null ? new List<CoreDataItem>() : InnerChildren.OfType<CoreDataItem>().ToList();
                return _children;
            }
            set {
                InnerChildren = _children = value;
            }
        }

        /// <summary>
        /// Lazy Load Paths object
        /// </summary>
        [SitecoreIgnore]
        public ItemPath Paths {
            get { return this.InnerItem.Paths; }
        }

    }
}