using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteLife2
{
    public class EventControl
    {
        public static Grid EventGridMaker(Person player, Popup popup, PopupContents.PopupContent popupContent, Person? otherPerson = null, Activity? activity = null)
        {
            if (popupContent.PopupButtons is null)
            {
                throw new ArgumentNullException(nameof(popupContent), $"{nameof(popupContent)} cannot be null!");
            }
            if (popup is null)
            {
                throw new ArgumentNullException(nameof(popup), $"{nameof(popup)} cannot be null!");
            }
            foreach (Person person in new Person[] { player, otherPerson })
            {
                if (person == null)
                {
                    throw new ArgumentNullException(nameof(person), $"{nameof(person)}cannot be null!");
                }
            }
            Grid grid1 = new() { AllowDrop = true, Width = 600, Height = 420, Background = Brushes.White };
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
            PopupContents.PopupGridButtonShuffler(buttons, grid1);
            return grid1;
        }
    }
}
