using CS_Practice_2.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CS_Practice_2.ViewModels
{
    enum NavigationTypes
    {
        DataInput,
        UserList
    }

    internal class NavViewModel : INotifyPropertyChanged
    {
        private List<INavigatable> _viewModels = new();
        private INavigatable _currentViewModel;

        public INavigatable CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            private set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public NavViewModel()
        {
            Navigate(NavigationTypes.UserList);
        }

        private void Navigate(NavigationTypes type)
        {
            if (CurrentViewModel != null && CurrentViewModel.ViewType.Equals(type))
                return;

            INavigatable viewModel = GetViewModel(type);

            if (viewModel == null)
                return;

            _viewModels.Add(viewModel);
            CurrentViewModel = viewModel;
        }

        private INavigatable GetViewModel(NavigationTypes type)
        {
            INavigatable viewModel = _viewModels.FirstOrDefault(vm => vm.ViewType.Equals(type));

            if(viewModel != null)
                return viewModel;

            switch(type)
            {
                case NavigationTypes.DataInput:
                    viewModel = new DataInputViewModel(() => Navigate(NavigationTypes.UserList)); break;
                case NavigationTypes.UserList:
                    viewModel = new PersonListViewModel(() => Navigate(NavigationTypes.DataInput)); break;
                default:
                    return null;
            }

            _viewModels.Add(viewModel);
            return viewModel;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
