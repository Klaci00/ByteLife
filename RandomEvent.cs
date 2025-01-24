﻿using System;
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
        public static Grid RandomEventGridMaker(Person player, Person otherPerson, Popup popup)
        {
            PopupContents.PopupContent popupContent = PopupContents.RandomEventTemplate01(player, otherPerson,popup);
            Grid grid1 = new() { AllowDrop = true, Width = 600, Height = 420, Background = Brushes.White };
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            TextBlock exposition = new() { Text = ExpositionText(otherPerson), Margin = new(5) };
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
        private static string ExpositionText(Person? otherPerson=null)
        {
            Random random = new();
            int next = random.Next(0, 10);
            
            string name = otherPerson==null ? WordBank.RandomArchetype() : (next >= 7 ? $"A {WordBank.RandomArchetype()}" : otherPerson.FullName);
            
            string action = WordBank.RandomInsulteGerund();
            string location=WordBank.RandomLocation();
            string exposition = $"{name} is {action} you {location}";
            return exposition;
        }
    }
}
