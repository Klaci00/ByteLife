using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ByteLife2
{
    internal class PopupContents
    {
        public struct PopupButton(string buttonText, Action action, Person player, Person? otherPerson)
        {
            public string ButtonText { get; } = buttonText;
            public Action Action { get; } = action;

            public Person Player { get; set; } = player;
            public Person OtherPerson { get; set; } = otherPerson;
        }


        public struct PopupContent
        {
            public PopupContent(List<PopupButton> popupButtons)
            {
                PopupButtons = popupButtons;
            }
            public List<PopupButton> PopupButtons { get; }
        }

        private static Action ACTIONAttack(Person player, Person attacker,Popup popup)
        {
            void action()
            {
                PersonDynamics.Attack(player, attacker);
                popup.IsOpen = false;
            }
            return action;
        }

        private static Action ACTIONHeal(Person player,Popup popup)
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
        public static PopupContent RandomEventTemplate01(Person player, Person otherPerson, Popup popup)
        {
            
                Action attackAction = ACTIONAttack(player, attacker: otherPerson,popup);
                Action healAction = ACTIONHeal(player,popup);
                PopupButton attack = new(buttonText: "Attack them!", action: attackAction, player, otherPerson);
                PopupButton heal = new(buttonText:"Heal me!",healAction,player,otherPerson);
                PopupButton blabla = new(buttonText: "blabla", action:attackAction, player, otherPerson);
                List<PopupButton> popupButtons = [attack,heal,blabla];
                PopupContent popupContent = new(popupButtons);
                return popupContent;

            

        }

        public static PopupContent JobinterViewTemplate01(Person player, Popup popup)
        {
            Action goodAnswer = AJobIntervGoodAnswer(player, popup);
            Action badAnswer = AJobIntervBadAnswer(player, popup);
            Action bestAnswer = AJobIntervBestAnswer(player, popup);
            Action poorAnswer = AJobIntervPoorAnswer(player, popup);
            PopupButton good = new(buttonText: "Good Answer", goodAnswer, player,null);
            PopupButton bad = new(buttonText: "Bad Answer", badAnswer, player, null);
            PopupButton best = new(buttonText: "Best Answer", bestAnswer, player, null);
            PopupButton poor = new(buttonText: "Poor Answer", poorAnswer, player, null);
            List<PopupButton> popupButtons = [good, bad, best, poor];
            PopupContent popupContent = new(popupButtons);
            return popupContent;
        }
        public static void PopupGridButtonShuffler(List<Button> buttons,Grid grid)
        {
            Random random = new();
            var shuffledButtons = buttons.OrderBy(x => random.Next()).ToList();
            foreach (var button in shuffledButtons)
            {
                Grid.SetRow(button, shuffledButtons.IndexOf(button) + 1);
                grid.Children.Add(button);
            }
        }
    }
}
