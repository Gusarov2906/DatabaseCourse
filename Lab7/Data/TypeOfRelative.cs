using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Data
{
    class TypeOfRelative
    {
        public int Id { get; set; }
        public string NameOfType { get; set; }

        public TypeOfRelative(int id, string nameOfType)
        {
            this.Id = id;
            this.NameOfType = nameOfType;
        }
    }
}
