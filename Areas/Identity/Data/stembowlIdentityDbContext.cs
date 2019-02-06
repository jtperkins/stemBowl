using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using stembowl.Areas.Identity;
using stembowl.Models;

namespace stembowl.Areas.Identity.Data
{
    public class stembowlIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public stembowlIdentityDbContext(DbContextOptions<stembowlIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne<Team>(s => s.Team)
                .WithMany(g => g.TeamMembers)
                .HasForeignKey(s => s.TeamID);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
