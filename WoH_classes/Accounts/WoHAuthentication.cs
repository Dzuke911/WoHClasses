using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_Data;

namespace WoH_classes.Accounts
{
    public class WoHAuthentication : IAuthentication
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public WoHAuthentication(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateNewUserAsync(string email, string password)
        {
            return await _userManager.CreateAsync(new ApplicationUser { UserName = email, Email = email }, password);
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
        }

        public async Task SignInAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            await _signInManager.SignInAsync(user,false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
