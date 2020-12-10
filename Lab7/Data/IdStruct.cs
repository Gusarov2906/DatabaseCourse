using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    class IdStruct
    {
        public int BenefitId = -1;
        public int FacultyId = -1;
        public string GroupNumber = "";
        public int PersonId = -1;
        public int RelativeOfStudentId = -1;
        public int TypeOfRelativeId = -1;
        public int StudentNum = -1;

        public IdStruct(int personId, int relativeOfStudentId, int typeOfRelativeId, int  studentNum, int benefitId, string groupNum, int facultyId)
        {
            this.PersonId = personId;
            this.RelativeOfStudentId = relativeOfStudentId;
            this.TypeOfRelativeId = typeOfRelativeId;
            this.StudentNum = studentNum;
            this.BenefitId = benefitId;
            this.GroupNumber = groupNum;
            this.FacultyId = facultyId;
        }
    }

}
