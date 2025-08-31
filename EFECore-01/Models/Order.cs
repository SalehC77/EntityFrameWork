using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    public class Order
    {
        public int Id { get; set; }
        public long OrderNo { get; set; }
        public double Amount { get; set; }

    }
}
