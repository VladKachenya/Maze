#pragma checksum "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19aae0e417ea2f0117683afe8f19c246dfc372ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Index), @"mvc.1.0.view", @"/Views/Game/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Game/Index.cshtml", typeof(AspNetCore.Views_Game_Index))]
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
#line 1 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\_ViewImports.cshtml"
using MazeWebApp;

#line default
#line hidden
#line 2 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\_ViewImports.cshtml"
using MazeWebApp.Models;

#line default
#line hidden
#line 3 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\_ViewImports.cshtml"
using Dal.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19aae0e417ea2f0117683afe8f19c246dfc372ea", @"/Views/Game/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"904bf6b11cdef8bf206de2f59ae5dac8aff13d45", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Game>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\Index.cshtml"
  
    ViewData["Title"] = "Game Page";

#line default
#line hidden
            BeginContext(64, 89, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <tr>\r\n        <td>#</td>\r\n        <td>Date</td>\r\n    </tr>\r\n");
            EndContext();
#line 11 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\Index.cshtml"
     foreach (var game in Model)
    {

#line default
#line hidden
            BeginContext(194, 22, true);
            WriteLiteral("    <tr>\r\n        <td>");
            EndContext();
            BeginContext(217, 7, false);
#line 14 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\Index.cshtml"
       Write(game.Id);

#line default
#line hidden
            EndContext();
            BeginContext(224, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(244, 9, false);
#line 15 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\Index.cshtml"
       Write(game.Date);

#line default
#line hidden
            EndContext();
            BeginContext(253, 18, true);
            WriteLiteral("</td>\r\n    </tr>\r\n");
            EndContext();
#line 17 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(278, 8, true);
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Game>> Html { get; private set; }
    }
}
#pragma warning restore 1591
