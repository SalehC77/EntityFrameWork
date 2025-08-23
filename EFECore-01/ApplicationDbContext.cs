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
            //Three way of modifing table Property using Fluent API
            //modelBuilder.Entity<Blog>().
            //    Property(m => m.Url).IsRequired();
            //new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            // the same work as the first statement;
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
            //-------------------------------------------------------------------------------------------------------

            /*modelBuilder.Entity<AuditEntry>();*/ //The Thired way to add Class like public DbSet<AuditEntry> AuditEntries { get; set; }

            /*modelBuilder.Ignore<Post>();*///this for ignore the Create of table in Database
            /*modelBuilder.Entity<Blog>().Ignore(b => b.AddedOn);*/ //this for ignore the Create of Propertity at table in Database
                                                                    //modelBuilder.Entity<Blog>()
                                                                    //    .ToTable("Blogs",b => b.ExcludeFromMigrations());

            //modelBuilder.Entity<Post>().ToTable("Posts");// just for chnage and make Table name in database
            //modelBuilder.Entity<Post>().ToTable("Posts",schema:"blogging");// change Schema
            //modelBuilder.HasDefaultSchema("blogging");//to change the defulat Schema = dto --> blogging;

            //modelBuilder.Entity<Blog>().Property(b => b.Url) //this for change property name = Url -> BlogUrl
            //    .HasColumnName("BlogUrl");

            //modelBuilder.Entity<Blog>(eb =>
            //{
            //    eb.Property(b => b.Url).HasColumnType("varchar(200)");
            //    eb.Property(b => b.Rating).HasColumnType("decimal(5,2)");
            //});
            //modelBuilder.Entity<Blog>().Property(b => b.Url).HasMaxLength(200);
            //modelBuilder.Entity<Blog>().Property(b => b.Url).HasComment("Test Comment");

            /*modelBuilder.Entity<Book>().HasKey(b => b.BookKey).HasName("PK_BookKey");*/ //to set a differnt Primary key and give it a name

            /*modelBuilder.Entity<Book>().HasKey(b => new {b.Name,b.Author});*/ // Set Composite key 

            /*modelBuilder.Entity<Book>().Property(b => b.Rating).HasDefaultValue(2);*///set default value
            /* modelBuilder.Entity<Book>().Property(b => b.CreatedOn).HasDefaultValueSql("GETDATE()");*///set default value using sql funcation or statement

            //modelBuilder.Entity<Author>().Property(p => p.DisplayName) //ComputedColumn
            //    .HasComputedColumnSql("[LastName] + ', ' + [FirstName] ");


            //modelBuilder.Entity<Category>().Property(b => b.Id) //this for byte primary key adding identity increment
            //    .ValueGeneratedOnAdd();












        }

        //The first way to class as DbSet to using with DbContext
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AuditEntry>  AuditEntries { get; set; }

    }
}
