using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    //[Table("Posts")]
    public class Post
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Content { get; set; }
        public Blog Blog { get; set; }
    }
}
