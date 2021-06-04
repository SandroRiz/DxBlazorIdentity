using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxBlazorIdentity.Pages
{
    [AllowAnonymous]
    public class UserInfoBase : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }

        public bool IsAdmin { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;

            UserName = authenticationState.User.Identity.Name;

            IsAuthenticated = authenticationState.User.Identity.IsAuthenticated;

            IsAdmin = authenticationState.User.IsInRole("admin");
        }

    }
}
