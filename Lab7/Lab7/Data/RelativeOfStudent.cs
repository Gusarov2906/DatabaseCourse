using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    class RelativeOfStudent
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdRelativeType { get; set; }
        public int NumberOfStudentCard { get; set; }

        public RelativeOfStudent(int id, int idPerson, int numberOfStudentCard, int idRelativeType)
        {
            this.Id = id;
            this.IdPerson = idPerson;
            this.IdRelativeType = idRelativeType;
            this.NumberOfStudentCard = numberOfStudentCard;
        }

    }
}
