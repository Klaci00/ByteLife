using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;

namespace ByteLife2
{
    /// <summary>
    /// Represents a button in a popup.
    /// </summary>
    /// <param name="buttonText"></param>
    /// <param name="action"></param>
    /// <param name="player"></param>
    /// <param name="otherPerson"></param>
    public class PopupButton(string buttonText, Action action, Person player, Person? otherPerson)
    {
        /// <summary>
        /// The text displayed on the button.
        /// </summary>
        public string ButtonText { get; } = buttonText;
        /// <summary>
        /// The action to be performed when the button is clicked.
        /// </summary>
        public Action Action { get; } = action;
        /// <summary>
        /// The player, Person object.
        /// </summary>
        public Person Player { get; set; } = player;
        /// <summary>
        /// The other participant in the event, Person object.
        /// </summary>
        public Person? OtherPerson { get; set; } = otherPerson;

        public static PopupButton AttackButton(Person player, Person attacker, Popup popup)
        {
            Action attackAction = () => Actions.actionList[0](player,popup,attacker);
            PopupButton button = new(buttonText: $"Attack {attacker.FirstName}!", action: attackAction, player, attacker);
            return new(buttonText: $"Attack {attacker.FirstName}!", action: attackAction, player, attacker);
        }
    }
}
