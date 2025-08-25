using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    public class BlogImage
    {
        public int Id { get; set; }
        public string Iamge { get; set; }
        [Required,MaxLength(250)]
        public string Caption { get; set; }

        public int BlogId { get; set; }
        //[ForeignKey("BlogForeignKey")]
        public Blog Blog { get; set; }
    }
}
