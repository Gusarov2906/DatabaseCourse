using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    class Person
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public Person(int id, string surname, string name, string patronymic, string dateOfBirth, string gender, string address)
        {
            this.Id = id;
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Address = address;
        }
    }
}
