using stembowl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace stembowl.Models
{
    public class QuestionDbContext : DbContext
    {
        public QuestionDbContext(DbContextOptions opt):base(opt) { }
        public DbSet<Question> Questions { get; set;}

    }
}