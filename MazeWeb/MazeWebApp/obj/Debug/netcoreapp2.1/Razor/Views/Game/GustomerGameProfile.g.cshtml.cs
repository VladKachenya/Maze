#pragma checksum "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9db2ae5587771c937b4b79187e6e48822c356a8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_GustomerGameProfile), @"mvc.1.0.view", @"/Views/Game/GustomerGameProfile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Game/GustomerGameProfile.cshtml", typeof(AspNetCore.Views_Game_GustomerGameProfile))]
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
using MazeWebCore.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9db2ae5587771c937b4b79187e6e48822c356a8a", @"/Views/Game/GustomerGameProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"085c8bc44294328a48e047214f0870a7dbdf8c99", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_GustomerGameProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Customer>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
  
    ViewData["Title"] = "Gustomer game profile";

#line default
#line hidden
            BeginContext(74, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(81, 10, false);
#line 6 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(91, 11, true);
            WriteLiteral("</h2>\r\n<h5>");
            EndContext();
            BeginContext(103, 10, false);
#line 7 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(113, 8, true);
            WriteLiteral(" score: ");
            EndContext();
            BeginContext(122, 11, false);
#line 7 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
                  Write(Model.Score);

#line default
#line hidden
            EndContext();
            BeginContext(133, 94, true);
            WriteLiteral("</h5>\r\n<table class=\"table\">\r\n    <tr>\r\n        <td>#</td>\r\n        <td>Date</td>\r\n    </tr>\r\n");
            EndContext();
#line 13 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
     foreach (var game in Model.Games)
    {

#line default
#line hidden
            BeginContext(274, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(305, 7, false);
#line 16 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
           Write(game.Id);

#line default
#line hidden
            EndContext();
            BeginContext(312, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(336, 9, false);
#line 17 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
           Write(game.Date);

#line default
#line hidden
            EndContext();
            BeginContext(345, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 19 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
    }

#line default
#line hidden
            BeginContext(374, 10, true);
            WriteLiteral("</table>\r\n");
            EndContext();
#line 21 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
 using (Html.BeginForm("Play", "Game", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(445, 69, true);
            WriteLiteral("    <div >\r\n        <input type=\"hidden\" id=\"GamerId\" name=\"Gamer.Id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 514, "\"", 531, 1);
#line 24 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
WriteAttributeValue("", 522, Model.Id, 522, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(532, 87, true);
            WriteLiteral(" />\r\n        <input class=\"btn btn-success\" type=\"submit\" value=\"Play\" />\r\n    </div>\r\n");
            EndContext();
#line 27 "C:\Users\Vlad_UPR\Desktop\GitHub Repositores\Maze\MazeWeb\MazeWebApp\Views\Game\GustomerGameProfile.cshtml"
}

#line default
#line hidden
            BeginContext(622, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
