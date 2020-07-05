using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCschemaorg.feature.SCschemaorgBuilder.Models
{
    [SitecoreType(TemplateId = "{3D86530B-1088-4519-B8AB-B0BCD4C0D819}", AutoMap = true)]
    public class SchemaScope 
    {
        [SitecoreChildren(InferType = true)]
        public virtual IEnumerable<SchemaProperty> SchemaProperties { get; set; }
    }
}