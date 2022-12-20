using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadan3.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public User User { get; set; }
        public Cafe Cafe { get; set; }
        public DateTime Time { get; set; }
        public int Stars { get; set; }
    }
}
