using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Blazor.Client.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Shared.Data;
using Microsoft.Extensions.Logging;

namespace Blazor.Client.Pages
{
    public partial class SweetInsert_Page : eComponentBase
    {
        public cSweet CurrentSweet = new cSweet();

        [Parameter]
        public int? ID { set; get; }

        protected async override void OnPageInit()
        {
            RequiedLogin = true;
            await JSRuntime.InvokeVoidAsync("setTitle", "Event Edit");
        }

        protected async override Task OnPageLoad()
        {

            if (ID != null)
            {
                CurrentSweet = await Server.GetFromJsonAsync<cSweet>("api/Sweet/" + ID);
                CurrentSweet.Ingrediants = await Server.GetFromJsonAsync<List<cIngrediant>>("api/Ingrediants/" + ID);
            }
        }

        protected async void InsertSweet()
        {
            var response = await Server.PostAsJsonAsync("api/Sweet/Insert", CurrentSweet);
            if (response.IsSuccessStatusCode)
            {
                //response = await Server.PostAsJsonAsync("Event/Insert", currentEvent);
                //if (response.IsSuccessStatusCode)
                //{
                //    Toast.ShowSuccess("Salvataggio avvenuto con successo");
                //    Redirect.NavigateTo("/EventManager");
                //}
                //else
                //    ErrorConnection();
                Redirect.NavigateTo("/Backend");
            }
            else
                ErrorConnection();
        }

        protected void Back()
        {
            Redirect.NavigateTo("/Backend");
        }

        protected void AddIngredient()
        {
            CurrentSweet.Ingrediants.Add(new cIngrediant());
            StateHasChanged();
        }
    }
}
