using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Blazor.Client.Entities;
using Blazor.Shared.Data;

namespace Blazor.Pages
{
    public partial class Logout_Page : eComponentBase
    {
        protected async override void OnPageInit()
        {
            RequiedLogin = true;
        }

        protected async override Task OnPageLoad()
        {
            Logout();
        }
    }
}