using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ByteLife2
{
    internal class Flow
    {
        public static void Cycle(List<Person> people, TabControl tabControl, Person player,Popup popup)
        {
            PersonalFlow.PersonalCycle(people);
            ActivityFlow.ActivityCycle(people);
            MoneyFlow.MoneyCycle(people);
            SchoolFlow.SchoolCycle(people, tabControl);
            Activity.TabUpdater(player, tabControl);
            Random random = new Random();
            Person person = people[random.Next(people.Count)];
            RandomEventPopupMaker(popup,player,person);
        }

        public static void RandomEventPopupMaker(Popup popup,Person player,Person otherperson)
        {
            Grid grid = RandomEvent.RandomEventGridMaker(player, otherperson,popup);

            // Set the grid as the child of the popup
            popup.Child = grid;
            popup.Placement = PlacementMode.Center;
            popup.HorizontalOffset = 0;
            popup.VerticalOffset = 0;
            popup.IsOpen = true;
        }
    }
}