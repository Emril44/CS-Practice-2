using System;

namespace CS_Practice_2.Models
{
    internal class Person
    {
		#region Fields
        private string _name;
		private string _surname;
		private string? _email;
		private DateTime? _dateOfBirth;
		private int? _age;
		private string? _westZodiac;
		private string? _eastZodiac;
		private bool? _isBirthday;
		#endregion

		#region Properties
		public string Name
		{
			get { return _name; } set { _name = value; }
		}

		public string Surname
		{
			get { return _surname; } set { _surname = value; }
		}

		public string? Email
		{
			get { return _email; } set { _email = value; }
		}

		public DateTime? DateOfBirth
		{
			get { return _dateOfBirth; } set { _dateOfBirth = value; }
		}

		public int? Age
		{
			get { return _age; } set { _age = value; }
		}

		public string? WestZodiac
		{
			get { return _westZodiac; } set { _westZodiac = value; }
		}

		public string? EastZodiac
		{
			get { return _eastZodiac; } set { _eastZodiac = value; }
		}

		public bool? IsBirthday
		{
			get { return _isBirthday; } set { _isBirthday = value; }
		}
		#endregion

		public Person() { _name = ""; _surname = ""; }

		public Person(string name, string surname, string? email, DateTime? dob)
		{
			_name = name;
			_surname = surname;
			_email = email;
			_dateOfBirth = dob;
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