using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    internal class PopupContents
    {
        public struct PopupButton(string buttonText, Action action, Person player, Person otherPerson)
        {
            public string ButtonText { get; } = buttonText;
            public Action Action { get; } = action;

            public Person Player { get; set; } = player;
            public Person OtherPerson { get; set; } = otherPerson;
        }


        public struct PopupContent
        {
            public PopupContent(List<PopupButton> popupButtons, string popupText)
            {
                PopupButtons = popupButtons;
            }
            public List<PopupButton> PopupButtons { get; }
        }

        private static Action ACTIONAttack(Person player, Person attacker)
        {
            void action()
            {
                PersonDynamics.Attack(player, attacker);
            }
            return action;
        }
        public static PopupContent Template01(Person player, Person otherPerson)
        {
            {
                Action attackAction = ACTIONAttack(player, attacker: otherPerson);
                PopupButton attack = new(buttonText: "Attack them!", action: attackAction, player, otherPerson);
                List<PopupButton> popupButtons = [attack];
                PopupContent popupContent = new(popupButtons, popupText: "sadas");
                return popupContent;

            }

        }

    }
}
