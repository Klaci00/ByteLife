using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    public class Work(int year, string name, int salary, int performance, int workhours) : Activity(year, name)
    {
        public new int Year { get; set; } = year;
        public new string Name { get; set; } = name;
        public int Salary { get; set; } = salary;
        public int Performance { get; set; } = performance;
        public int WorkHours { get; set; } = workhours;
    }
}
