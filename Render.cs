using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    internal class Render
    {
        public static List<Country> peacefulCountries = Country.countryList.Where(x => !x.AtWar).ToList();
        public static List<List<Country>> Wars = [];
        public static List<Person> peoplePool = [];
        public static void RunRender()
        {
            Country.Countrymaker();
        }
        public static void RenderPlayer(Person player)
        {
            Random random = new Random();
            player.Health = random.Next(50,101);
            player.Fitness = random.Next(0, 101);
            player.Intelligence = random.Next(0, 101);
            player.Happiness = random.Next(70, 101);
            player.Looks = random.Next(0, 101);
        }
    }

}
