using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Data;

namespace EJournalDAL.Repository
{
    public interface ILessonsAttendancesRepository
    {
        public int AddStudentsAttendance(LessonDTO lessonDTO, DataTable dt);
        public List<LessonDTO> GetStudentsAttendancesByGroup(int groupId);
        public void UpdateStudentsAttendances(LessonDTO lessonDTO, DataTable dt);
        public void DeleteLessonAndStudentsAttendances(int id);
    }
}
