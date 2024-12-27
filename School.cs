using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    public abstract class School(int year, string name,int yearstocomplete)
    {
        public int Year { get; set; } = year;
        public string Name { get; set; } = name;
        public string ? Description { get; set; }

        public int YearstoComplete { get; set; } = yearstocomplete;

        public void Complete(Person player)
        {
            if (this.Description == null)
            {
                throw new Exception("Description is null");
            }
            else
            {
                player.Skills.Add(this.Description);
            }
            
        }
    }
    
    
}
