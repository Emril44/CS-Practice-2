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
    /// Interaction logic for DataInputView.xaml
    /// </summary>
    public partial class DataInputView : UserControl
    {
        private DataInputViewModel _viewModel;

        public DataInputView()
        {
            InitializeComponent();
            DataContext = _viewModel = new DataInputViewModel();
        }

        private void BProceed_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
