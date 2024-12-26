using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    internal class MoneyFlow
    {
        public static void MoneyCycle(List<Person> people)
        {
            foreach (Person person in people)
            {
                Income(person);
            }
        }
        private static void Income(Person person)
        {
            person.Money += person.Salary;
        }
    }
}
