using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    public class Category
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public byte Id { get; set; }  Never Don't use byte for primary key use int or short if storege is matter
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }

    }
}
