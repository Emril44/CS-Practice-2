using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice_2.Models
{
    class DBPerson
    {
        public DBPerson(string name, string surname, string email, DateTime dob, int age, string westZodiac, string eastZodiac, bool isBirthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dob;
            Age = age;
            WestZodiac = westZodiac;
            EastZodiac= eastZodiac;
            IsBirthday = isBirthday;
        }

        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public DateTime DateOfBirth { get; }
        public int Age { get; }
        public string WestZodiac { get; }
        public string EastZodiac { get; }
        public bool IsBirthday { get; }
    }
}
