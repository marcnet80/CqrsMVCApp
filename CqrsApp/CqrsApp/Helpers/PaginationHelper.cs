using System.Web.Mvc;

namespace CqrsApp.Helpers
{
    public static class PaginationHelper
    {
        public static MvcHtmlString CreatePagination(this HtmlHelper html, int itemsCount)
        {
            TagBuilder result = new TagBuilder("div");
            result.AddCssClass("btn-group");
            for (int i = 0; i <= itemsCount; i++)
            {
                var page = i + 1;
                TagBuilder link = new TagBuilder("a");
                link.AddCssClass("btn-primary btn");
                link.Attributes.Add("href", "Page" + page);
                link.SetInnerText(page.ToString());
                result.InnerHtml += link.ToString();
            }
            return new MvcHtmlString(result.ToString());
        }
    }
}