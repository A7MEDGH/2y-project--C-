using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Country> allCountries = new List<Country>();

        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new Uri("/pages/loginpage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //setting the comboBox
            string[] types = { "All", "Asia", "Europe", "America" };
            cboxTypes.ItemsSource = types;

            //Creating Countries
            Asia c1 = new Asia() { Countries = "Oman", Language = "Arabic", Population = 5.564430, SoftwareDevelopers = 10177 };
            Asia c2 = new Asia() { Countries = "UAE", Language = "Arabic", Population = 5.876887, SoftwareDevelopers = 4165 };

            Europe c3 = new Europe() { Countries = "Ireland", Language = "English, Gaeilge", Population = 6.556997, SoftwareDevelopers = 9388 };
            Europe c4 = new Europe() { Countries = "Austria", Language = "German", Population = 12.876654, SoftwareDevelopers = 109700 };

            America c5 = new America() { Countries = "Canada", Language = "English", Population = 15.777865, SoftwareDevelopers = 13000 };
            America c6 = new America() { Countries = "Mexico", Language = "Spanish", Population = 200.896743, SoftwareDevelopers = 12654 };


            //Creating the description
            Random rand = new Random();

            Description d1 = new Description() { Info = " Software firm in oman, Muscat is one of the best software company offers\n software development in oman and software services oman, Muscat." };

            Description d2 = new Description() { Info = " List of Top Software Development Companies Dubai,\n UAE | Top Software Developers UAE SPEC INDIA\n  Kadam Technologies Pvt.Ltd.\n  BrancoSoft Private LimitedUplogic\n Technologies Pvt \nLtdMobileCoderz Technologies" };

            Description d3 = new Description() { Info = " List of Top Software Development Companies\n kneat software \n Software AG \n Rococo Software" };

            Description d4 = new Description() { Info = "Working as a developer in Austria The number of software developers\n increased from 103,500 in 2018 to over 109,700 \nregistered software developers in 2019 in\n Austria according to The State of European Tech Report." };

            Description d5 = new Description() { Info = "  it is one of the leading countries for software development,\n and the software sector accounts for some of the biggest companies in Canada.\n Five of the largest Canadian software companies,\n by market capitalization, include Constellation Software Inc.,\n OpenText Corporation, CGI Inc., Descartes Systems Group Inc., and Kinaxis." };

            Description d6 = new Description() { Info = "With Mexico being so close to the U.S.,\n you might be surprised how much lower programmer rates are\n in Mexico...but - they are! Industry experts conclude that\n you can get 3-4 developers in Mexico for the price of 1 in the U.S" };

            //Add to the description listbox
            c1.DescriptionList.Add(d1);

            c2.DescriptionList.Add(d2);

            c3.DescriptionList.Add(d3);

            c4.DescriptionList.Add(d4);

            c5.DescriptionList.Add(d5);

            c6.DescriptionList.Add(d6);

            //Add to countries listbox
            allCountries.Add(c1);
            allCountries.Add(c2);
            allCountries.Add(c3);
            allCountries.Add(c4);
            allCountries.Add(c5);
            allCountries.Add(c6);

            //Sort
            allCountries.Sort();
            //Display
            lbxCountries.ItemsSource = allCountries;



            Project1.dbGridTestDataSet dbGridTestDataSet = ((Project1.dbGridTestDataSet)(this.FindResource("dbGridTestDataSet")));

            // Load data into the table tbl_GridTest. You can modify this code as needed.
            Project1.dbGridTestDataSetTableAdapters.tbl_GridTestTableAdapter dbGridTestDataSettbl_GridTestTableAdapter 
            = new Project1.dbGridTestDataSetTableAdapters.tbl_GridTestTableAdapter();

            dbGridTestDataSettbl_GridTestTableAdapter.Fill(dbGridTestDataSet.tbl_GridTest);
            System.Windows.Data.CollectionViewSource tbl_GridTestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tbl_GridTestViewSource")));
            tbl_GridTestViewSource.View.MoveCurrentToFirst();
        }

        private void lbxCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Country selectedCountry =lbxCountries.SelectedItem as Country;

            if (selectedCountry != null)
            {
                lbxDescription.ItemsSource = selectedCountry.DescriptionList;
                tblkStatistics.Text = string.Format($"Language : {selectedCountry.Language}" + $"\n Population : {selectedCountry.Population}" + $"\n Software Developers : {selectedCountry.SoftwareDevelopers}");
            }
        }

        private void cboxTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //determine selection in the comboBox
            string selectedContinent = cboxTypes.SelectedItem as string;

            //setting a filtered List
            List<Country> filterList = new List<Country>();

            //if/else / switch 
            switch (selectedContinent)
            {
                case "All":
                    lbxCountries.ItemsSource = allCountries;
                    break;

                case "Asia":
                    foreach (Country country in allCountries)
                    {
                        if (country is Asia)
                            filterList.Add(country);
                    }
                    lbxCountries.ItemsSource = filterList;
                    break;

                case "Europe":
                    foreach (Country country in allCountries)
                    {
                        if (country is Europe)
                            filterList.Add(country);
                    }
                    lbxCountries.ItemsSource = filterList;
                    break;

                case "America":
                    foreach (Country country in allCountries)
                    {
                        if (country is America)
                            filterList.Add(country);
                    }
                    lbxCountries.ItemsSource = filterList;
                    break;
            }

        }




    }
    
}
