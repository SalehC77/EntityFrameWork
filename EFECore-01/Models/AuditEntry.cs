using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    public class AuditEntry
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
    }
}
