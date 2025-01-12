using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace ByteLife2
{
    internal class WordBank
    {
        public static string RandomArchetype()
        {
            Random random = new();
            int next = random.Next(PeopleLists.Count);
            List<string> randomList = PeopleLists[next];
            int randomIndex = random.Next(randomList.Count);
            string archetype = randomList[randomIndex];
            return archetype;
        }
        private static readonly List<List<string>> PeopleLists = [Professionals, Derogatory,Other,Criminals];
        private static readonly List<string> Professionals = ["accountant","actor","actress","air traffic controller","architect","artist","attorney","banker","bartender","barber","bookkeeper","builder","businessman","businesswoman","businessperson","butcher","carpenter","cashier","chef","coach","dental hygienist","dentist","designer","developer","dietician","doctor","economist","editor","electrician","engineer","farmer","filmmaker","fisherman","flight attendant","jeweler","judge","lawyer","mechanic","musician","nutritionist","nurse","optician","painter","pharmacist","photographer","physician","physician's assistant","pilot","plumber","police officer","politician","professor","programmer","psychologist","receptionist","salesman","salesperson","saleswoman","secretary","singer","surgeon","teacher","therapist","translator","translator","undertaker","veterinarian","videographer","waiter","waitress","writer"];

        private static readonly List<string> Derogatory = ["hobo","bum","junkie","thief","burglar","drug dealer", "stinkmeaner"];

        private static readonly List<string> Other = ["biker", "trucker", "sailor", "pirate", "soldier", "marine", "airman", "punk", "rocker", "rapper", "genZer", "boomer", "millenial", "zoomer", "hipster", "emo", "goth", "weeb", "otaku", "furry", "brony", "trekkie"];

        private static readonly List<string> Criminals = ["thief", "burglar", "drug dealer", "gangster", "mobster", "hitman", "assassin", "serial killer", " arsonist", "hacker", "cybercriminal", "pirate", "smuggler", "thug", "enforcer", "blackmailer", "extortionist", "kidnapper", "human trafficker", "pimp", "prostitute", "escort", "drug mule", "drug lord", "drug kingpin", "drug baron", "drug czar", "drug trafficker", "drug pusher", "drug smuggler", "drug runner", "drug courier", "drug addict", "drug abuser", "drug user"];
    }
}
