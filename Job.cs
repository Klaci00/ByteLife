using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ByteLife2
{
    public class Job
    {
        public static Grid InterviewPopupGridMaker(Person player, Person otherPerson, Popup popup)
        {
            PopupContents.PopupContent popupContent = PopupContents.RandomEventTemplate01(player, otherPerson, popup);
            Grid grid1 = new() { AllowDrop = true, Width = 600, Height = 420, Background = Brushes.White };
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            TextBlock exposition = new() { Text = "At the interview, you are asked the following question:", Margin = new(5) };
            Grid.SetRow(exposition, 0);
            grid1.Children.Add(exposition);
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < popupContent.PopupButtons.Count; i++)
            {
                Button button = new Button();
                button.Content = $"{popupContent.PopupButtons[i].ButtonText}, {i}, {popupContent.PopupButtons.Count}";
                int index = i; // Capture the current value of i
                button.Click += (sender, e) => popupContent.PopupButtons[index].Action();
                buttons.Add(button);
            }
            PopupContents.PopupGridButtonShuffler(buttons, grid1);
            return grid1;
        }
    }
}
