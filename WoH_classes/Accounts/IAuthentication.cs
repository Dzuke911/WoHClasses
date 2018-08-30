using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WoH_classes.Accounts
{
    public interface IAuthentication
    {
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe);
        Task SignInAsync(string email);
        Task<IdentityResult> CreateNewUserAsync(string email, string password);
        Task SignOutAsync();
    }
}
