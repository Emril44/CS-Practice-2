using CS_Practice_2.Models;
using CS_Practice_2.ViewModels;
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
        private PersonListViewModel _viewModel;

        public PersonListView()
        {
            InitializeComponent();
            DataContext = _viewModel = new PersonListViewModel();
            UserList.ItemsSource = _viewModel.People;
        }
    }
}
