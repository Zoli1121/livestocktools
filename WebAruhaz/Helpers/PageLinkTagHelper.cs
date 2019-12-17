//-----------------------------------------------------------------------
// <copyright file="PageLinkTagHelper.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------
namespace WebAruhaz.Helpers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using WebAruhaz.Models.ViewModels.WebShopViewModels;

    /// <summary>
    /// Defines the <see cref="PageLinkTagHelper" />
    /// </summary>
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        /// <summary>
        /// Defines the urlHelperFactory
        /// </summary>
        private IUrlHelperFactory urlHelperFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageLinkTagHelper"/> class.
        /// </summary>
        /// <param name="helperFactory">The helperFactory<see cref="IUrlHelperFactory"/></param>
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        /// <summary>
        /// Gets or sets the ViewContext
        /// </summary>
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// Gets or sets the PageModel
        /// </summary>
        public PageViewModel PageModel { get; set; }

        /// <summary>
        /// Gets or sets the PageAction
        /// </summary>
        public string PageAction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether PageClassesEnabled
        /// </summary>
        public bool PageClassesEnabled { get; set; } = false;

        /// <summary>
        /// Gets or sets the PageClass
        /// </summary>
        public string PageClass { get; set; }

        /// <summary>
        /// Gets or sets the PageClassNormal
        /// </summary>
        public string PageClassNormal { get; set; }

        /// <summary>
        /// Gets or sets the PageClassSelected
        /// </summary>
        public string PageClassSelected { get; set; }

        /// <summary>
        /// The Process
        /// </summary>
        /// <param name="context">The context<see cref="TagHelperContext"/></param>
        /// <param name="output">The output<see cref="TagHelperOutput"/></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.Pages; i++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                var page = new { productPage = i };
                tagBuilder.Attributes["href"] = urlHelper.Action(PageAction, page);
                if (PageClassesEnabled)
                {
                    tagBuilder.AddCssClass(PageClass);
                    tagBuilder.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }

                tagBuilder.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tagBuilder);
            }
         
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
