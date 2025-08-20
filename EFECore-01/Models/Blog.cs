using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        //[NotMapped]//this for ignore the property from creation in database;
        public List<Post> Posts { get; set; }
    }
}
