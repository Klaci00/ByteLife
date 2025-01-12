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
            RandomEventPopupMaker(popup);
        }

        public static void RandomEvent()
        {

        }
        public static void RandomEventPopupMaker(Popup popup)
        {
            // Create a new Grid
            Grid grid = new Grid { AllowDrop = true, Background = System.Windows.Media.Brushes.LightGray,Width=300, Height=420 };

            // Define the rows and columns
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Create some child elements
            TextBlock textBlock1 = new TextBlock { Text = "Row 0, Column 0", Margin = new Thickness(5) };
            TextBlock textBlock2 = new TextBlock { Text = "Row 0, Column 1", Margin = new Thickness(5) };
            TextBlock textBlock3 = new TextBlock { Text = "Row 1, Column 0", Margin = new Thickness(5) };
            TextBlock textBlock4 = new TextBlock { Text = "Row 1, Column 1", Margin = new Thickness(5) };

            // Add the child elements to the grid
            Grid.SetRow(textBlock1, 0);
            Grid.SetColumn(textBlock1, 0);
            grid.Children.Add(textBlock1);

            Grid.SetRow(textBlock2, 0);
            Grid.SetColumn(textBlock2, 1);
            grid.Children.Add(textBlock2);

            Grid.SetRow(textBlock3, 1);
            Grid.SetColumn(textBlock3, 0);
            grid.Children.Add(textBlock3);

            Grid.SetRow(textBlock4, 1);
            Grid.SetColumn(textBlock4, 1);
            grid.Children.Add(textBlock4);

            // Set the grid as the child of the popup
            popup.Child = grid;
            popup.Placement = PlacementMode.Center;
            popup.HorizontalOffset = 0;
            popup.VerticalOffset = 0;
            popup.IsOpen = true;
        }
    }
}