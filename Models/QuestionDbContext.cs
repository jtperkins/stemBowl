using stembowl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using stembowl.Areas.Identity;

namespace stembowl.Models
{
    public class QuestionDbContext : IdentityDbContext<ApplicationUser>
    {
        public QuestionDbContext(DbContextOptions opt):base(opt) { }
        public DbSet<Question> Questions { get; set;}
        public DbSet<Answer> Answer { get; set;}
        public DbSet<Team> Teams {get; set;}
        public DbSet<TeamAnswers> TeamAnswers {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            /*configures one-to-many relationship
            modelBuilder.Entity<ApplicationUser>()
                .HasOne<Team>(s => s.Team)
                .WithMany(g => g.TeamMembers)
                .HasForeignKey(s => s.TeamID);*/
        }

    }
}