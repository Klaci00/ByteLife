using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ByteLife2
{
    internal class MainActivity
    {
        public static void Study(Person player)
        {
            player.Intelligence += 1;
            player.OnPropertyChanged(nameof(player.Intelligence));
            MessageBox.Show("You have studied hard!");
        }
    }
}
