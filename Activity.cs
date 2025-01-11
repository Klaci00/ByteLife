using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                if (activity == null) continue;
                string tabName = activity.Name.Replace(" ", "");
                if (tabControl.Items.OfType<TabItem>().Any(tabItem => tabItem.Name == tabName))
                {
                    TabItem thisTabItem = tabControl.Items.OfType<TabItem>().First(tabItem => tabItem.Name == tabName);
                    thisTabItem.Content = activity.Year.ToString();
                    continue;
                }
                TabItem tabItem = new()
                {
                    Name = tabName,
                    Header = activity.Name,
                    Content = new TextBlock
                    {
                        Text = activity.Year.ToString(),
                        DataContext = activity
                    }
                };
                tabControl.Items.Add(tabItem);
            }
        }
        public static void TabAdder(Activity activity, TabControl tabControl)
        {
            string tabName = activity.Name.Replace(" ", "");
            if (tabControl.Items.OfType<TabItem>().Any(tabItem => tabItem.Name == tabName))
            {
                TabItem thisTabItem = tabControl.Items.OfType<TabItem>().First(tabItem => tabItem.Name == tabName);
                thisTabItem.Content = activity.Year.ToString();
                return;
            }
            TabItem tabItem = new()
            {
                Name = tabName,
                Header = activity.Name,
                Content = new TextBlock
                {
                    Text = activity.Year.ToString(),
                    DataContext = activity
                }
            };
            tabControl.Items.Add(tabItem);
        }
        public static void TabRemover(Activity activity, TabControl tabControl)
        {
            string tabName = activity.Name.Replace(" ", "");
            if (tabControl.Items.OfType<TabItem>().Any(tabItem => tabItem.Name == tabName))
            {
                TabItem thisTabItem = tabControl.Items.OfType<TabItem>().First(tabItem => tabItem.Name == tabName);
                tabControl.Items.Remove(thisTabItem);
            }
        }
    }
}
