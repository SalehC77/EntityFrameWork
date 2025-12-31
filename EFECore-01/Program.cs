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