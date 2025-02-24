using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace ByteLife2
{
    internal class Actions
    {
        public static readonly List<Action<Person, Popup, Person?>> actionList =
        [
            (player, popup, attacker) => {
                attacker = attacker ??  player; MessageBox.Show("ATTACKER IS NULL!!");
                ACTIONAttack(player,popup, attacker);
                ACTIONHeal(player, popup);
                AJobIntervGoodAnswer(player, popup);
                AJobIntervBadAnswer(player, popup);
                AJobIntervBestAnswer(player, popup);
                AJobIntervPoorAnswer(player, popup);

            },
        ];
        private static Action ACTIONAttack(Person player,  Popup popup, Person attacker)
        {
            void action()
            {
                PersonDynamics.Attack(player, attacker);
                popup.IsOpen = false;
            }
            return action;
        }
        private static Action ACTIONHeal(Person player, Popup popup)
        {
            void action()
            {
                PersonDynamics.Heal(player);
                popup.IsOpen = false;
            }
            return action;
        }
        private static Action AJobIntervGoodAnswer(Person player, Popup popup)
        {
            void action()
            {
                popup.IsOpen = false;
            }
            return action;
        }
        private static Action AJobIntervBadAnswer(Person player, Popup popup)
        {
            void action()
            {
                popup.IsOpen = false;
            }
            return action;
        }
        private static Action AJobIntervBestAnswer(Person player, Popup popup)
        {
            void action()
            {
                popup.IsOpen = false;
            }
            return action;
        }
        private static Action AJobIntervPoorAnswer(Person player, Popup popup)
        {
            void action()
            {
                popup.IsOpen = false;
            }
            return action;
        }

    }
}
