#pragma checksum "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\Tag\Tags.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0f4459b0917337f03db33c0471b1403e1fa109e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Tag_Tags), @"mvc.1.0.view", @"/Views/Shared/Components/Tag/Tags.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Tag/Tags.cshtml", typeof(AspNetCore.Views_Shared_Components_Tag_Tags))]
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
#line 1 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\_ViewImports.cshtml"
using SieuNhanGaoBlog;

#line default
#line hidden
#line 2 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\_ViewImports.cshtml"
using SieuNhanGaoBlog.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0f4459b0917337f03db33c0471b1403e1fa109e", @"/Views/Shared/Components/Tag/Tags.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96a26a6566f37069fbeeeb5b3c97770dc6673da2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Tag_Tags : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SieuNhanGao.Service.ViewModels.TagViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\Tag\Tags.cshtml"
  
    foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(109, 39, true);
            WriteLiteral("        <li class=\"list-inline-item\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 148, "\"", 174, 2);
            WriteAttributeValue("", 155, "/tags/", 155, 6, true);
#line 5 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\Tag\Tags.cshtml"
WriteAttributeValue("", 161, item.TagName, 161, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(175, 14, true);
            WriteLiteral(" class=\"tag\">#");
            EndContext();
            BeginContext(190, 12, false);
#line 5 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\Tag\Tags.cshtml"
                                                                           Write(item.TagName);

#line default
#line hidden
            EndContext();
            BeginContext(202, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 6 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Shared\Components\Tag\Tags.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SieuNhanGao.Service.ViewModels.TagViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
