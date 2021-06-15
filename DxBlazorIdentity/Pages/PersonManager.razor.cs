using DevExpress.Blazor;
using DxBlazorIdentity.Data;
using DxBlazorIdentity.Models;
using DxBlazorIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DxBlazorIdentity.Pages
{
    [AllowAnonymous]
    public class PersonManagerBase : ComponentBase
    {
       
        public Person MyPerson { get; set; }
        
        private PersonService PersonService;

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PersonService = new PersonService();
            MyPerson = PersonService.Get(Id);
        }
        
    }
}
