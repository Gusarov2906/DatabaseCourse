using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    class Student
    {
        public int NumberOfStudentCard { get; set; }
        public int IdPerson { get; set; }
        public string NumberOfGroup { get; set; }

        public Student(int numberOfStudentCard, int idPerson, string numberOfGroup)
        {
            this.NumberOfStudentCard = numberOfStudentCard;
            this.IdPerson = idPerson;
            this.NumberOfGroup = numberOfGroup;
        }

    }
}
