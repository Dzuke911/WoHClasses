using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WoH_Data;
using WoH_Data.Models;

namespace WoH_classes.AccountData
{
    class AccountDataManager : IAccountDataManager
    {
        private readonly WoHDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountDataManager(UserManager<ApplicationUser> userManager, WoHDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<JObject> GetAccountDataAsync(string userName)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userName);

            if (user == null) { throw new InvalidOperationException(); } //////////////!!!!!!!!!!!!!!!!!!!!!

            UserTutorialProgress utp = await _context.TutorialProgresses.SingleOrDefaultAsync(t => t.UserID == user.Id);

            if (utp == null) { throw new InvalidOperationException(); } //////////////!!!!!!!!!!!!!!!!!!!!!

            bool tutorialComplete = utp.Progress >= 6; ///////////////////!!!!!!!!!!!!!!!!!!! not hardcoded, but grabbed from game defaults

            JObject result = new JObject{
                { "TutorialProgress", utp.Progress },
                { "TutorialComplete", tutorialComplete },
                { "Name", userName }
            };

            return result;
        }
    }
}
