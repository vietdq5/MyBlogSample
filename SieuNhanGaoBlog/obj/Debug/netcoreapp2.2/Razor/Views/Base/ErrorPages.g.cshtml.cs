#pragma checksum "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Base\ErrorPages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e69611591b13eff6c7852c3af4d7a1759d231c6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Base_ErrorPages), @"mvc.1.0.view", @"/Views/Base/ErrorPages.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Base/ErrorPages.cshtml", typeof(AspNetCore.Views_Base_ErrorPages))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e69611591b13eff6c7852c3af4d7a1759d231c6c", @"/Views/Base/ErrorPages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96a26a6566f37069fbeeeb5b3c97770dc6673da2", @"/Views/_ViewImports.cshtml")]
    public class Views_Base_ErrorPages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Base\ErrorPages.cshtml"
  
    ViewData["Title"] = "ErrorPages";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(95, 31, true);
            WriteLiteral("<h1>ErrorPages</h1>\r\n<h2>\r\n    ");
            EndContext();
            BeginContext(127, 20, false);
#line 8 "C:\Users\hello\Desktop\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Views\Base\ErrorPages.cshtml"
Write(ViewBag.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(147, 11, true);
            WriteLiteral("\r\n</h2>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
