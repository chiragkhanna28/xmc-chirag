using Newtonsoft.Json.Linq;
using Sitecore.Data.Items;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;

namespace XmCloudSXAStarter.Resolvers
{
    public class FeaturedBlogResolver : RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            Item datasourceItem = this.GetContextItem(rendering, renderingConfig);
            if (datasourceItem == null)
                return null;
            JObject jobject = ProcessItem(datasourceItem, rendering, renderingConfig);
            List<Item> itemList = new List<Item>();
            Sitecore.Data.Fields.MultilistField featuredBlogs = datasourceItem.Fields["Featured Blogs"];
            if(featuredBlogs!=null && featuredBlogs.Count > 0)
            {
                foreach (Item featuredBlog in featuredBlogs.GetItems())
                {
                    itemList.Add(featuredBlog);
                }
            }
            jobject["items"] = ProcessItems(itemList, rendering, renderingConfig);
            return jobject;
        }
    }
}