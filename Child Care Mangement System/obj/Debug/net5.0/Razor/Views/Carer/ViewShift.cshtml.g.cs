#pragma checksum "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\Carer\ViewShift.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e16e690ed4356aa0eb3f7bde6bb27a8dda58ae9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carer_ViewShift), @"mvc.1.0.view", @"/Views/Carer/ViewShift.cshtml")]
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
#nullable restore
#line 1 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\_ViewImports.cshtml"
using Child_Care_Mangement_System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\_ViewImports.cshtml"
using Child_Care_Mangement_System.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e16e690ed4356aa0eb3f7bde6bb27a8dda58ae9c", @"/Views/Carer/ViewShift.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e99bc983b587276b6c6eb7181c09d02582e21d4f", @"/Views/_ViewImports.cshtml")]
    public class Views_Carer_ViewShift : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Child_Care_Mangement_System.Models.Shift>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\Carer\ViewShift.cshtml"
  
    ViewData["Title"] = "ViewShift";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <h1> Upcoming Shifts</h1>

    <table id=""Shifts"" class=""table"">
        <thead>
            <tr>
                <th>
                    Id
                </th>
                <th>
                    Date
                </th>
                <th>Available From</th>
                <th>Available To</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 23 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\Carer\ViewShift.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 27 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\Carer\ViewShift.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 30 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\Carer\ViewShift.cshtml"
                   Write(item.ShiftDate.Date.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 33 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\Carer\ViewShift.cshtml"
                   Write(item.From.TimeOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 36 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\Carer\ViewShift.cshtml"
                   Write(item.To.TimeOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 39 "C:\Users\kazi.alam\source\repos\Child Care Mangement System\Child Care Mangement System\Views\Carer\ViewShift.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    </div>\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#AvailableCarers\').DataTable();\r\n        });\r\n\r\n\r\n\r\n    </script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Child_Care_Mangement_System.Models.Shift>> Html { get; private set; }
    }
}
#pragma warning restore 1591
