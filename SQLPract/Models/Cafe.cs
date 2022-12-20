using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLPract.Models
{
    public class Cafe
    {
        public int CafeId { get; set; }
        public string CafeName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public CafeType CafeType { get; set; }
    }
}
