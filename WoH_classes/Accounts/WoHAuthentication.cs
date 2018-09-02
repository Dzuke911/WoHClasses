using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_Data;
using WoH_Data.Models;

namespace WoH_classes.Accounts
{
    public class WoHAuthentication : IAuthentication
    {
        private readonly WoHDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public WoHAuthentication(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, WoHDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateNewUserAsync(string email, string password)
        {
            ApplicationUser user = new ApplicationUser { UserName = email, Email = email };
            IdentityResult result = await _userManager.CreateAsync(user, password);

            if(result.Succeeded)
            {
                await _context.TutorialProgresses.AddAsync(new UserTutorialProgress { UserID = user.Id });
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
        }

        public async Task SignInAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            await _signInManager.SignInAsync(user, false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
