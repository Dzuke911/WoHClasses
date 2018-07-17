using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_Data
{
    public static class WoHDatabaseFacade
    {
        public static IConfiguration Configuration { get; set; }

        public static void InitDatabase(string connectionString = null)
        {
            if(connectionString == null)
            {
                connectionString = Configuration.GetConnectionString("Database");
            }

            DbContextOptionsBuilder<WoHDbContext> contextOptionsBuilder = new DbContextOptionsBuilder<WoHDbContext>();
            contextOptionsBuilder.UseSqlServer(connectionString);

            using (WoHDbContext context = new WoHDbContext(contextOptionsBuilder.Options))
            {
                context.Database.Migrate();
            }
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WoHDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Database")));

            services.AddIdentity<ApplicationUser ,IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<WoHDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
