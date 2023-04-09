using CS_Practice_2.Models;
using CS_Practice_2.Navigation;
using CS_Practice_2.Tools;
using CS_Practice_2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Practice_2.ViewModels
{
    internal class PersonListViewModel : INavigatable, INotifyPropertyChanged
    {
        private ObservableCollection<Person> _people;
        private Person _selectedPerson;
        private Action _goToDataInput;

        private RelayCommand<object> _addPersonCommand;
        private RelayCommand<object> _editPersonCommand;
        private RelayCommand<object> _removePersonCommand;

        public PersonListViewModel(Action goToInput)
        {
            _goToDataInput = goToInput;
            People = new ObservableCollection<Person>(Enumerable.Range(1, 50).Select(i => Person.GenerateRandomPerson()));
        }

        public ObservableCollection<Person> People
		{
			get { return _people; }
			set { _people = value; OnPropertyChanged(nameof(People)); }
		}

		public Person SelectedPerson
		{
			get { return _selectedPerson; }
			set { _selectedPerson = value; OnPropertyChanged(nameof(SelectedPerson)); }
		}

        public RelayCommand<object> AddPersonCommand
        {
            get { return _addPersonCommand ??= new RelayCommand<object>(_ => AddPerson()); }
        }

        public RelayCommand<object> EditPersonCommand
        {
            get { return _editPersonCommand ??= new RelayCommand<object>(_ => EditPerson(), CanEditDeletePerson); }
        }

        public RelayCommand<object> RemovePersonCommand
        {
            get { return _removePersonCommand ??= new RelayCommand<object>(_ => RemovePerson(), CanEditDeletePerson); }
        }

        public NavigationTypes ViewType
        {
            get
            {
                return NavigationTypes.UserList;
            }
        }

        private void AddPerson()
        {
            _goToDataInput.Invoke();
        }

        private void EditPerson()
        {
            _goToDataInput.Invoke();
        }

        private void RemovePerson()
        {
            People.Remove(SelectedPerson);
        }

        private bool CanEditDeletePerson(object obj)
        {
            return SelectedPerson != null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
