#pragma checksum "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\Maze\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bcfca952ebea16c908a624d69bf1e34c2247def"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Maze_Index), @"mvc.1.0.view", @"/Views/Maze/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Maze/Index.cshtml", typeof(AspNetCore.Views_Maze_Index))]
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
#line 1 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\_ViewImports.cshtml"
using MazeWebApp;

#line default
#line hidden
#line 2 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\_ViewImports.cshtml"
using MazeWebApp.Models;

#line default
#line hidden
#line 3 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\_ViewImports.cshtml"
using Dal.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bcfca952ebea16c908a624d69bf1e34c2247def", @"/Views/Maze/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"904bf6b11cdef8bf206de2f59ae5dac8aff13d45", @"/Views/_ViewImports.cshtml")]
    public class Views_Maze_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<char[,]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\Maze\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(104, 37, true);
            WriteLiteral("\r\n<h2>Game controller</h2>\r\n<table>\r\n");
            EndContext();
#line 9 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\Maze\Index.cshtml"
     for (int y = 0; y < Model.GetUpperBound(0) + 1; y++)
    {

#line default
#line hidden
            BeginContext(207, 26, true);
            WriteLiteral("        <tr class=\"row\">\r\n");
            EndContext();
#line 12 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\Maze\Index.cshtml"
             for (int x = 0; x < Model.GetUpperBound(1) + 1; x++)
            {

#line default
#line hidden
            BeginContext(315, 33, true);
            WriteLiteral("                <td class=\"cell\">");
            EndContext();
            BeginContext(349, 11, false);
#line 14 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\Maze\Index.cshtml"
                            Write(Model[y, x]);

#line default
#line hidden
            EndContext();
            BeginContext(360, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 15 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\Maze\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(382, 15, true);
            WriteLiteral("        </tr>\r\n");
            EndContext();
#line 17 "C:\Users\VlAD\Desktop\EpamTasks\Maze\MazeWeb\MazeWebApp\Views\Maze\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(404, 10, true);
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<char[,]> Html { get; private set; }
    }
}
#pragma warning restore 1591