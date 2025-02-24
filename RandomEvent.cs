using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace ByteLife2
{
    public class RandomEvent
    {
        /// <summary>
        /// Creates a grid to inject into a popup for a random event.
        /// </summary>
        /// <param name="player">A Person object representing the player.</param>
        /// <param name="otherPerson">A Person object representing the other participant in the event.</param>
        /// <param name="popup">A System.Windows.Controls.Primitives.Popup object for displaying the grid.</param>
        /// <returns>A System.Windows.Controls.Grid containing the event details.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one of the arguments is null.</exception>
        /// <example><code>Grid result = RandomEventGridMaker(player, otherPerson, popup);</code></example>
        public static Grid EventGridMaker(Person player, Popup popup, PopupContents.PopupContent popupContent, Person? otherPerson=null, Activity? activity=null)
        {
            if (popup is null)
            {
                throw new ArgumentNullException(nameof(popup), $"{nameof(popup)} cannot be null!");
            }
                foreach (Person person in new Person[] { player, otherPerson })
            {
                if (person == null)
                {
                    throw new ArgumentNullException(nameof(person),$"{nameof(person)}cannot be null!");
                }
            }
            PopupContents.PopupContent popupContent = PopupContents.RandomEventTemplate01(player, otherPerson,popup);
            Grid grid1 = new() { AllowDrop = true, Width = 600, Height = 420, Background = Brushes.White };
            ExpositionMaker(grid1, otherPerson);
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
        

        private static void ExpositionMaker(Grid grid, Person? otherPerson)
        {
            grid.RowDefinitions.Add(new RowDefinition());
            TextBlock exposition = new() { Text = ExpositionText(otherPerson), Margin = new(5) };
            Grid.SetRow(exposition, 0);
            grid.Children.Add(exposition);
        }

    }
}
