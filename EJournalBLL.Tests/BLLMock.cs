using System.Collections.Generic;
using EJournalDAL.Repository;
using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Models;
using System;

namespace EJournalBLL.Tests
{
    public static class BLLMock
    {
        public static LessonDTO GetLessonDTOMock(int iDLesson, int iDGroup, int StartStudentId, int studentsCount)
        {
            const int isPresence = 1;
            const int isNotPresence = 0;
            LessonDTO lessonDTO = new LessonDTO();
            lessonDTO.DateLesson = new DateTime(2021, 05, 21);
            lessonDTO.Id = iDLesson;
            lessonDTO.IdGroup = iDGroup;
            lessonDTO.IsDelete = false;
            lessonDTO.Topic = $"Test topic {iDLesson}";
            lessonDTO.StudentAttendanceDTO = new List<StudentAttendanceDTO>();

            while (StartStudentId <= studentsCount)
            {
                StudentAttendanceDTO studentAttendanceDTO = new StudentAttendanceDTO();

                studentAttendanceDTO.IdLesson = iDLesson;
                studentAttendanceDTO.IdStudent = StartStudentId;
                studentAttendanceDTO.IsPresence = 1;
                studentAttendanceDTO.Name = $"Name {StartStudentId}";
                studentAttendanceDTO.Surname = $"Surname {StartStudentId}";
                lessonDTO.StudentAttendanceDTO.Add(studentAttendanceDTO);
                ++StartStudentId;
            }

            return lessonDTO;
        }

        public static Lesson GetLesson(int iDLesson, int iDGroup, int StartStudentId, int studentsCount)
        {
            Lesson lesson = new Lesson();
            lesson.DateLesson = new DateTime(2021, 05, 21);
            lesson.Id = iDLesson;
            lesson.IdGroup = iDGroup;
            lesson.Topic = $"Test topic {iDLesson}";
            lesson.Attendances = new List<Attendances>();

            while (StartStudentId <= studentsCount)
            {
                Attendances attendance = new Attendances(GetStudent(StartStudentId));
                attendance.isPresent = true;
                lesson.Attendances.Add(attendance);
                ++StartStudentId;
            }

            return lesson;
        }

        public static Student GetStudent(int idStudent)
        {
            return new Student($"Name {idStudent}", $"Surname {idStudent}") { Id = idStudent };
        }

        public static Course GetCourseMock(int iDCourse)
        {
            return new Course($"Course {iDCourse}")
            {
                Id = iDCourse
            };
        }

        public static CourseDTO GetCourseDTOMock(int iDCourse)
        {
            return new CourseDTO()
            {
                Name = $"Course {iDCourse}",
                Id = iDCourse
            };
        }
    }
}
