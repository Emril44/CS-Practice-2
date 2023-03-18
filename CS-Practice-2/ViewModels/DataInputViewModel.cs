using CS_Practice_2.Models;
using CS_Practice_2.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice_2.ViewModels
{
    internal class DataInputViewModel
    {
        private User _user = new User();
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;

        public string Name
        {
            get { return _user.Name; }
            set { _user.Name = value; }
        }

        public string Surname
        {
            get { return _user.Surname; }
            set { _user.Surname = value; }
        }

        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _user.DateOfBirth; }
            set { _user.DateOfBirth = value; }
        }

        public RelayCommand<object> ProceedCommand
        {
            get { return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute); }
        }

        public RelayCommand<object> CancelCommand
        {
            get { return _cancelCommand ??= new RelayCommand<object>(_ => Environment.Exit(0)); }
        }

        private void Proceed()
        {

        }

        private bool CanExecute(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
