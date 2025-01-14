using System.Windows;

namespace ByteLife2
{
    internal class PersonDynamics
    {
        Random Random = new Random();
        public static void Interaction(Person actor, Person recipient)
        {

        }

        public static void FamilyMaker(Person player)
        {
            Random Random = new Random();
            int fatherAge = Random.Next(18, 45);
            int motherAge = Random.Next(fatherAge - 12, fatherAge + 13);
            motherAge = motherAge < 18 ? 18 : motherAge;

            Person father = Person.Father(Random, player);
            Person mother = Person.Mother(Random, player);
            father.Age = fatherAge;
            mother.Age = motherAge;
            List<Person> siblings = Person.Siblings(Random, player, mother);
            Relationship.FamilyRelationshipRenderer(player, father, mother, siblings);
            Render.peoplePool.Add(player);
            Render.peoplePool.Add(mother);
            Render.peoplePool.Add(father);
            if (siblings.Count > 0)
            {
                foreach (Person s in siblings)
                {
                    Render.peoplePool.Add(s);
                }
            }
        }
        public static string MainActivityChooser(Person player)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                { "Infant", "" },
                { "Child", "" },
                { "Elementary", "School" },
                { "HighSchooler", "Highschool" },
                { "Adult", "University" },
                { "Senior", "University" }
            };
            return player.Employed ? "Work":dic[player.AgeGroup];
        }

        public static void Attack(Person player,Person attacker)
        {
            player.Health-=SmallDamage(attacker);
            MessageBox.Show(Convert.ToString(player.Health));
        }
        private static int SmallDamage(Person attacker)
        {
            return attacker.Strength / 3;
        }
    }
}
