using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Blazor.Client.Entities;
using Blazor.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Blazor.Pages
{
    public partial class Backend_Index_Page: eComponentBase
    {
        protected List<cSweet> Sweets = new List<cSweet>();

        protected async override void OnPageInit()
        {
            RequiedLogin = true;
            await JSRuntime.InvokeVoidAsync("setTitle", "Backoffice");
        }

        protected async override Task OnPageLoad()
        {
            Sweets = await Server.GetFromJsonAsync<List<cSweet>>("/api/Sweets");
        }

        protected void EditSweet(int ID)
        {
            Redirect.NavigateTo("/SweetInsert/" + ID);
        }

        protected void NewSweet()
        {
            Redirect.NavigateTo("/SweetInsert");
        }

        protected async void DeleteSweet(int ID)
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", "Sicuro di voler eliminare questo dolce?");
            if (confirmed)
            {
                var response = await Server.PostAsJsonAsync("api/Sweet/Delete", ID);
                if (response.IsSuccessStatusCode)
                {
                    Sweets = await Server.GetFromJsonAsync<List<cSweet>>("api/Sweets");
                    StateHasChanged();
                }
                else
                {
                    ErrorConnection();
                }
            }
        }
    }
}
