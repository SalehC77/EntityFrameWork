using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    public class Book
    {
        //[Key] we use key notations if the primary key name is different not like = Id or BookId
        //public int BookKey { get; set; }
        public int Id { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
