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
        public static List<Person> peoplePool = new List<Person>();
        public static void RunRender()
        {

            Random random = new();
            Country.Countrymaker();


        }
    }

}
