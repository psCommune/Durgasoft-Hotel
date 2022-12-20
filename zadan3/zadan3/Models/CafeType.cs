using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadan3.Models
{
    public class CafeType
    {
        public int CafeTypeId { get; set; }
        public string CafeTypeTitle { get; set; }
        public List<Cafe> Cafes { get; set; }
    }
}
