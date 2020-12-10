using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    class Benefit
    {
        public int Id { get; set; }
        public int NumberOfStudentCard { get; set; }
        public string TypeOfBenefit { get; set; }
        public string Basis { get; set; }
        public string DateOfIssue { get; set; }

        public Benefit(int id, int numberOfStudentCard, string typeOfBenefit, string basis, string dateOfIssue)
        {
            this.Id = id;
            this.NumberOfStudentCard = numberOfStudentCard;
            this.TypeOfBenefit = typeOfBenefit;
            this.Basis = basis;
            this.DateOfIssue = dateOfIssue;
        }
    }
}
