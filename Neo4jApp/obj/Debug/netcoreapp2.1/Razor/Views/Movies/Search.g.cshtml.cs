#pragma checksum "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e639145f5f0a03a02d0858bc1020c7a552cc08b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Search), @"mvc.1.0.view", @"/Views/Movies/Search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Movies/Search.cshtml", typeof(AspNetCore.Views_Movies_Search))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\_ViewImports.cshtml"
using Neo4jApp.Models;

#line default
#line hidden
#line 2 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\_ViewImports.cshtml"
using Neo4jApp.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e639145f5f0a03a02d0858bc1020c7a552cc08b9", @"/Views/Movies/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ffc4d8059c66ae19a724a2e9f7691b4812d3c09", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MoviesSearchViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/placeholder.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Card image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 23, true);
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n");
            EndContext();
#line 5 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
     if (Model.Movies != null)
    {
        

#line default
#line hidden
#line 7 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
         foreach (var movie in Model.Movies)
        {

#line default
#line hidden
            BeginContext(149, 127, true);
            WriteLiteral("            <div class=\"col-xl-2 col-lg-3 col-md-4 col-sm-6 col-6\">\r\n                <div class=\"card\">\r\n                    \r\n");
            EndContext();
#line 12 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
                   if (@movie.Poster == "N/A")
                   {

#line default
#line hidden
            BeginContext(344, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d42df49435ba43f9a7ad057df9b8f61b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
#line 13 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
                                                                                              }
                   else
                   {

#line default
#line hidden
            BeginContext(466, 25, true);
            WriteLiteral("<img class=\"card-img-top\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 491, "\"", 510, 1);
#line 15 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
WriteAttributeValue("", 497, movie.Poster, 497, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(511, 18, true);
            WriteLiteral(" alt=\"Card image\">");
            EndContext();
#line 15 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
                                                                                   }

#line default
#line hidden
            BeginContext(532, 172, true);
            WriteLiteral("                  \r\n                    <div class=\"card-body\" style=\"text-align: center;  padding: 3px; padding-top:10px\">\r\n                        <h6 class=\"card-title\">");
            EndContext();
            BeginContext(705, 11, false);
#line 18 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
                                          Write(movie.Title);

#line default
#line hidden
            EndContext();
            BeginContext(716, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(719, 10, false);
#line 18 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
                                                        Write(movie.Year);

#line default
#line hidden
            EndContext();
            BeginContext(729, 34, true);
            WriteLiteral(")</h6>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 763, "\"", 799, 2);
            WriteAttributeValue("", 770, "/Movies/Details/", 770, 16, true);
#line 19 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
WriteAttributeValue("", 786, movie.imdbID, 786, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(800, 130, true);
            WriteLiteral(" class=\"btn btn-primary stretched-link\">View Details</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 23 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
        }

#line default
#line hidden
#line 23 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
         
    }
    else
    {

#line default
#line hidden
            BeginContext(965, 35, true);
            WriteLiteral("        <h3>No results found</h3>\r\n");
            EndContext();
#line 28 "C:\Users\mlade\source\repos\Neo4jApp\Neo4jApp\Views\Movies\Search.cshtml"
    }

#line default
#line hidden
            BeginContext(1007, 10, true);
            WriteLiteral("</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MoviesSearchViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591