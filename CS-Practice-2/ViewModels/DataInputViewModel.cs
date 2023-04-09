using CS_Practice_2.Models;
using CS_Practice_2.Navigation;
using CS_Practice_2.Tools;
using System;
using System.CodeDom;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CS_Practice_2.ViewModels
{
    internal class DataInputViewModel : INavigatable
    {
        private Person _person = new();
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        private readonly PersonListViewModel _personList;

        private bool _isAdult;

        private bool _isEnabled = true;
        private Visibility _loaderVisibility = Visibility.Collapsed;
        private Action _goToUserList;

        public DataInputViewModel(Action goToUserList)
        {
            _goToUserList = goToUserList;
        }

        public DataInputViewModel(PersonListViewModel personList)
        {
            _personList = personList;
        }

        public string Name
        {
            get { return _person.Name; }
            set { _person.Name = value; }
        }

        public string Surname
        {
            get { return _person.Surname; }
            set { _person.Surname = value; }
        }

        public string Email
        {
            get { return _person.Email ?? ""; }
            set { _person.Email = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _person.DateOfBirth ?? DateTime.Today; }
            set { _person.DateOfBirth = value; }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            private set { _isAdult = value; }
        }

        public string SunSign
        {
            get { return _person.WestZodiac ?? ""; }
            private set { _person.WestZodiac = value; }
        }

        public string ChineseSign
        {
            get { return _person.EastZodiac ?? ""; }
            private set { _person.EastZodiac = value; }
        }

        public bool IsBirthday
        {
            get { return _person.IsBirthday ?? false; }
            private set { _person.IsBirthday = value; }
        }

        public int Age
        {
            get { return _person.Age ?? -1; }
            set { _person.Age = value; }
        }

        public RelayCommand<object> ProceedCommand
        {
            get { return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute); }
        }

        public RelayCommand<object> CancelCommand
        {
            get { return _cancelCommand ??= new RelayCommand<object>(_ => CloseEdit()); }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public NavigationTypes ViewType
        {
            get { return NavigationTypes.DataInput; }
        }

        private async void Proceed()
        {
            IsEnabled = false;
            LoaderVisibility = Visibility.Visible;

            IsBirthday = await Task.Run(() => _person.IsItBirthday());
            
            try
            {
                await Task.Run(() => Person.ValidateEmail(Email));
            }
            catch(InvalidPersonEmailException)
            {
                MessageBox.Show($"Email invalid! ({Email})");
                await Task.Run(() => FinishLoad());
                return;
            }

            try
            {
                await Task.Run(() => _person.CalculateAge());
            }
            catch(AgeTooOldException)
            {
                MessageBox.Show($"Age {Age} exceeds 150!");
                await Task.Run(() => FinishLoad());
                return;
            }
            catch(DateOfBirthUnreachedException)
            {
                MessageBox.Show($"Age {Age} below 0!");
                await Task.Run(() => FinishLoad());
                return;
            }

            _isAdult = await Task.Run(()=>(Age >= 18));

            SunSign = await Task.Run(() => _person.GetSunSign());
            ChineseSign = await Task.Run(() => _person.GetChineseSign());

            await Task.Run(() => FinishLoad());
            await Task.Run(() => OutputPersonData());

            CloseEdit();
        }

        private bool CanExecute(object obj)
        {
            return
                !String.IsNullOrWhiteSpace(Name) &&
                !String.IsNullOrWhiteSpace(Surname) &&
                !String.IsNullOrWhiteSpace(Email) &&
                !DateOfBirth.Equals(null);
        }

        private void FinishLoad()
        {
            Thread.Sleep(1000);
            IsEnabled = true;
            LoaderVisibility = Visibility.Collapsed;
        }

        private void OutputPersonData()
        {
            string output = ($"Full name: {Name} {Surname} \n" +
                $"Email: {Email} \n" +
                $"Date of birth: {DateOfBirth.ToShortDateString()} \n" +
                $"Western & Chinese Zodiac: {SunSign}, {ChineseSign}\n" +
                $"You are {Age} years old");

            if (IsBirthday)
                output += ("\nHappy birthday! :D");

            MessageBox.Show(output);
        }

        private void CloseEdit()
        {
            _goToUserList.Invoke();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


