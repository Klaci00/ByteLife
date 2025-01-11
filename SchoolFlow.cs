using System.Windows;
using System.Windows.Controls;

namespace ByteLife2
{
    internal class SchoolFlow
    {
        public static void SchoolCycle(List<Person> people,TabControl tabControl)
        {
            foreach (Person person in people)
            {
                if (person.School != null)
                {
                    if (person.School.Year == person.School.YearstoComplete)
                    {
                        Complete(person,tabControl);
                    }
                    else
                    {
                        person.School.Year += 1;
                    }
                }
                ObligatoryEnrollment(person,tabControl);

            }
        }
        public static void ObligatoryEnrollment(Person player,TabControl tabControl)
        {
            if (player.Student == false && !player.Skills.Contains("Elementary School") && player.Age >= 6 && player.Age < 18)
            {
                School school = ElementarySchoolMaker(player);
                if (player.Player)
                {
                    player.Activities.Add(school);
                    Activity.TabAdder(school, tabControl);
                }
                school.Year = player.School == null ? 0 : player.School.Year;
                player.School = school;
                player.Student = true;
            }
            else if (player.Student == false && !player.Skills.Contains("High School") && player.Age >= 14 && player.Age < 18)
            {
                School school = HighSchoolMaker(player);
                if (player.Player)
                {
                    player.Activities.Add(school);
                    Activity.TabAdder(school, tabControl);

                }
                school.Year = player.School == null ? 0 : player.School.Year;
                player.School = school;
                player.Student = true;
            }
        }
        public static void Enroll(Person player, School school)
        {
            if (player.School != null && player.School.Description == school.Description)
            {
                school.Year = player.School.Year;
                player.School = school;
            }
        }
        public static ElementarySchool ElementarySchoolMaker(Person player)
        {
            string elementaryName = SchoolnameMaker("Elementary School");
            return new ElementarySchool(0, elementaryName, 8);
        }

        public static HighSchool HighSchoolMaker(Person player)
        {
            string highschoolName = SchoolnameMaker("High School");
            return new HighSchool(0, highschoolName, 4);
        }
        public static string SchoolnameMaker(string schooltype)
        {
            Random random = new();
            string adjecive = School.adjectives[random.Next(0, School.adjectives.Count)];
            adjecive = string.Concat(adjecive[0].ToString().ToUpper(), adjecive.AsSpan(1));
            string noun = School.nouns[random.Next(0, School.nouns.Count)];
            noun = string.Concat(noun[0].ToString().ToUpper(), noun.AsSpan(1));
            return $"{adjecive} {noun} {schooltype}";
        }
        public static void Complete(Person player, TabControl tabControl)
        {
            if (player.School?.Description == null)
            {
                throw new Exception("Description is null");
            }
            else
            {
                player.Activities.Remove(player.School);
                player.Skills.Add(player.School.Description);
                Activity.TabRemover(player.School, tabControl);
                player.Student = false;
                player.School = null;
            }
        }

    }
}
