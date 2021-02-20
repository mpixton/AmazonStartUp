using AmazonStartUp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonStartUp.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlhf)
        {
            _urlHelperFactory = urlhf;
        }

        /// <summary>
        /// Context of the view around the Tag Helper.
        /// </summary>
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// Object containing the Pagination information.
        /// </summary>
        public PagingInfo PageModel { get; set; }

        /// <summary>
        /// Action for the Tag to execute.
        /// </summary>
        public string PageAction { get; set; }

        /// <summary>
        /// Determines if the Tag Helper will use CSS to display each link.
        /// </summary>
        public bool PageClassesEnabled { get; set; } = false;

        /// <summary>
        /// CSS class to be applied to the Page control.
        /// </summary>
        public string PageClass { get; set; }

        /// <summary>
        /// CSS class to be applied to the links that are not selected.
        /// </summary>
        public string PageClassNormal { get; set; }

        /// <summary>
        /// CSS class to be applied to the link that is selected.
        /// </summary>
        public string PageClassSelected { get; set; }

        /// <summary>
        /// Processes the Tag Helper when the page is called.
        /// </summary>
        /// <param name="context">Context around the tag in the View.</param>
        /// <param name="output">HTML elements to be output.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            var result = new TagBuilder("div");

            // Loop through the total number of pages in the PageModel class.
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                // For each page, create a new a tag with the URL after the pattern /?page=i.
                var tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });

                // Checks if we have enabled extra CSS classes for our Tag Helper.
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                // Add the newly created a tag to the output.
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
