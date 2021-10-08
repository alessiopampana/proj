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
    public partial class Index_Page: eComponentBase
    {
        protected List<cSweet> Sweets = new List<cSweet>();

        protected async override void OnPageInit()
        {
            RequiedLogin = false;
            await JSRuntime.InvokeVoidAsync("setTitle", "Home");
        }

        protected async override Task OnPageLoad()
        {
            Sweets = await Server.GetFromJsonAsync<List<cSweet>>("/api/Sweets");
            for (int i = Sweets.Count - 1; i >= 0; i--)
            {
                cSweet s = Sweets[i];
                s.Ingrediants = await Server.GetFromJsonAsync<List<cIngrediant>>("api/Ingrediants/" + s.ID);
                if (s.Date.AddDays(1) < DateTime.Now)
                {
                    TimeSpan t = DateTime.Now - s.Date;
                    if (t.Days == 1)
                    {
                        s.Price = s.Price * (8.0 / 10.0);
                    }
                    else if (t.Days == 2)
                    {
                        s.Price = s.Price * (2.0 / 10.0);
                    }
                    else
                    {
                        var response = await Server.PostAsJsonAsync("/api/Sweet/Delete", s.ID);
                        if(response.IsSuccessStatusCode)
                        {
                            Sweets.RemoveAt(i);
                        }
                    }
                }
            }
            StateHasChanged();
        }
    }
}
