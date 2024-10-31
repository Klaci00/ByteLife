using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    internal class PersonalFlow
    {
        public static void PersonalCycle(List<Person> people)
        {
            foreach (Person person in people)
            {
                Aging(person);
            }
        }
        private static void Aging(Person person)
        {
            person.Age += 1;
        }
                
    }
}
