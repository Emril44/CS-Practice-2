using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice_2.Models
{
    internal class User
    {
        #region Fields
        private string _name;
		private string _surname;
		private string _email;
		private DateTime _dateOfBirth;
		#endregion

		#region Properties
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Surname
		{
			get { return _surname; }
			set { _surname = value; }
		}

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		public DateTime DateOfBirth
		{
			get { return _dateOfBirth; }
			set { _dateOfBirth = value; }
		}
		#endregion
	}
}
