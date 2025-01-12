using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    public class CountryDinamics
    {
        private static readonly Random random = new();

        private static Country Beligerent()
        {
            int firstRandom = random.Next(Render.peacefulCountries.Count);
            var beligerent = Render.peacefulCountries[firstRandom];
            return beligerent;
        }

        public static void NewWar(Country country) //Add 1+1 country to war.
        {
            List<Country> war = [country];    //Create a war.
            var beligerent = Beligerent();
            while (beligerent == country)
            {
                beligerent = Beligerent();
            }
            war.Add(beligerent); //add beligerent
            News.NewsAdder($"A war has started between {country.Name} and {beligerent.Name}!");
            CountryListUpdater(war);
            Render.Wars.Add(war); //add war to container
        }

        public static void WarAddBeligerent(List<Country> war) //Adds a new beligerent to a select war.
        {
            Country newBeligerent = Render.peacefulCountries[random.Next(Render.peacefulCountries.Count)];
            string warName = string.Join("-", war.Select(x => x.Name));
            News.NewsAdder($"{newBeligerent.Name} has joined the {warName} war!");
            war.Add(newBeligerent);
            newBeligerent.AtWar = true;
            CountryListUpdater(war);
        }

        public static void WarRemoveBeligerent(List<Country> war)
        {
            Country formerBeligerent = war[random.Next(war.Count)];
            string warName = string.Join("-", war.Select(x => x.Name));

            if (war[0].WarYears > 0)
            {
                News.NewsAdder($"{formerBeligerent.Name} has left the {warName} war!");
            }
            else { News.NewsAdder($"{formerBeligerent.Name} had a brief armed conflict with {war[0].Name}!"); }
            war.Remove(formerBeligerent);
            formerBeligerent.AtWar = false;
            formerBeligerent.WarYears = 0;
            CountryListUpdater(war);
        }

        public static void CountryListUpdater(List<Country> war)
        {
            //Update original coutrylist to .AtWar=true. :
            foreach (Country _country in war)
            {
                var matchingcountries = Country.countryList.Where(x => x.Name == _country.Name);
                foreach (var match in matchingcountries)
                {
                    {
                        match.AtWar = true;
                    }
                }
                Render.peacefulCountries = Country.countryList.Where(x => !x.AtWar).ToList();
            }
        }

        public static void WarYearAdder() //a year passes
        {
            foreach (List<Country> war in Render.Wars)
            {
                foreach (Country country in war)
                {
                    country.WarYears += 1;
                }
            }
        }

        public static void InitWar()
        {
            foreach (Country country in Country.countryList)
            {
                int r = random.Next(0, 100);
                if (r == 1)
                {
                    country.AtWar = true;
                }
            }
        }
        public static void WarBreaksOut(Country country)
        {

            if (random.Next(0, 100) == 1)
            {
                country.AtWar = true;
                News.NewsAdder($"{country.Name} has started a war!");
            }

        }
        public static void WarEnds(Country country)
        {
            int r = random.Next(0, 10);
            if (r == 1)
            {
                country.AtWar = false;
                News.NewsAdder($"{country.Name} has ended the war after {country.WarYears} years.");
            }

        }
        public static void CountryDinamicsCycle()
        {
            //News.NewsAdder(Person.MainCharacter.Name+Person.MainCharacter.Country.Name+Person.MainCharacter.Country.AtWar.ToString()+Person.MainCharacter.Country.WarYears.ToString());
            foreach (Country country in Render.peacefulCountries)
            {
                if (random.Next(0, 600) == 1) //should be 600
                {
                    NewWar(country);
                }

            }
            News.NewsAdder(Convert.ToString(Render.Wars.Count) + " wars count");
            var warstoRemove = new List<List<Country>>();
            foreach (List<Country> war in Render.Wars)
            {
                News.NewsAdder(war[0].AtWar.ToString() + " Before peace");
                if (random.Next(0, 100) == 1)
                {

                    WarAddBeligerent(war);
                }
                else if (random.Next(0, 3) == 1)
                {
                    News.NewsAdder("TEST peacefulC length: " + Render.peacefulCountries.Count.ToString());

                    WarRemoveBeligerent(war);
                    News.NewsAdder("TEST peacefulC length AFTER: " + Render.peacefulCountries.Count.ToString());

                    if (war.Count < 2)
                    {
                        if (war[0].WarYears != 0)
                        {
                            News.NewsAdder($"The war has concluded after {war[0].WarYears} years.");//end war
                        }

                        war[0].WarYears = 0;
                        war[0].AtWar = false;
                        News.NewsAdder(war[0].AtWar.ToString() + " After peace");
                        warstoRemove.Add(war);
                    }


                }
            }
            foreach (var war in warstoRemove)
            {
                Render.Wars.Remove(war);
            }
            WarYearAdder();
        }
    }
}
