using System.ComponentModel;

namespace ByteLife2
{
    public class Person(string firstname, string lastname, Country country, int age, bool female, List<Relationship> relationships) : INotifyPropertyChanged
    {
        public string FirstName { get; set; } = firstname;
        public string LastName { get; set; } = lastname;
        public string FullName => $"{FirstName} {LastName}";
        public Country Country { get; set; } = country;
        public int Age { get; set; } = age;
        public int Health { get; set; } = 100;
        public int Happiness { get; set; } = 100;
        public int Looks { get; set; } = 0;
        public int Intelligence { get; set; } = 0;
        public int Fitness { get; set; } = 0;
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
                    return "HigSchooler";
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
        public bool Female { get; set; } = female;

        public int Salary { get; set; } = 0;
        public int Money { get; set; } = 0;
        public List<Relationship> Relationships { get; set; } = relationships ?? new List<Relationship>();
        public static Person? MainCharacter { get; set; }

        public static readonly List<string> FemaleFirstNames = ["Hanna", "Léna", "Zoé", "Anna", "Luca", "Emma", "Olívia", "Boglárka", "Lili", "Mira", "Laura", "Lara", "Sára", "Zsófia", "Alíz", "Izabella", "Lilien", "Kamilla", "Gréta", "Flóra", "Janka", "Jázmin", "Szofia", "Nóra", "Adél", "Maja", "Liza", "Lilla", "Bella", "Linett", "Zselyke", "Dorka", "Liliána", "Fanni", "Csenge", "Blanka", "Rebeka", "Natasa", "Panna", "Viktória", "Dorina", "Dóra", "Noémi", "Nara", "Emília", "Róza", "Bianka", "Réka", "Elizabet", "Szofi", "Petra", "Szófia", "Abigél", "Milla", "Júlia", "Eszter", "Lotti", "Mia", "Szonja", "Elena", "Norina", "Vivien", "Lia", "Panka", "Zorka", "Eliza", "Amira", "Natália", "Hanga", "Boróka", "Emili", "Johanna", "Odett", "Zejnep", "Nazira", "Hédi", "Lujza", "Bíborka", "Fruzsina", "Diána", "Tamara", "Zora", "Nina", "Lora", "Alina", "Lana", "Mirella", "Regina", "Elina", "Letícia", "Borbála", "Emese", "Zita", "Kincső", "Kiara", "Dorottya", "Mirabella", "Alexandra", "Vanda", "Annabella"];

        public static readonly List<string> MaleFirstNames = ["Dominik", "Olivér", "Levente", "Máté", "Marcell", "Noel", "Bence", "Zalán", "Milán", "Ádám", "Botond", "Dániel", "Zsombor", "Benett", "Áron", "Dávid", "Balázs", "Benedek", "Nimród", "Márk", "Zente", "Nolen", "Bálint", "Péter", "Kristóf", "László", "Zétény", "Tamás", "Barnabás", "Kornél", "Alex", "Hunor", "András", "Martin", "Gergő", "Zoltán", "Márton", "Attila", "Ábel", "Ákos", "Patrik", "Bendegúz", "Vince", "Gábor", "Soma", "István", "Erik", "Sándor", "Krisztián", "Zsolt", "József", "Benjámin", "János", "Roland", "Mátyás", "Csongor", "Ármin", "Nándor", "Kevin", "Ferenc", "Vencel", "Csaba", "Róbert", "Norbert", "Richárd", "Benjamin", "Mihály", "Kende", "Boldizsár", "Szabolcs", "Simon", "Zénó", "Viktor", "Gergely", "Tibor", "Vilmos", "Dorián", "Miron", "Laurent", "Bende", "Nátán", "Teodor", "Bertalan", "Denisz", "Mirkó", "Adrián", "Miklós", "Félix", "Donát", "Krisztofer", "Sámuel", "Imre", "Brájen", "Noé", "Gellért", "Eliot", "Dénes", "Merse", "Alexander", "Iván"];

        public static readonly List<string> FamilyNames = ["Antal", "Bakos", "Balázs", "Bálint", "Balla", "Balog", "Balogh", "Barna", "Barta", "Berki", "Biró", "Bodnár", "Bogdán", "Bognár", "Borbély", "Boros", "Budai", "Csonka", "Deák", "Dudás", "Fábián", "Faragó", "Farkas", "Fazekas", "Fehér", "Fekete", "Fodor", "Fülöp", "Gál", "Gáspár", "Gulyás", "Hajdu", "Halász", "Hegedűs", "Hegedüs", "Horváth", "Illés", "Jakab", "Jónás", "Juhász", "Katona", "Kelemen", "Kerekes", "Király", "Kis", "Kiss", "Kocsis", "Kovács", "Kozma", "Lakatos", "László", "Lengyel", "Lukács", "Magyar", "Major", "Márton", "Máté", "Mészáros", "Mezei", "Molnár", "Nagy", "Nemes", "Németh", "Novák", "Oláh", "Orbán", "Orosz", "Orsós", "Pál", "Pap", "Papp", "Pásztor", "Pataki", "Péter", "Pintér", "Rácz", "Sándor", "Sárközi", "Simon", "Sipos", "Somogyi", "Soós", "Szabó", "Szalai", "Székely", "Szilágyi", "Szőke", "Szűcs", "Szücs", "Takács", "Tamás", "Tóth", "Török", "Váradi", "Varga", "Vass", "Veres", "Vincze", "Virág", "Vörös"];

        private static Random Random = new Random();
        public static List<Person> People(int number, Country country)
        {
            var list = new List<Person>();

            for (int i = 0; i < number; i++)
            {
                int firstRandom = Random.Next(0, 100);
                int familyRandom = Random.Next(0, 100);
                bool female = Random.Next(0, 2) == 1;
                string randomFirst = female ? FemaleFirstNames[firstRandom] : MaleFirstNames[firstRandom];
                string randomFamily = FamilyNames[familyRandom];
                Person person = new(randomFirst, randomFamily, country, Random.Next(13, 90), female, relationships: []);
                list.Add(person);
            }
            return list;

        }

        public static Person Mother(Random random, Person player)
        {
            int firstRandomF = Random.Next(0, FemaleFirstNames.Count);
            int maidenRandom = Random.Next(0, FamilyNames.Count);
            Person mother = new(FemaleFirstNames[firstRandomF], player.LastName + "-" + FamilyNames[maidenRandom], player.Country, 0, true, relationships: []);
            return mother;
        }

        public static Person Father(Random random, Person player)
        {
            int firstRandom = Random.Next(0, MaleFirstNames.Count);
            Person father = new(MaleFirstNames[firstRandom], player.LastName, player.Country, 0, false, relationships: []);
            return father;
        }

        public static List<Person> Siblings(Random random, Person player, Person mother)
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
                    int firstRandomF = Random.Next(0, FemaleFirstNames.Count);
                    firstName = FemaleFirstNames[firstRandomF];
                }
                else
                {
                    int firstRandom = Random.Next(0, FemaleFirstNames.Count);
                    firstName = MaleFirstNames[firstRandom];
                }
                Person sibling = new(firstName, player.LastName, player.Country, siblingAge, female, relationships: []);
                siblings.Add(sibling);
            }
            return siblings;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
