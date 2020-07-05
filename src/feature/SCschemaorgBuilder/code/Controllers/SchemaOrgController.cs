using Glass.Mapper.Sc.Web.Mvc;
using SCschemaorg.feature.SCschemaorgBuilder.Models;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCschemaorg.feature.SCschemaorgBuilder.Controllers
{
    public class SchemaOrgController : Controller
    {
        private readonly IMvcContext _sitecoreService;
        public SchemaOrgController(IMvcContext sitecoreService)
        {
            _sitecoreService = sitecoreService ?? throw new System.Exception(nameof(sitecoreService));
        }
        public ActionResult SchemaOrg()
        {
            var viewModel = new SchemaViewModel();

            try
            {

                var Scope = _sitecoreService.GetDataSourceItem<SchemaScope>();

                if (Scope != null && Scope.SchemaProperties != null)
                {
                    UpdateSchemaProperties(Scope.SchemaProperties);
                    viewModel.Scope = Scope;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex, this);
            }

            return PartialView(viewModel);
        }

        private static void UpdateSchemaProperties(IEnumerable<SchemaProperty> schemaProperties)
        {
            ItemUrlBuilderOptions urlOptions = new ItemUrlBuilderOptions { AlwaysIncludeServerUrl = true, LanguageEmbedding = LanguageEmbedding.Never };

            MediaUrlBuilderOptions mediaurlOptions = new MediaUrlBuilderOptions();

            mediaurlOptions.AlwaysIncludeServerUrl = true;

            if (schemaProperties != null)
            {
                foreach (var item in schemaProperties)
                {
                    if (item.ItemScope)
                    {
                        UpdateSchemaProperties(item.Properties);
                    }
                    else
                    {
                        if (item.FieldType.Value == Constants.SchemaFieldTypes.CurrentItemURL)
                        {
                            item.FieldValue = LinkManager.GetItemUrl(Sitecore.Context.Item, urlOptions);
                        }
                        else if (item.FieldType.Value == Constants.SchemaFieldTypes.FromField)
                        {
                            item.FieldValue = Sitecore.Context.Item.Fields[item.FieldValue]?.Value;
                        }
                        else if (item.FieldType.Value == Constants.SchemaFieldTypes.FromParent)
                        {
                            item.FieldValue = Sitecore.Context.Item.Parent?.Fields[item.FieldType.Value]?.Value;
                        }
                        else if (item.FieldType.Value == Constants.SchemaFieldTypes.Image)
                        {
                            Sitecore.Data.Fields.ImageField imgField = Sitecore.Context.Item.Fields[item.FieldValue];

                            if (imgField != null)
                            {

                                var theURL = MediaManager.GetMediaUrl(imgField.MediaItem, mediaurlOptions);

                                item.FieldValue = HashingUtils.ProtectAssetUrl(theURL);

                            }
                        }
                    }
                }
            }
        }
    }
}