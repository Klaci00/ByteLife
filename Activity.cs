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
        public static void TabUpdater(Person player, TabControl tabControl)
        {
            foreach (Activity activity in player.Activities)
            {
                string tabName = activity.Name.Replace(" ", "");
                if (tabControl.Items.OfType<TabItem>().Any(tabItem => tabItem.Name == tabName))
                {
                    TabItem thisTabItem = tabControl.Items.OfType<TabItem>().First(tabItem => tabItem.Name == tabName);
                    thisTabItem.Content = activity.Year.ToString();
                }
            }
            
        }

        private static Grid TabContent(Person player,Activity activity)
        {
            Grid grid = new Grid();

            return grid;

        }

        private static Grid SchoolGrid()
        {
            Grid grid = new Grid();
            ColumnDefinition columnDefinition0 = new()
            {
                Width = new GridLength(1, GridUnitType.Star)
            };
            ColumnDefinition columnDefinition1 = new()
            {
                Width = new GridLength(1, GridUnitType.Star)
            };
            grid.ColumnDefinitions.Add(columnDefinition0);
            grid.ColumnDefinitions.Add(columnDefinition1);
            for(int i = 0; i < 5; i++)
            {
                RowDefinition rowDefinition = new()
                {
                    Height = new GridLength(1, GridUnitType.Star)
                };
                grid.RowDefinitions.Add(rowDefinition);
            }

            return grid;

        }
    }
}
