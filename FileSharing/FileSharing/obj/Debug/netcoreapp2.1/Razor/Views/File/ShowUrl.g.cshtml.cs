#pragma checksum "d:\C#\11-708_Exam\FileSharing\FileSharing\Views\File\ShowUrl.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d18183c61353ca19fb6ab604f1e587d36681d598"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_File_ShowUrl), @"mvc.1.0.view", @"/Views/File/ShowUrl.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/File/ShowUrl.cshtml", typeof(AspNetCore.Views_File_ShowUrl))]
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
#line 1 "d:\C#\11-708_Exam\FileSharing\FileSharing\Views\_ViewImports.cshtml"
using FileSharing;

#line default
#line hidden
#line 2 "d:\C#\11-708_Exam\FileSharing\FileSharing\Views\_ViewImports.cshtml"
using FileSharing.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d18183c61353ca19fb6ab604f1e587d36681d598", @"/Views/File/ShowUrl.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93a11bdab95aceb82ff30b58334a029eb76f806c", @"/Views/_ViewImports.cshtml")]
    public class Views_File_ShowUrl : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "d:\C#\11-708_Exam\FileSharing\FileSharing\Views\File\ShowUrl.cshtml"
  
    ViewData["Title"] = "ShowUrl";

#line default
#line hidden
            BeginContext(45, 26, true);
            WriteLiteral("\r\n<h2>ShowUrl</h2>\r\n<h3><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 71, "\"", 99, 1);
#line 7 "d:\C#\11-708_Exam\FileSharing\FileSharing\Views\File\ShowUrl.cshtml"
WriteAttributeValue("", 78, ViewData["shorturl"], 78, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(100, 2, true);
            WriteLiteral("> ");
            EndContext();
            BeginContext(103, 20, false);
#line 7 "d:\C#\11-708_Exam\FileSharing\FileSharing\Views\File\ShowUrl.cshtml"
                                Write(ViewData["shorturl"]);

#line default
#line hidden
            EndContext();
            BeginContext(123, 13, true);
            WriteLiteral("</a></h3>\r\n\r\n");
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
