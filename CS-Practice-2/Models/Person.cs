using System;
using System.Threading;

namespace CS_Practice_2.Models
{
    internal class Person
    {
        #region Aux
        private static readonly string[] names = { "Jake", "Aaron", "Paul", "Adam", "Kel" };
        private static readonly string[] surnames = { "Taylor", "Sandler", "Cage", "Harris", "Davis" };
        #endregion

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


        public static Person GenerateRandomPerson()
        {
            Random rand = new();
            string name = names[rand.Next(0, names.Length)];
			string surname = surnames[rand.Next(0, surnames.Length)];

			string? email = "toolazytorandomizethis@gmail.com";
			DateTime? dob = new(rand.Next(1900, 2022), rand.Next(1, 13), rand.Next(1, 29));

			Person newPerson = new()
            {
				Name = name,
				Surname = surname,
				Email = email,
				DateOfBirth = dob,
			};

            newPerson.CalculateAge();
            newPerson.WestZodiac = newPerson.GetSunSign();
            newPerson.EastZodiac = newPerson.GetChineseSign();
            newPerson.IsBirthday = newPerson.IsItBirthday();

            return newPerson;
		}

        public bool IsItBirthday()
        {
            if (DateOfBirth == null)
                return false;

            var today = DateTime.Today;
            return (DateOfBirth.Value.Day == today.Day) && (DateOfBirth.Value.Month == today.Month);
        }

        public void CalculateAge()
        {
            if (DateOfBirth == null)
                return;

            var today = DateTime.Today;

            int age = (int)((today - DateOfBirth).Value.TotalDays / 365.242199);

            Age = age;
            ValidateAge(Age);
        }

        public string GetSunSign()
        {
            if(DateOfBirth == null)
                return "a";

            int month = DateOfBirth.Value.Month;
            int day = DateOfBirth.Value.Day;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";

                case 3:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";

                case 4:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";

                case 5:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";

                case 6:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";

                case 7:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";

                case 8:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";

                case 9:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";

                case 10:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";

                case 11:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";

                case 12:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";

                default:
                    return "";
            }
        }

        public string GetChineseSign()
        {
            if (DateOfBirth == null)
                return "";

            return (DateOfBirth.Value.Year % 12) switch
            {
                0 => "Monkey",
                1 => "Rooster",
                2 => "Dog",
                3 => "Pig",
                4 => "Rat",
                5 => "Ox",
                6 => "Tiger",
                7 => "Rabbit",
                8 => "Dragon",
                9 => "Snake",
                10 => "Horse",
                11 => "Goat",
                _ => "",
            };
        }

        public static void ValidateAge(int? age)
        {
            if (age == null)
                return;

            if (age <= 0)
            {
                throw new DateOfBirthUnreachedException();
            }

            else if (age >= 150)
            {
                throw new AgeTooOldException();
            }
        }

        public static void ValidateEmail(string? email)
        {
            if (email == null)
                return;

            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                throw new InvalidPersonEmailException(email);
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
            }
            catch (FormatException)
            {
                throw new InvalidPersonEmailException(email);
            }
        }
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