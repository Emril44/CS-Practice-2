using System;

namespace CS_Practice_2.Models
{
    internal class Person
    {
		#region Fields
		private Person _person;
        private string _name;
		private string _surname;
		private string? _email;
		private DateTime? _dateOfBirth;
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

		public string? Email
		{
			get { return _email; }
			set { _email = value; }
		}

		public DateTime? DateOfBirth
		{
			get { return _dateOfBirth; }
			set { _dateOfBirth = value; }
		}
		#endregion

		public Person() { }

		public Person(string name, string surname, string? email, DateTime? dob)
		{
			_person = new()
			{
				_name = name,
				_surname = surname,
				_email = email,
				_dateOfBirth = dob
			};
		}

		public Person(string name, string surname, string email) : this(name, surname, email, null) { }
		public Person(string name, string surname, DateTime dob) : this(name, surname, null, dob) { }
    }

	class InvalidPersonEmailException : Exception
	{
		public InvalidPersonEmailException(string email) :
			base(String.Format("Invalid email: {0}", email))
		{ }
	}

    class AgeTooOldException : Exception
    {
        public AgeTooOldException() { }
    }

    class DateOfBirthUnreachedException : Exception
    {
        public DateOfBirthUnreachedException() { }
    }
}