using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ByteLife2
{
    public class PopupContent(List<PopupButton> popupButtons, string expositionText)
    {
        public List<PopupButton> PopupButtons { get; set; } = popupButtons;
        public string Exposition_Text { get; set; } = expositionText;


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


        private static PopupContent RandomEventTemplate01(Person player, Person otherPerson, Popup popup)
        {

            void attackAction() => Actions.actionDict["Attack"](player, popup, otherPerson);
            void attack2() => Actions.actionList[0](player, popup, otherPerson);
            void healAction() => Actions.actionDict["Heal"](player, popup, otherPerson);
            PopupButton attack = new(buttonText: "Attack them!", action: attack2, player, otherPerson);
            PopupButton heal = new(buttonText: "Heal me!", healAction, player, otherPerson);
            PopupButton blabla = new(buttonText: "blabla", action: attackAction, player, otherPerson);
            List<PopupButton> popupButtons = [attack, heal, blabla];
            string expositionText = ExpositionText(otherPerson);
            PopupContent popupContent = new(popupButtons, expositionText);
            return popupContent;
        }

        private static PopupContent JobinterViewTemplate01(Person player, Popup popup)
        {

            void goodAnswer() => Actions.actionDict["Good Answer"](player, popup, null);
            void badAnswer() => Actions.actionDict["Bad Answer"](player, popup, null);
            void bestAnswer() => Actions.actionDict["Best Answer"](player, popup, null);
            void poorAnswer() => Actions.actionDict["Poor Answer"](player, popup, null);
            PopupButton good = new(buttonText: "Good Answer", goodAnswer, player, null);
            PopupButton bad = new(buttonText: "Bad Answer", badAnswer, player, null);
            PopupButton best = new(buttonText: "Best Answer", bestAnswer, player, null);
            PopupButton poor = new(buttonText: "Poor Answer", poorAnswer, player, null);
            List<PopupButton> popupButtons = [good, bad, best, poor];
            string interviewQuestion = "Not implemented yet.";
            PopupContent popupContent = new(popupButtons, expositionText: $"The interviewer asks the following question:\n {interviewQuestion}");
            return popupContent;
        }
        public static void PopupGridButtonShuffler(List<Button> buttons, Grid grid)
        {
            Random random = new();
            var shuffledButtons = buttons.OrderBy(x => random.Next()).ToList();
            foreach (var button in shuffledButtons)
            {
                Grid.SetRow(button, shuffledButtons.IndexOf(button) + 1);
                grid.Children.Add(button);
            }
        }
        public static PopupContent PopupContentGetter(int index, Person player, Popup popup, Person? otherPerson = null)
        {
            switch (index)
            {
                case 0:
                    return RandomEventTemplate01(player, otherPerson, popup);
                case 1:
                    return JobinterViewTemplate01(player, popup);
                default:
                    return RandomEventTemplate01(player, otherPerson, popup);
            }
        }
    }
}
