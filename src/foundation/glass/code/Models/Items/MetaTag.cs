using Glass.Mapper.Sc.Configuration.Attributes;

namespace Common.Foundation.Glass.Models.Items
{
    [SitecoreType(TemplateId = "{01F9CA13-6721-4878-8574-4481487D4253}", AutoMap = true)]
    public class MetaTag
    {
        [SitecoreField(FieldName="Key")]
        public virtual string Key { get; set; }
        [SitecoreField(FieldName="Content")]
        public virtual string Content { get; set; }
    }
}