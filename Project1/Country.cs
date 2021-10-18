using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public abstract class Country : IComparable
    {

        //Properties

        public string Countries { get; set; }

        public string Language { get; set; }
        public double Population { get; set; }
        public int SoftwareDevelopers { get; set; }
        public List<Description> DescriptionList { get; set; }

        //Constructors
        public Country(string countries, string language, double population, int softwareDevelopers)
        {
            Countries = countries;
            Language = language;
            Population = population;
            SoftwareDevelopers = softwareDevelopers;
            DescriptionList = new List<Description>();

        }

        public Country() : this("Unknown", "Unknown", 17844, 17777) 
        {

        }

        //Methods
        public override string ToString()
        {
            return Countries;
        }

        public int CompareTo(object obj)
        {
            Country othercountry = obj as Country;
            return this.Countries.CompareTo(othercountry.Countries);
        }
    }
    public class Asia : Country
    {
        public override string ToString()
        {
            return base.ToString() + " : Asia";
        }
    }
    public class Europe : Country
    {
        public override string ToString()
        {
            return base.ToString() + " : Europ";
        }
    }
    public class America : Country
    {
        public override string ToString()
        {
            return base.ToString() + " : America";
        }
    }
}

