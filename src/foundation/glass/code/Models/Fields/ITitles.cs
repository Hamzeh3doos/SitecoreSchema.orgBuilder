using System;

namespace Common.Foundation.Glass.Models.Fields
{
    public interface ITitles
    {
        String Title { get; set; }
        String ShortTitle { get; set; }
        String BreadcrumbTitle { get; set; }
    }
}
