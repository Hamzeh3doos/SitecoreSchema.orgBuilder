using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCschemaorg.feature.SCschemaorgBuilder.Models
{
    [SitecoreType(TemplateId = "{0BB02A82-E7BA-4742-8CB7-8AF2BC83FAB3}", AutoMap = true)]
    public class SchemaProperty 
    {
        [SitecoreField("Item Scope")]
        public virtual bool ItemScope { get; set; }

        [SitecoreField("Item Prop")]
        public virtual string ItemProp { get; set; }

        [SitecoreField("Field Type")]
        public virtual Field FieldType { get; set; }

        [SitecoreField("Field Value")]
        public virtual string FieldValue { get; set; }

        [SitecoreChildren(InferType = true)]
        public virtual IEnumerable<SchemaProperty> Properties { get; set; }
    }
}