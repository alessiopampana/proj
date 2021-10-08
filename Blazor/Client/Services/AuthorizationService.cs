using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Client.Services
{
    public class AuthorizationService
    {
        public bool IsLogged { get; set; }
        public event EventHandler<EventArgs> OnChanged;
        public void NotifyChanged() {
            OnChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
