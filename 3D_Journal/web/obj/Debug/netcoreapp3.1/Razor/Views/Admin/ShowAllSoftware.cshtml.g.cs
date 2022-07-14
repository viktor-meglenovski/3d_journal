#pragma checksum "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\Admin\ShowAllSoftware.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e80583f447487d55ba3b3f9d2165e82a465baf99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ShowAllSoftware), @"mvc.1.0.view", @"/Views/Admin/ShowAllSoftware.cshtml")]
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
#line 1 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\_ViewImports.cshtml"
using web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\Admin\ShowAllSoftware.cshtml"
using domain.DomainModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e80583f447487d55ba3b3f9d2165e82a465baf99", @"/Views/Admin/ShowAllSoftware.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"315d961db4c149d0f65279ea3108021725a8da71", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ShowAllSoftware : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<domain.DomainModels.Software>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container border border-dark rounded col-8"">
    <h2 class=""text-center"">Show all software that is available for users to choose</h2>
    <hr />
    <table style=""width:100%;"" class=""tabela"">
        <thead>
            <tr>
                <th style=""width:40%;"">Software Name</th>
                <th style=""width:40%;"">Software Logo</th>
                <th style=""width:20%;""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 15 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\Admin\ShowAllSoftware.cshtml"
             foreach (Software s in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 18 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\Admin\ShowAllSoftware.cshtml"
                   Write(s.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><img class=\"thumbnail otherImages zoomInImages\"");
            BeginWriteAttribute("alt", " alt=\"", 723, "\"", 741, 2);
#nullable restore
#line 19 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\Admin\ShowAllSoftware.cshtml"
WriteAttributeValue("", 729, s.Name, 729, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 736, "Logo", 737, 5, true);
            EndWriteAttribute();
            WriteLiteral(" ,");
            BeginWriteAttribute("src", " src=\"", 744, "\"", 767, 1);
#nullable restore
#line 19 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\Admin\ShowAllSoftware.cshtml"
WriteAttributeValue("", 750, s.Logo.ImagePath, 750, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:75px;height:75px;\" /></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 836, "\"", 870, 2);
            WriteAttributeValue("", 843, "/Admin/DeleteSoftware/", 843, 22, true);
#nullable restore
#line 20 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\Admin\ShowAllSoftware.cshtml"
WriteAttributeValue("", 865, s.Id, 865, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">X</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 22 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\Admin\ShowAllSoftware.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
    <hr />
    <div class=""row mb-2"">
        <div class=""col-6"">
            <a href=""/Admin/AddSoftware"" class=""btn btn-success btn-lg btn-block"">Add a new Software</a>
        </div>
        <div class=""col-6"">
            <a href=""/Admin"" class=""btn btn-primary btn-lg btn-block"">Back to Administrator Panel</a>
        </div>
        </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $("".tabela"").DataTable({
                ""columns"": [
                    { ""name"": ""name"", ""orderable"": false },
                    { ""name"": ""picture"", ""orderable"": false },
                    { ""name"": ""delete"", ""orderable"": false }
                ],
                ""ordering"": false,
                ""bLengthChange"": false,
                ""searching"": false,
                ""pageLength"": 4,
                ""bInfo"": false
            });
            $(""#newSearchPlace"").html($("".dataTables_filter""));
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<domain.DomainModels.Software>> Html { get; private set; }
    }
}
#pragma warning restore 1591