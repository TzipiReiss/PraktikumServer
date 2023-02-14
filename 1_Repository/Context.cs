using _3_Repository.Entities;
using _3_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace _3_Repository
{
    public class Context : DbContext, IDataSource
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                " Data Source = sqlsrv;" +
                " Initial Catalog = project_TzipiReiss1;" +
                " Integrated Security = True;" +
                " TrustServerCertificate = True;" +
                " MultipleActiveResultSets = True;"
                );
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>().ToTable("Children");
            modelBuilder.Entity<User>().ToTable("Users");
        }

    }
}
