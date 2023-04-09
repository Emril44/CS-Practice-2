using CS_Practice_2.Models;
using CS_Practice_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice_2.Services
{
    class PersonService
    {
        private static FileRepository Repository = new FileRepository();

        public List<Person> GetAllPeople()
        {
            var res = new List<Person>();

            foreach(var person in Repository.GetAll())
            {
                res.Add(new Person(person.Name, person.Surname, person.Email, person.DateOfBirth));
            }

            return res;
        }
    }
}
