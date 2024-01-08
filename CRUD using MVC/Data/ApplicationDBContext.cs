using CRUD_using_MVC.Controllers;
using CRUD_using_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CRUD_using_MVC.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDo>().Property(W => W.IsFinished).HasDefaultValue(false);
        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
