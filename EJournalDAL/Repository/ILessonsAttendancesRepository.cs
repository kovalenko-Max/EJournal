using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Data;

namespace EJournalDAL.Repository
{
    public interface ILessonsAttendancesRepository
    {
        public int AddLessonAttendances(LessonDTO lessonDTO, DataTable dt);
        public List<LessonDTO> GetLessonsAttendancesByGroup(int groupId);
        public void UpdateLessonsAttendances(LessonDTO lessonDTO, DataTable dt);
        public void DeleteLessonAndAttendances(int id);
    }
}
