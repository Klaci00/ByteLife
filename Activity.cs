using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ByteLife2
{
    public abstract class Activity(int year, string name)
    {
        public int Year { get; set; } = year;
        public string Name { get; set; } = name;

        public static void TabMaker(Person player, TabControl tabControl)
        {
            foreach (Activity activity in player.Activities)
            {
                if (tabControl.Items.OfType<TabItem>().Any(tabItem => tabItem.Name == activity.Name))
                {
                    continue;
                }

                TabItem tabItem = new()
                {
                    Name = activity.Name,
                    Header = activity.Name,
                    Content = new TextBlock { Text = $"Year: {activity.Year}" }
                };
                tabControl.Items.Add(tabItem);
            }
        }
    }
}
