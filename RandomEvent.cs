using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace ByteLife2
{
    public class RandomEvent
    {
        public static Grid RandomEventGridMaker(Person player, Person? otherPerson,Grid grid)
        {
            Grid grid1 = new() { AllowDrop = true, Width = 300, Height = 420 };
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            grid1.RowDefinitions.Add(new RowDefinition());
            TextBlock exposition = new() { Text = Exposition, Margin = new(5) };
            Grid.SetRow(exposition, 0);
            grid1.Children.Add(exposition);

            return grid1;
        }
        private static string ExpositionText(Person otherPerson)
        {
            Random random = new();
            int next = random.Next(0, 10);
            string name=next>=7?$"A {WordBank.RandomArchetype}"(): otherPerson.FullName;
            string exposition = $"{name}";
        }
    }
}
