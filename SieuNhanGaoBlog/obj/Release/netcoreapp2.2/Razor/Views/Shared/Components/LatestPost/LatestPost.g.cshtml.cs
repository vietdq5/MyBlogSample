#pragma checksum "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\LatestPost\LatestPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27051e29bbe13d41d7383a7b35717d73cdd4f78a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_LatestPost_LatestPost), @"mvc.1.0.view", @"/Views/Shared/Components/LatestPost/LatestPost.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/LatestPost/LatestPost.cshtml", typeof(AspNetCore.Views_Shared_Components_LatestPost_LatestPost))]
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
#line 1 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\_ViewImports.cshtml"
using SieuNhanGaoBlog;

#line default
#line hidden
#line 2 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\_ViewImports.cshtml"
using SieuNhanGaoBlog.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27051e29bbe13d41d7383a7b35717d73cdd4f78a", @"/Views/Shared/Components/LatestPost/LatestPost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96a26a6566f37069fbeeeb5b3c97770dc6673da2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_LatestPost_LatestPost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SieuNhanGao.Service.ViewModels.PostViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\LatestPost\LatestPost.cshtml"
  
    foreach (var item in Model)
    {
        var url = "/" + item.Alias + "-post." + item.Id + ".html";

#line default
#line hidden
            BeginContext(180, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 190, "\"", 201, 1);
#line 7 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\LatestPost\LatestPost.cshtml"
WriteAttributeValue("", 197, url, 197, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(202, 124, true);
            WriteLiteral(">\r\n            <div class=\"item d-flex align-items-center\">\r\n\r\n                <div class=\"image\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 326, "\"", 361, 1);
#line 11 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\LatestPost\LatestPost.cshtml"
WriteAttributeValue("", 332, Url.Content(@item.Thumbnail), 332, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(362, 120, true);
            WriteLiteral(" alt=\"...\" class=\"img-fluid\">\r\n                </div>\r\n                <div class=\"title\">\r\n                    <strong>");
            EndContext();
            BeginContext(483, 10, false);
#line 14 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\LatestPost\LatestPost.cshtml"
                       Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(493, 139, true);
            WriteLiteral("</strong>\r\n                    <div class=\"d-flex align-items-center\">\r\n                        <div class=\"views\"><i class=\"icon-eye\"></i>");
            EndContext();
            BeginContext(633, 14, false);
#line 16 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\LatestPost\LatestPost.cshtml"
                                                              Write(item.ViewCount);

#line default
#line hidden
            EndContext();
            BeginContext(647, 94, true);
            WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </a>\r\n");
            EndContext();
#line 21 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\LatestPost\LatestPost.cshtml"
    }

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SieuNhanGao.Service.ViewModels.PostViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
