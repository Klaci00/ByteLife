using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{/// <summary>
/// Represents the flow of activities in the game.
/// </summary>
    public class ActivityFlow
    {
        public static void ActivityCycle(List<Person> people)
        {
            foreach (Person person in people)
            {
                foreach (Activity activity in person.Activities)
                {
                    activity.Year += 1;
                }
            }
        }
    }
}
