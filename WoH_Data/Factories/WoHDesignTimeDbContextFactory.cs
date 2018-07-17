using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_Data
{
    class WoHDesignTimeDbContextFactory : IDesignTimeDbContextFactory<WoHDbContext>
    {
        public WoHDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<WoHDbContext> contextOptionBuilder = new DbContextOptionsBuilder<WoHDbContext>();
            contextOptionBuilder.UseSqlServer("someDatabase");

            return new WoHDbContext(contextOptionBuilder.Options);
        }
    }
}
