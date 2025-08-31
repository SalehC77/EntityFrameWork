using EFECore_01.Models;

namespace EFECore_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var _context = new ApplicationDbContext();
            //var employee = new Employee() { Name = "saleh" };
            //_context.Employees.Add(employee);
            //_context.SaveChanges();


            //var _context = new ApplicationDbContext();
            //var book = new Book() { Name = "book1" ,Author = "saleh" };
            //_context.Books.Add(book);
            //_context.SaveChanges();
            SeedingData();
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