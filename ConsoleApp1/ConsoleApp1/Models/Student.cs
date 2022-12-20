using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime BirhtDay { get; set; }

        public Group Group { get; set; }
    }
}
