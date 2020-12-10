using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    class Group
    {
        public string NumberOfGroup { get; set; }
        public int IdFaculty { get; set; }
        public int NumberOfStudents { get; set; }

        public Group(string numberOfGroup, int idFaculty, int numberOfStudents)
        {
            this.NumberOfGroup = numberOfGroup;
            this.IdFaculty = idFaculty;
            this.NumberOfStudents = numberOfStudents;
        }
    }
}
