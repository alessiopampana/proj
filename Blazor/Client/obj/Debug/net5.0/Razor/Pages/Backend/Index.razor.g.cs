#pragma checksum "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23f236f92df6e761b4fe6d5266c604c828585faf"
// <auto-generated/>
#pragma warning disable 1591
namespace Blazor.Client.Pages.Backend
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazor.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazor.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazor.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazor.Shared.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazor.Client.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazored.Toast.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\_Imports.razor"
using Blazor.Client.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Backend/")]
    public partial class Index : Backend_Index_Page
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.OpenElement(1, "button");
            __builder.AddAttribute(2, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
                      NewSweet

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "class", "btn btn-primary");
            __builder.AddContent(4, "Nuovo dolce");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "mt-2");
#nullable restore
#line 9 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
     if (Sweets.Count == 0)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(8, "<span class=\"mt-2\">Nessun dolce presente</span>");
#nullable restore
#line 12 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "form-row");
#nullable restore
#line 16 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
             foreach (cSweet obj in Sweets)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "card col-lg-3");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "card-body");
            __builder.OpenElement(15, "h5");
            __builder.AddAttribute(16, "class", "card-title");
            __builder.AddContent(17, 
#nullable restore
#line 20 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
                                                obj.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                    ");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "card-footer");
            __builder.OpenElement(21, "button");
            __builder.AddAttribute(22, "class", "btn btn-outline-info btn-b");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
                                                                             () => EditSweet(obj.ID)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(24, "<i class=\"fas fa-edit\"></i><br>Modifica");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n                        ");
            __builder.OpenElement(26, "button");
            __builder.AddAttribute(27, "class", "btn btn-outline-primary btn-b");
            __builder.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
                                                                                () => DeleteSweet(obj.ID)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(29, "<i class=\"fas fa-trash-alt\"></i><br>Elimina");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 27 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 29 "C:\Users\WEBCOMWS001\Desktop\Esercizio\Blazor\Client\Pages\Backend\Index.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
