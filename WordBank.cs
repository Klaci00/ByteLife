using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace ByteLife2
{
    internal class WordBank
    {

        private static readonly List<string> Professionals = new List<string>
        {
            "accountant","actor","actress","air traffic controller","architect","artist","attorney",
            "banker","bartender","barber","bookkeeper","builder","businessman","businesswoman","businessperson",
            "butcher","carpenter","cashier","chef","coach","dental hygienist","dentist","designer","developer",
            "dietician","doctor","economist","editor","electrician","engineer","farmer","filmmaker","fisherman",
            "flight attendant","jeweler","judge","lawyer","mechanic","musician","nutritionist","nurse","optician",
            "painter","pharmacist","photographer","physician","physician's assistant","pilot","plumber","police officer",
            "politician","professor","programmer","psychologist","receptionist","salesman","salesperson","saleswoman",
            "secretary","singer","surgeon","teacher","therapist","translator","translator","undertaker","veterinarian",
            "videographer","waiter","waitress","writer"
        };

        private static readonly List<string> Derogatory = new List<string>
        {
            "hobo","bum","junkie","thief","burglar","drug dealer", "stinkmeaner"
        };

        private static readonly List<string> Other = new List<string>
        {
            "biker", "trucker", "sailor", "pirate", "soldier", "marine", "airman", "punk", "rocker", "rapper", "genZer",
            "boomer", "millenial", "zoomer", "hipster", "emo", "goth", "weeb", "otaku", "furry", "brony", "trekkie"
        };

        private static readonly List<string> Criminals = new List<string>
        {
            "thief", "burglar", "drug dealer", "gangster", "mobster", "hitman", "assassin", "serial killer", "arsonist",
            "hacker", "cybercriminal", "pirate", "smuggler", "thug", "enforcer", "blackmailer", "extortionist", "kidnapper",
            "human trafficker", "pimp", "prostitute", "escort", "drug mule", "drug lord", "drug kingpin", "drug baron",
            "drug czar", "drug trafficker", "drug pusher", "drug smuggler", "drug runner", "drug courier", "drug addict",
            "drug abuser", "drug user"
        };

        private static readonly List<string> InsultsGerund = new List<string>
        {
            "spitting at", "cursing at", "cussing at", "screaming at", "insulting", "mocking", "threatening", "name-calling",
            "belittling", "intimidating", "patronizing", "ridiculing", "gaslighting", "hassling", "hazing", "hekkling"
        };

        private static readonly List<string> Locations = new List<string>
        {
            "on the street", "on the sidewalk", "in your backyard", "on your porch", "in front of your home", "at the shopping mall",
            "at the park", "in the grocery store", "at the bus stop", "in the subway", "at the train station", "at the library",
            "in a coffee shop", "at a restaurant", "in the movie theater", "at the gym", "in front of a hospital", "at the beach",
            "in front of a hotel", "at the airport", "in a museum", "at a concert", "in a stadium", "at the amusement park",
            "in the zoo", "at the aquarium", "in a nightclub", "at a bar", "at a church", "at a temple", "in a mosque",
            "at a synagogue", "at the courthouse", "at the police station", "at the fire station", "at the post office", "in the bank",
            "at the gas station", "next to your car", "on the highway", "in the forest", "on a mountain", "by the lake", "at the river",
            "in the city", "in the countryside"
        };

        private static readonly List<List<string>> PeopleLists = new List<List<string>> { Professionals, Derogatory, Other, Criminals };
        /// <summary>
        /// Generates a random archetype string
        /// from a list of professional, derogatory, other, and criminal archetypes.
        /// </summary>
        /// <returns>string</returns>
        public static string RandomArchetype()
        {
            Random random = new();
            int next = random.Next(0, PeopleLists.Count);
            var randomList = PeopleLists[next];
            int randomIndex = random.Next(0, randomList.Count);
            string archetype = randomList[randomIndex];
            return archetype;
        }
        /// <summary>
        /// Generates a random insult in gerund form.
        /// </summary>
        /// <returns>string</returns>
        public static string RandomInsulteGerund()
        {
            Random random = new Random();
            int next = random.Next(0, InsultsGerund.Count);
            return InsultsGerund[next];
        }
        /// <summary>
        /// Generates a random location string.
        /// </summary>
        ///<returns>string</returns>
        public static string RandomLocation()
        {
            Random random = new Random();
            int next = random.Next(0, Locations.Count);
            return Locations[next];
        }
    }
}
