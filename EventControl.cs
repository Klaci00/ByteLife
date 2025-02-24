using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace ByteLife2
{
    public class EventControl
    {
        public static Grid EventGridMaker(Person player, Popup popup, int contentType, Person? otherPerson = null)
        {
            PopupContent popupContent = PopupContent.PopupContentGetter(contentType,player,popup,otherPerson);
            if (popupContent.PopupButtons is null)
            {
                throw new ArgumentNullException(nameof(popupContent), $"{nameof(popupContent)} cannot be null!");
            }
            if (popup is null)
            {
                throw new ArgumentNullException(nameof(popup), $"{nameof(popup)} cannot be null!");
            }
            foreach (Person person in new Person[] { player})
            {
                if (person == null)
                {
                    throw new ArgumentNullException(nameof(person), $"{nameof(person)} cannot be null!");
                }
            }
            Grid grid1 = new() { AllowDrop = true, Width = 600, Height = 420, Background = Brushes.White };
            grid1.RowDefinitions.Add(new RowDefinition());
            TextBlock textBlock = new() { Text = popupContent.Exposition_Text, FontSize = 20, TextWrapping = TextWrapping.Wrap, Margin = new Thickness(10) };
            Grid.SetRow(textBlock, 0);
            grid1.Children.Add(textBlock);
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < popupContent.PopupButtons.Count; i++)
            {
                grid1.RowDefinitions.Add(new RowDefinition());
                Button button = new Button();
                button.Content = $"{popupContent.PopupButtons[i].ButtonText}, {i}, {popupContent.PopupButtons.Count}";
                int index = i; // Capture the current value of i
                button.Click += (sender, e) => popupContent.PopupButtons[index].Action();
                buttons.Add(button);
            }
            PopupContent.PopupGridButtonShuffler(buttons, grid1);
            return grid1;
        }

        public static void EventPopupMaker(Person player, List<Person> people, Popup popup, int contentType)
        {
            Random random = new();
            Person? otherPerson = random.Next(0,2)==0?PersonDynamics.RandomPerson(people) : null;
            Grid grid = EventGridMaker(player, popup,contentType,otherPerson);
            popup.IsOpen = true;
            popup.Visibility = System.Windows.Visibility.Visible;
            popup.Child = grid;
        }
    }
}
