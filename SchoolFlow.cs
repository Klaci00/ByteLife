using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    internal class SchoolFlow
    {
        public static void Enroll(Person player,School school)
        {
            if (player.School!=null && player.School.Description == school.Description)
            {
                school.Year= player.School.Year;
                player.School = school;
            }
        }
    }
}
