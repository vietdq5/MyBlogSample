#pragma checksum "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Areas\Admin\Views\Shared\_LoginPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82aaded14ac9697f5664521a2fe1ad335cf96da3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__LoginPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_LoginPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/_LoginPartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared__LoginPartial))]
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
#line 1 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Areas\Admin\Views\Shared\_LoginPartial.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82aaded14ac9697f5664521a2fe1ad335cf96da3", @"/Areas/Admin/Views/Shared/_LoginPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b35857dd199098649926cf8d40cf1622e149676b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__LoginPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Areas\Admin\Views\Shared\_LoginPartial.cshtml"
  
    var userName = @Context.Session.GetString("UserName");
    var avatar = @Context.Session.GetString("UserAvatar");

#line default
#line hidden
            BeginContext(161, 506, true);
            WriteLiteral(@"
<!-- Topbar -->
<nav class=""navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow"">
    <!-- Topbar Navbar -->
    <ul class=""navbar-nav ml-auto"">
        <!-- Nav Item - User Information -->
        <li class=""nav-item dropdown no-arrow"">
            <a class=""nav-link dropdown-toggle"" href=""#"" id=""userDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                <span class=""mr-2 d-none d-lg-inline text-gray-600 small"">Hi Boss ");
            EndContext();
            BeginContext(668, 8, false);
#line 14 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Areas\Admin\Views\Shared\_LoginPartial.cshtml"
                                                                             Write(userName);

#line default
#line hidden
            EndContext();
            BeginContext(676, 64, true);
            WriteLiteral("</span>\r\n                <img class=\"img-profile rounded-circle\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 740, "\"", 767, 1);
#line 15 "C:\Users\vietdq5\Desktop\New folder\BlogGaoXanh\MyBlogSample\SieuNhanGaoBlog\Areas\Admin\Views\Shared\_LoginPartial.cshtml"
WriteAttributeValue("", 746, Url.Content(@avatar), 746, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(768, 1114, true);
            WriteLiteral(@" />
            </a>
            <!-- Dropdown - User Information -->
            <div class=""dropdown-menu dropdown-menu-right shadow animated--grow-in"" aria-labelledby=""userDropdown"">
                <a class=""dropdown-item"" href=""#"">
                    <i class=""fas fa-user fa-sm fa-fw mr-2 text-gray-400""></i>
                    Profile
                </a>
                <a class=""dropdown-item"" href=""#"">
                    <i class=""fas fa-cogs fa-sm fa-fw mr-2 text-gray-400""></i>
                    Settings
                </a>
                <a class=""dropdown-item"" href=""#"">
                    <i class=""fas fa-list fa-sm fa-fw mr-2 text-gray-400""></i>
                    Activity Log
                </a>
                <div class=""dropdown-divider""></div>
                <a class=""dropdown-item"" href=""#"" data-toggle=""modal"" data-target=""#logoutModal"">
                    <i class=""fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400""></i>
                    Logout
          ");
            WriteLiteral("      </a>\r\n            </div>\r\n        </li>\r\n    </ul>\r\n</nav>\r\n<!-- End of Topbar -->\r\n");
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
