using EFECore_01.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFECore_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var _context = new ApplicationDbContext();

            //var employee = new Employee() { Name = "saleh" };
            //_context.Employees.Add(employee);
            //_context.SaveChanges();


            //var _context = new ApplicationDbContext();
            //var book = new Book() { Name = "book1" ,Author = "saleh" };
            //_context.Books.Add(book);
            //_context.SaveChanges();
            SeedingData();
            //start :Explicit Loading
            //var _context = new ApplicationDbContext();

            //var book = _context.Books.SingleOrDefault(b => b.Id == 3);
            //_context.Entry(book).Reference(a => a.Author).Load();// this for single object

            //var blog = _context.Blogs.SingleOrDefault(a => a.Id == 4);
            //_context.Entry(blog).Collection(p => p.Posts).Load();
            //_context.Entry(blog).Collection(p => p.Posts).Query().Where(p => p.Id > 2).ToList();


            //foreach (var post in blog.Posts)
            //{
            //    Console.WriteLine(post.Content);
            //}
            //end :Explicit Loading

            // start: SplitQuery
            //var blog1 = _context.Blogs.Include(b => b.Posts).AsSplitQuery().ToList();
            //var blog2 = _context.Blogs.Include(b => b.Posts).AsSingleQuery().ToList();
            // end: SplitQuery


            //start: Select Data using Stored Procedure 

            // this is a name of Stored Procedure in the database called pre_GetAllBooks We use it to get all books
            //var books1 = _context.Books.FromSqlRaw("pre_GetAllBooks").ToList();

            //var bookId1 = 2;
            //var books2 = _context.Books.FromSqlRaw($"pre_GetBookById {bookId1}").ToList();

            //var bookId2 = new SqlParameter("Id",2);
            //var books3 = _context.Books.FromSqlRaw("pre_GetBookById @Id ",bookId2).ToList();

            // Select Data using Stored Procedure  And Dto 
            // becouse to map the properties that return from the stored Procedure only 
            // the books in this case not mapped and return all his properties
            //var booksDto = _context.BookDto.FromSqlRaw("pre_GetAllBooksWithAuthors").ToList();

            //end: Stored Procedure 

            // this to ignore glopal filter
            //var posts = _context.Posts.IgnoreQueryFilters().ToList();

            // this for update data
            //var post = new Post
            //{
            //    Id = 9,
            //    BlogId = 4,
            //    Content = "Updated Content",
            //    IsDeleted = true,
            //};
            //_context.Posts.Update(post);
            //// this tow lines are for ignore updates for spcific property
            //_context.Entry(post).Property(p => p.BlogId).IsModified = false;
            //_context.Entry(post).Property(p => p.Titel).IsModified = false;
            //_context.SaveChanges();

            //using var transaction = _context.Database.BeginTransaction();

            //try
            //{
            //    _context.Blogs.Add(new Blog { Url = "test from transacion 1" });
            //    _context.SaveChanges();
            //    // in the next add will throw exception and will rollback the prev add
            //    _context.Blogs.Add(new Blog { Id = 9, Url = "test from transacion 2" });
            //    _context.SaveChanges();
            //    transaction.Commit();
            //}
            //catch (Exception ex)
            //{
            //    transaction.Rollback();
            //}

            //try
            //{
            //    _context.Blogs.Add(new Blog { Url = "test from transacion 1" });
            //    _context.SaveChanges();

            //    transaction.CreateSavepoint("AddFirstBlog");

            //    _context.Blogs.Add(new Blog {  Url = "test from transacion 2" });
            //    _context.Blogs.Add(new Blog { Id = 9, Url = "test from transacion 3" });
            //    _context.SaveChanges();
            //    transaction.Commit();


            //}
            //catch (Exception ex)
            //{
            //    // in this line will keep the operations
            //    transaction.RollbackToSavepoint("AddFirstBlog");
            //    // here in this line will save the operations before the SavePoint only
            //    transaction.Commit();


            //}



            //_context.Database.ExecuteSqlRaw("Insert Into Blogs Values ('Test')");
            //// this is stored procedures
            //_context.Database.ExecuteSqlRaw("pre_GetBookById @Id = 2");
            //var name = "Test3";
            //_context.Database.ExecuteSqlRaw($"pre_AddBlog @Name=N'{name}',@");
















        }

        public static void SeedingData()
        {
            using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();
            var blog = context.Blogs.FirstOrDefault(b => b.Url == "www.google.com");
            if (blog == null)
                context.Blogs.Add(new Blog { Id = 1, Url = "www.google.com", Rating = (decimal)4.5, AddedOn = DateTime.Now });
            context.SaveChanges();
        }

    }
}