using CS_Practice_2.Models;
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
    }
}
