#pragma checksum "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d854bdfcaad0e857628c6f4dd98f862e1dbf9333"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyProfile_Index), @"mvc.1.0.view", @"/Views/MyProfile/Index.cshtml")]
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
#line 2 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
using domain.DomainModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d854bdfcaad0e857628c6f4dd98f862e1dbf9333", @"/Views/MyProfile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"315d961db4c149d0f65279ea3108021725a8da71", @"/Views/_ViewImports.cshtml")]
    public class Views_MyProfile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<domain.Identity.AppUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/defaultProfilePicture.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:300px;height:300px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("profilePictureImage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("zoomInImages profilePicture"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container-fluid border border-dark rounded col-10\">\r\n    <div class=\"row mt-2 p-3\">\r\n        <div class=\"col-4 text-center profileInfoContainter\">\r\n            <div class=\"whiteBg roundedCorners\">\r\n                <h2>");
#nullable restore
#line 7 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
               Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 7 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                                Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <hr />\r\n");
#nullable restore
#line 9 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                 if (Model.ProfileImage == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d854bdfcaad0e857628c6f4dd98f862e1dbf93335679", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img");
            BeginWriteAttribute("src", " src=\"", 671, "\"", 706, 1);
#nullable restore
#line 15 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
WriteAttributeValue("", 677, Model.ProfileImage.ImagePath, 677, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:300px;height:300px;\" id=\"profilePictureImage\" class=\"profilePicture zoomInImages\">\r\n");
#nullable restore
#line 16 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <hr />\r\n                <h2>");
#nullable restore
#line 19 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
               Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <hr />\r\n                <div class=\"row\">\r\n                    <h3 class=\"col-8 text-left\">Total Projects:</h3>\r\n                    <h3 class=\"col-4 text-right\">");
#nullable restore
#line 23 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                                            Write(Model.Projects.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                    <h3 class=\"col-8 text-left\">Total Likes:</h3>\r\n");
#nullable restore
#line 26 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                      
                        var x = 0;
                        foreach (var p in Model.Projects)
                        {
                            x += p.LikedByUsers.Count;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3 class=\"col-4 text-right\">");
#nullable restore
#line 32 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                                                Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
            WriteLiteral(@"                </div>
                <hr />
                <a href=""/Account/EditProfile"" class=""btn btn-primary btn-lg btn-block"">Edit Profile</a>
            </div>
        </div>
        <div class=""col-8 profileInfoContainter"">
            <div class=""whiteBg roundedCorners"">
                <h2 class=""text-center"">My 3D Art Projects</h2>
                <hr />
");
#nullable restore
#line 43 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                 if (Model.Projects.Count == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h3 class=\"text-center text-danger\">No projects available :(</h3>\r\n                    <hr />\r\n");
#nullable restore
#line 47 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""roundedCorners"" style=""margin-bottom:15px;"">
                        <table id=""dataTable"" class=""row-border"">
                            <thead>
                                <tr style=""border-bottom:1px solid black"" ; width:100%;>
                                    <th style=""width:15%"">Name</th>
                                    <th style=""width:25%"">Preview</th>
                                    <th style=""width:10%"">Price</th>
                                    <th style=""width:15%"">Likes</th>
                                    <th style=""width:25%""></th>
                                    <th style=""width:20%""></th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 63 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                                 foreach (Project p in @Model.Projects)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr style=\"border-bottom:1px solid black\">\r\n                                        <td>");
#nullable restore
#line 66 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                                       Write(p.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td><img class=\"otherImagesWithRatio zoomInImages\"");
            BeginWriteAttribute("alt", " alt=", 3237, "", 3249, 1);
#nullable restore
#line 67 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
WriteAttributeValue("", 3242, p.Name, 3242, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=", 3249, "", 3276, 1);
#nullable restore
#line 67 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
WriteAttributeValue("", 3254, p.MainImage.ImagePath, 3254, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"border:1px solid #d3d3d3; border-radius:10%; width:100px; height:100px;\" /></td>\r\n                                        <td>$");
#nullable restore
#line 68 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                                        Write(p.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 69 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                                       Write(p.LikedByUsers.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 3544, "\"", 3570, 2);
            WriteAttributeValue("", 3551, "/Project/View/", 3551, 14, true);
#nullable restore
#line 70 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
WriteAttributeValue("", 3565, p.Id, 3565, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success btn-size\">View details</a></td>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 3674, "\"", 3700, 2);
            WriteAttributeValue("", 3681, "/Project/Edit/", 3681, 14, true);
#nullable restore
#line 71 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
WriteAttributeValue("", 3695, p.Id, 3695, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning text-white btn-size btn-block mb-2\">Edit</a> <a");
            BeginWriteAttribute("imgUrl", " imgUrl=\"", 3772, "\"", 3803, 1);
#nullable restore
#line 71 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
WriteAttributeValue("", 3781, p.MainImage.ImagePath, 3781, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("projectName", " projectName=\"", 3804, "\"", 3825, 1);
#nullable restore
#line 71 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
WriteAttributeValue("", 3818, p.Name, 3818, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("path", " path=\"", 3826, "\"", 3854, 2);
            WriteAttributeValue("", 3833, "/Project/Delete/", 3833, 16, true);
#nullable restore
#line 71 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
WriteAttributeValue("", 3849, p.Id, 3849, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-size deleteButton text-white btn-block\">Delete</a></td>\r\n                                    </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n");
#nullable restore
#line 77 "C:\Users\Viktor Meglenovski\Desktop\3D_Journal\3D_Journal\web\Views\MyProfile\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a href=\"/Project/Create\" class=\"btn btn-success btn-lg btn-block\">Add a new Project</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $("".deleteButton"").click(function () {
                var link = $(this);
                bootbox.confirm({
                    title: ""<h4 class='text-center'>Are you sure that you want to delete the following project?</h4>"",
                    message: ""<span><h3 style='display:inline-block;' class='text-center'>"" + link.attr('projectName') + ""</h3> <img style='display:inline-block; width:100%;' class='otherImagesWithRatio thumbnail' src="" + link.attr('imgUrl') + "" /></span>"",
                    callback: function (result) {
                        if (result) {
                            window.location.href = link.attr('path');
                        }
                    }
                });
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(""#dataTable"").DataTable({
                ""columns"": [
                    { ""name"": ""name"", ""orderable"": true },
 ");
                WriteLiteral(@"                   { ""name"": ""preview"", ""orderable"": false },
                    { ""name"": ""price"", ""orderable"": true },
                    { ""name"": ""likes"", ""orderable"": true },
                    { ""name"": ""detailsBtn"", ""orderable"": false },
                    { ""name"": ""editDeleteBtn"", ""orderable"": false }
                ],
                ""bLengthChange"": false,
                ""searching"": false,
                ""pageLength"": 4,
                ""bInfo"": false
            });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<domain.Identity.AppUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
