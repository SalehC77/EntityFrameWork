using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    public class Tag
    {
        public int Id { get; set; }
        //public ICollection<Post> Posts { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
