using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    public class ElementarySchool(int year, string name,int yearstocomplete) : School(year, name,yearstocomplete)
    {
        public new int Year { get; set; } = year;
        public new string Name { get; set; } = name;
        public new string Description { get; set; } = "Elementary School";
        public new int YearstoComplete { get; set; } = yearstocomplete;
    }
}
