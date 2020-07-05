using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCschemaorg.feature.SCschemaorgBuilder.Models
{
    [SitecoreType(TemplateId = "{AD9482E1-D864-4311-B5B7-BBC646D25D61}", AutoMap = true)]
    public class Field 
    {
        public virtual string Value { get; set; }
    }
}