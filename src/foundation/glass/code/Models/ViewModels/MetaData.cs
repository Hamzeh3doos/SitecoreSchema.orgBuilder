using Sitecore.Mvc.Presentation;
using Common.Foundation.Glass.Models.Items;
using Common.Foundation.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Web;

namespace Common.Foundation.Glass.Models.ViewModels
{
    public class MetaData : RenderingModel
    {
        public String BrowserTitle { get; private set; }
        public String Keywords { get; private set; }
        public String Description { get; private set; }
        public List<MetaTag> MetaTags { get; private set; }
        public String Canonical { get; private set; }


        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            LoadData();
        }

        private void LoadData()
        {
            // TODO: Apply PageContext
            BrowserTitle = HttpUtility.HtmlEncode(Rendering.Item[Constants.FieldIDs.MetaTitle]);

            Description = HttpUtility.HtmlEncode(Rendering.Item[Constants.FieldIDs.MetaDescription]);

            // TODO: Handle MetaTags
            MetaTags = new List<MetaTag>(); // PageContext.MetaTags;

            Keywords = HttpUtility.HtmlEncode(String.Join(",", Rendering.Item[Constants.FieldIDs.MetaKeywords]));

            Canonical = HttpUtility.HtmlEncode(Sitecore.Links.LinkManager.GetItemUrl(Rendering.Item, new Sitecore.Links.UrlOptions() { AlwaysIncludeServerUrl = true }).ToLower());
        }


    }
}
