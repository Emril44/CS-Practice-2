using CS_Practice_2.Models;
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

namespace CS_Practice_2.Views
{
    /// <summary>
    /// Interaction logic for PersonListView.xaml
    /// </summary>
    public partial class PersonListView : UserControl
    {
        private static readonly string[] names = { "Jake", "Aaron", "Paul", "Adam" };
        private static readonly string[] surnames = { "McCartney", "Sandler", "Cage", "Harris", "Davis" };

        public PersonListView()
        {
            InitializeComponent();

            DateTime startDate = new(1900, 1, 1);
            int range = (DateTime.Today - startDate).Days;

            List<Person> people = new();
            Random rand = new();

            for (int i = 0; i < 50; i++)
            {
                string personName = names[rand.Next(0, names.Length)];
                string personSurname = surnames[rand.Next(0, surnames.Length)];


                people.Add(new Person(personName, personSurname, "toolazytomakethisrandom@gmail.com", startDate.AddDays(rand.Next(range))));
            }

            UserList.ItemsSource = people;
        }
    }
}
