using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ByteLife2
{
    internal class PopupContent(List<PopupButton> popupButtons, string expositionText)
    {
        


        /// <summary>
        /// Generates a random exposition text for a random event.
        /// </summary>
        /// <param name="otherPerson">A Person object which may be null.</param>
        /// <returns>string</returns>
        /// <example><code>string text = ExpositionText(Person? otherPerson);</code></example>
        private static string ExpositionText(Person? otherPerson = null)
        {
            Random random = new();
            int next = random.Next(0, 10);

            string name = otherPerson == null ? WordBank.RandomArchetype() : (next >= 7 ? $"A {WordBank.RandomArchetype()}" : otherPerson.FullName);

            string action = WordBank.RandomInsulteGerund();
            string location = WordBank.RandomLocation();
            string exposition = $"{name} is {action} you {location}";
            return exposition;
        }

        private static PopupButton AttackButton(Person player, Person attacker, Popup popup)
        {
            Action attackAction = ACTIONAttack(player, attacker, popup);
            IPopupButton button = new(buttonText: $"Attack {attacker.FirstName}!", action: attackAction, player, attacker);
            return new(buttonText: $"Attack {attacker.FirstName}!", action: attackAction, player, attacker);
        }
        


    private static readonly List<Action<Person, Popup>> JobInterviewAnswersActions =
    [
        (person, popup) =>
        {
            AJobIntervBadAnswer(person, popup);
            AJobIntervBestAnswer(person, popup);
            AJobIntervGoodAnswer(person, popup);
            AJobIntervPoorAnswer(person, popup);
        }
    ];
        public static PopupContent RandomEventTemplate01(Person player, Person otherPerson, Popup popup)
        {

            Action attackAction = () => Actions.actionList[0](player, otherPerson, popup);
            Action healAction = ACTIONHeal(player,popup);
                PopupButton attack = new(buttonText: "Attack them!", action: attackAction, player, otherPerson);
                PopupButton heal = new(buttonText:"Heal me!",healAction,player,otherPerson);
                PopupButton blabla = new(buttonText: "blabla", action:attackAction, player, otherPerson);
                List<PopupButton> popupButtons = [attack,heal,blabla];
                string expositionText = ExpositionText(otherPerson);
                PopupContent popupContent = new() {PopupButtons= popupButtons, ExpositionText= expositionText };
                Action attack = ACTIONAttack[0].Invoke();
                return popupContent;

            

        }

        public static PopupContent JobinterViewTemplate01(Person player, Popup popup)
        {
            JobInterviewAnswersActions[0](player, popup);
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
        public static PopupContent PopupContentGetter(int index,Person player, Popup popup, Person? otherPerson=null)
        {
            switch (index)
            {
                case 0:
                    return RandomEventTemplate01(player,otherPerson,popup);
                case 1:
                    return JobinterViewTemplate01(player,popup);
                default:
                    return RandomEventTemplate01(player, otherPerson, popup);
            }
    }
}
