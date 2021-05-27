using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL
{
    public class Course
    {
        public string Name;

        public Course(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
