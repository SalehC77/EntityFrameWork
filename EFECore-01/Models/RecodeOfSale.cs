using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFECore_01.Models
{
    public class RecodeOfSale
    {
        public int Id { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }
        public string CarLicensePlate { get; set; }
        public string CarState { get; set; }
        public Car Car { get; set; }
    }
}
