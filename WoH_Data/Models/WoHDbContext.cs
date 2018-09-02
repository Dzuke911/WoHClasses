using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WoH_Data.Models;

namespace WoH_Data
{
    public class WoHDbContext : IdentityDbContext<ApplicationUser>
    {
        public WoHDbContext(DbContextOptions<WoHDbContext> options) : base(options)
        {

        }

        public DbSet<UserTutorialProgress> TutorialProgresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
