using EFECore_01.Configuraions;
using EFECore_01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=DESKTOP-1JJT5LB;Initial Catalog=EFECore;Integrated Security=True;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Three way of modifing table Property using Flowint Api
            //modelBuilder.Entity<Blog>().
            //    Property(m => m.Url).IsRequired();
            //new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            // the same work as the first statement;
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
            //-------------------------------------------------------------------------------------------------------

            /*modelBuilder.Entity<AuditEntry>();*/ //The Thired way to add Class like public DbSet<AuditEntry> AuditEntries { get; set; }

            /*modelBuilder.Ignore<Post>();*///this for ignore the Create of table in Database

            //modelBuilder.Entity<Blog>()
            //    .ToTable("Blogs",b => b.ExcludeFromMigrations());

            modelBuilder.Entity<Post>().ToTable("Posts");// just for chnage Table name in database



        }

        //The first way to class as DbSet to using with DbContext
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AuditEntry>  AuditEntries { get; set; }

    }
}
