using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ByteLife2
{
    internal class Flow
    {
        public static void Cycle(List<Person> people,TabControl tabControl,Person player)
        {
            PersonalFlow.PersonalCycle(people);
            ActivityFlow.ActivityCycle(people);
            MoneyFlow.MoneyCycle(people);
            SchoolFlow.SchoolCycle(people,tabControl);
            Activity.TabUpdater(player, tabControl);
        }
    }
}
