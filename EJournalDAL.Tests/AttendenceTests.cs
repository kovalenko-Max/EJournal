using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Tests
{
    class AttendenceTests
    {
        AttendanceRepository attendanceRepository;

        [SetUp]
        public void Setup()
        {
            attendanceRepository = new AttendanceRepository();
        }

        [TestCaseSource(nameof(DataExpectedCollectionAttendce))]
        public void GetAllStudentsAttendance_WhenCheckAttendance_ShouldShowList(List<AttendanceDTO> expected)
        {
            var attendance = attendanceRepository.GetAllAttendance();

            CollectionAssert.AreEqual(expected, attendance);
        }
        private static IEnumerable<object[]> DataExpectedCollectionAttendce()
        {
            yield return new object[] { new List<AttendanceDTO>()
            {
                new AttendanceDTO(){IdLesson=1010, Topic="ascfe", DateLesson= new DateTime(2021, 06, 09, 17, 58, 45), IsPresence = true, IdStudent =1, Name ="OrlaRandolph"}

            }
            };
        }

    }
}
