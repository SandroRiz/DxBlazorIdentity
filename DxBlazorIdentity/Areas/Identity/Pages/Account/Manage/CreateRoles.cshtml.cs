using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DxBlazorIdentity.Areas.Identity.Pages.Account.Manage
{
    public class CreateRoles : PageModel
    {
      
        private readonly ILogger<CreateRoles> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateRoles(
            ILogger<CreateRoles> logger,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

       

        public async Task<IActionResult> OnPostAsync()
        {

            if (false)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
                await _roleManager.CreateAsync(new IdentityRole { Name = "superuser" });
                await _roleManager.CreateAsync(new IdentityRole { Name = "user" });
                await _roleManager.CreateAsync(new IdentityRole { Name = "guest" });
            }
            return Page();
        }
    }
}