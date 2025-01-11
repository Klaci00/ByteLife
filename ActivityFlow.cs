using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
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
        public static void NextYear(Activity activity)
        {
            activity.Year += 1;
        }

        public static void ActivityAdder(Person player, Activity activity)
        {
            player.Activities.Add(activity);
        }
    }
}
