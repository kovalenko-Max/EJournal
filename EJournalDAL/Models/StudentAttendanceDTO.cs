using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class StudentAttendanceDTO
    {
        public int IdStudent;
        public string Name;
        public string Surname;
        public int IsPresence;
    }
}
