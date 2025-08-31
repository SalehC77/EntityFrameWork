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


            //modelBuilder.Entity<Blog>().HasOne(b => b.BlogImage) //relationships one to one
            //    .WithOne(i => i.Blog).HasForeignKey<BlogImage>(b => b.BlogForeignKey);

            //modelBuilder.Entity<Blog>().HasMany(b => b.Posts) //left to right
            //    .WithOne(b => b.Blog);
            //these tow ways are work if we have navigation property in both side;
            //modelBuilder.Entity<Post>().HasOne(b => b.Blog) //right to left
            //    .WithMany(b => b.Posts);

            // if we don't have navigation Property use this way;

            //modelBuilder.Entity<Post>()
            //    .HasOne<Blog>().WithMany()
            //    .HasForeignKey(p => p.BlogId);

            //this if you need addifrent forign key not normal
            //modelBuilder.Entity<RecodeOfSale>()
            //    .HasOne(r => r.Car)
            //    .WithMany(c => c.SaleHistory)
            //    .HasForeignKey(r => r.CarLicensePlate)
            //    .HasPrincipalKey(c => c.Licenseplate);

            //this if you need composite key;
            //modelBuilder.Entity<RecodeOfSale>()
            //    .HasOne(r => r.Car)
            //    .WithMany(c => c.SaleHistory)
            //    .HasForeignKey(r => new { r.CarLicensePlate ,r.CarState})
            //    .HasPrincipalKey(c => new { c.Licenseplate ,c.State});



            //Many to Many Relation ship without write the third Table manualy

            //modelBuilder.Entity<Post>()
            //    .HasMany(p => p.Tags)
            //    .WithMany(t => t.Posts)
            //    .UsingEntity(j => j.ToTable("PostTagsTest"));

            //after adding the third table using Icollection form both Tag and Post

            //modelBuilder.Entity<Post>()
            //    .HasMany(p => p.Tags)
            //    .WithMany(t => t.Posts)
            //    .UsingEntity<PostTag>(
            //    j => j.HasOne(pt => pt.Tag)
            //          .WithMany(t => t.PostTags)
            //          .HasForeignKey(pt => pt.TagId),
            //    j => j.HasOne(pt => pt.Post)
            //          .WithMany(p => p.PostTags)
            //          .HasForeignKey(pt => pt.PostId),
            //    j =>
            //    {
            //        j.Property(pt => pt.AddedOn).HasDefaultValueSql("GETDATE()");
            //        j.HasKey(t => new { t.PostId, t.TagId });
            //    }
            //    );

            // using indirect Many to Many Relation Ship
            modelBuilder.Entity<PostTag>()
                .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<PostTag>()
                .HasIndex(pt => pt.PostId);

            //**********************************************************
            //modelBuilder.Entity<PostTag>() //composite Index
            //    .HasIndex(pt => new { pt.PostId,pt.TagId });

            //modelBuilder.Entity<Person>()
            //    .HasIndex(p => new { p.FirstName, p.LastName });

            //modelBuilder.Entity<Blog>()
            //    .HasIndex(pt => pt.Url).IsUnique(); // that means the data in column is unique

            //modelBuilder.Entity<Blog>()
            //    .HasIndex(pt => pt.Url).HasDatabaseName("Index_Url_Test");


            //modelBuilder.Entity<Blog>()
            //   .HasIndex(pt => pt.Url).HasFilter("[Url] IS NOT NULL");

            //modelBuilder.Entity<Blog>()
            //  .HasIndex(pt => pt.Url).IsUnique().HasFilter(null); // allow null in input
            //******************************************************************
            //modelBuilder.HasSequence<int>("OrderNumber");

            //modelBuilder.Entity<Order>()
            //    .Property(o => o.OrderNo).HasDefaultValueSql("NEXT VALUE FOR OrderNumber");

            //modelBuilder.HasSequence<int>("OrderNumber",schema:"shared")
            //    .StartsAt(1000)
            //    .IncrementsBy(5);

            //modelBuilder.Entity<Order>()
            //    .Property(o => o.OrderNo).HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumber");
            //*************************************************************
            //Data Seeding
            modelBuilder.Entity<Blog>()
                .HasData(new Blog { Id = 1, Url = "www.google.com", Rating = (decimal)4.5, AddedOn = DateTime.Now });

            modelBuilder.Entity<Post>()
                .HasData(new Post { Id = 1, BlogId = 1, Titel = "Post 1", Content = "test 1" });

            modelBuilder.Entity<Post>()
                .HasData(new Post { Id = 2, BlogId = 1, Titel = "Post 2", Content = "test 2" },
                         new Post { Id = 3, BlogId = 1, Titel = "Post 3", Content = "test 3" },
                         new Post { Id = 4, BlogId = 1, Titel = "Post 4", Content = "test 4" });
















        }

        //The first way to class as DbSet to using with DbContext
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person>  Persons  { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AuditEntry>  AuditEntries { get; set; }

    }
}
