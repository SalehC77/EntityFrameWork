using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    //Data annotation
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        //[Column("BlogUrl")]
        //[Column(TypeName ="varchar(200)")]
        //[MaxLength(200)]
        //[Comment("The Url of the blog")]
        public string Url { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Rating { get; set; }
        //[NotMapped]
        public DateTime AddedOn { get; set; }
        //[NotMapped]//this for ignore the property from creation in database;
        public List<Post> Posts { get; set; }
    }
}
