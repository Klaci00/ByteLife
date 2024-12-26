using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    internal class Flow
    {
        public static void Cycle(List<Person> people)
        {
            PersonalFlow.PersonalCycle(people);
            MoneyFlow.MoneyCycle(people);
        }
    }
}
