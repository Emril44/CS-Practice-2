using CS_Practice_2.ViewModels;
using System.Windows.Controls;

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
    }
}
