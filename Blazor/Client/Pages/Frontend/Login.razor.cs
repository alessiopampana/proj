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
    public partial class Login_Page : eComponentBase
    {
        protected string Email;
        protected string Password;

        protected async override void OnPageInit()
        {
            RequiedLogin = false;
            await JSRuntime.InvokeVoidAsync("setTitle", "Login");
        }

        protected async override Task OnPageLoad()
        {
    
        }

        public async void OnLogin()
        {
            cUser user = await Server.GetFromJsonAsync<cUser>("api/User/" + Email + "/" + Password);
            if (user.IsLogged)
            {
                Login(user);
            }
        }

        protected void Enter(KeyboardEventArgs e)
        {
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                OnLogin();
            }
        }
    }
}