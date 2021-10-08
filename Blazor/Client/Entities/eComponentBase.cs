using Blazored.Toast.Services;
using BrowserInterop.Extensions;
using BrowserInterop.Geolocation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using Blazor.Shared.Data;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor.Client.Services;

namespace Blazor.Client.Entities
{
    public class eComponentBase : ComponentBase
    {
        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService localStorage { set; get; }
        [Inject]
        protected NavigationManager Redirect { get; set; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Inject]
        protected HttpClient Server { get; set; }
        [Inject]
        protected IToastService Toast { get; set; }
        [Inject]
        protected AuthorizationService _AuthorizationService { get; set; }

        protected cUser User
        {
            get;
            set;
        }

        protected string ApplicationPath { get { return System.IO.Directory.GetCurrentDirectory() + @"\"; } }
        protected string ImgPath { get { return ApplicationPath + @"wwwroot\img\"; } }
        public bool RequiedLogin { private get; set; }
        public bool isLoading { get; private set; } = true;
        public bool Enabled { get; set; } = true;
        public bool IsOnline { get; set; }

        [JSInvokable("Connection.StatusChanged")]
        public void OnConnectionStatusChanged(bool isOnline)
        {
            IsOnline = isOnline;
        }

        protected virtual void OnPageInit()
        {

        }

        protected virtual Task OnPageLoad()
        {
            return Task.CompletedTask;
        }

        protected override async Task OnInitializedAsync()
        {
            OnPageInit();
            if (User == null && await localStorage.ContainKeyAsync("UserID"))
            {
                User = await Server.GetFromJsonAsync<cUser>("api/User/" + await localStorage.GetItemAsStringAsync("UserID"));
            }
            AccessControl();
            await OnPageLoad();
            isLoading = false;
            await JSRuntime.InvokeVoidAsync("Connection.Initialize", DotNetObjectReference.Create(this));
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender && await localStorage.ContainKeyAsync("UserID"))
            {

            }
        }

        private void AccessControl()
        {
            if (RequiedLogin && (User == null || !User.IsLogged))
            {
                Redirect.NavigateTo("/");
            }
        }

        protected async void Login(cUser user)
        {
            User = user;
            await localStorage.SetItemAsync("UserID", user.ID);
            _AuthorizationService.IsLogged = true;
            _AuthorizationService.NotifyChanged();
            StateHasChanged();
            Redirect.NavigateTo("/Backend");
          
        }

        protected async void Logout()
        {
            User = new cUser();
            await localStorage.RemoveItemAsync("UserID");
            _AuthorizationService.IsLogged = false;
            _AuthorizationService.NotifyChanged();
            StateHasChanged();
            Redirect.NavigateTo("/");
   
        }

        protected void ErrorConnection()
        {
            Toast.ShowError("Si sono verificati dei problemi, per favore riprova piu tardi");
        }

        protected async void Alert(string msg)
        {
            await JSRuntime.InvokeVoidAsync("Alert", msg);
        }
    }
}
