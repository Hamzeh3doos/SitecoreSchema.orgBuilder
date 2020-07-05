using System.Collections.Generic;
using Sitecore.Data;

namespace Common.Foundation.Glass.Models.Core.Abstract
{
    public partial interface ICoreDataItem : ICoreInferred
    {
        CoreInferred Parent { get; set; }
        
        List<CoreDataItem> Children { get; set; }
        
        ItemPath Paths { get; }

    }
}