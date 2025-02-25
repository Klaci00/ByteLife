using System.ComponentModel;

namespace ByteLife2
{
    public abstract class Person() : INotifyPropertyChanged
    {
        public int Health { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public bool Alive => Health > 0;


        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class NPC : Person, INotifyPropertyChanged
    {
        public static readonly Random Random = new Random();

        public Country Country { get; set; }
        public int Age { get; set; }
        public bool Female { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public NPC()
        {
            FirstName = FirstNameRnd();
            LastName = FamilyNameRnd();
            Country = Country.countryList[Random.Next(0, Country.countryList.Count)];
            Age = Random.Next(18, 100);
            Female = Random.Next(0, 2) == 1;
        }
        private string FirstNameRnd()
        {
            int firstRandom = Random.Next(0, 100);
            string randomFirst = Female ? WordBank.FemaleFirstNames[firstRandom] : WordBank.MaleFirstNames[firstRandom];
            return randomFirst;
        }
        private static string FamilyNameRnd()
        {
            int familyRandom = Random.Next(0, 100);
            return WordBank.FamilyNames[familyRandom];
        }
        public int Salary { get; set; } = 0;
        public int Money { get; set; } = 0;
        public bool Employed { get; set; } = false;
        public bool Student { get; set; } = false;
        public int Happiness { get; set; } = 100;
        public int Looks { get; set; } = Random.Next(0, 101);
        public int Intelligence { get; set; } = Random.Next(0, 101);
        public int Fitness { get; set; } = Random.Next(0, 101);
        public School? School { get; set; }
        public List<string> Skills { get; set; } = new List<string>();
        public List<Relationship> Relationships { get; set; } = new List<Relationship>();
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public string AgeGroup
        {
            get
            {
                if (Age < 2)
                {
                    return "Infant";
                }
                else if (Age < 6)
                {
                    return "Child";
                }
                else if (Age < 14)
                {
                    return "Elementary";
                }
                else if (Age < 18)
                {
                    return "HighSchooler";
                }
                else if (Age < 65)
                {
                    return "Adult";
                }
                else
                {
                    return "Senior";
                }
            }
        }

    }
    public class Player(string firstname, string lastname, Country country, bool female) : NPC, INotifyPropertyChanged
    {
        public new string FirstName { get; set; } = firstname;
        public new string LastName { get; set; } = lastname;
        public new Country Country { get; set; } = country;
        public new bool Female { get; set; } = female;

        public static Person Mother(Random random, Player player)
        {
            int firstRandomF = random.Next(0, WordBank.FemaleFirstNames.Count);
            int maidenRandom = random.Next(0, WordBank.FamilyNames.Count);
            NPC mother = new();
            mother.FirstName = WordBank.FemaleFirstNames[firstRandomF];
            mother.LastName = player.LastName + "-" + WordBank.FamilyNames[maidenRandom];
            mother.Country = player.Country;
            mother.Female = true;
            return mother;
        }

        public static Person Father(Random random, Player player)
        {
            int firstRandom = random.Next(0, WordBank.MaleFirstNames.Count);
            NPC father = new();
            father.FirstName = WordBank.MaleFirstNames[firstRandom];
            father.LastName = player.LastName;
            father.Country = player.Country;
            father.Female = false;
            return father;
        }

        public static List<Person> Siblings(Random random, Player player, NPC mother)
        {
            List<Person> siblings = new List<Person>();
            int siblingCount = mother.Age == 18 ? random.Next(0, 3) : (mother.Age <= 25 ? random.Next(0, 4) : random.Next(0, 6));
            for (int i = 0; i < siblingCount; i++)
            {
                int siblingAge = random.Next(0, mother.Age - 17);
                bool female = random.Next(0, 2) == 1;
                string firstName = "";
                if (female)
                {
                    int firstRandomF = Random.Next(0,WordBank.FemaleFirstNames.Count);
                    firstName = WordBank.FemaleFirstNames[firstRandomF];
                }
                else
                {
                    int firstRandom = Random.Next(0, WordBank.FemaleFirstNames.Count);
                    firstName = WordBank.MaleFirstNames[firstRandom];
                }
                NPC sibling = new();
                sibling.FirstName = firstName;
                sibling.LastName = player.LastName;
                sibling.Country = player.Country;
                sibling.Age = siblingAge;
                sibling.Female = female;
                siblings.Add(sibling);
            }
            return siblings;
        }

    }
    public class NPC_CheapEnemy : Person,INotifyPropertyChanged
    {
        private static readonly Random Random = new();
        public NPC_CheapEnemy()
        {
            Health = Random.Next(30, 101);
            Strength = Random.Next(1, 101);

        }
    }
}
