using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    public class ElementarySchool(int year, string name, int yearstocomplete) : School(year, name, yearstocomplete)
    {
        public override string? Description { get; set; } = "Elementary School";
    }

    public class HighSchool(int year, string name, int yearstocomplete) : School(year, name, yearstocomplete)
    {
        public override string? Description { get; set; } = "High School";
    }
    }
