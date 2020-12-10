using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    class Faculty
    {
        public int Id { get; set; }
        public string NameOfFaculty { get; set; }
        public string Dean { get; set; }
        public string Deanery { get; set; }

        public Faculty(int id, string nameOfFaculty, string dean, string deanery)
        {
            this.Id = id;
            this.NameOfFaculty = nameOfFaculty;
            this.Dean = dean;
            this.Deanery = deanery;
        }
    }

   
}
