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

            if (studentsCount > 0)
            {
                while (StartStudentId <= studentsCount)
                {
                    Attendances attendance = new Attendances(GetStudent(StartStudentId));
                    attendance.isPresent = true;
                    lesson.Attendances.Add(attendance);
                    ++StartStudentId;
                }
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
        public static Project GetProjectMock(int IdProject)
        {

            return new Project($"Name{IdProject}", $"Description{IdProject}")
            {
                Id = IdProject

            };
        }

        public static ProjectDTO GetProjectDTOMock(int IdProject)
        {
            return new ProjectDTO()
            {
                Name = $"Name{IdProject}",
                Id = IdProject,
                Description = $"Description{IdProject}",
            };
        }

        public static StudentDTO GetStudentDTOMock(int IdStudent)
        {

            return new StudentDTO()
            {
                Id = IdStudent,
                Name = $"Name{IdStudent}",
                Surname = $"Surname{IdStudent}",
                AgreementNumber = $"AgreementNumber{IdStudent}",
                City = $"City{IdStudent}",
                Email = $"Email{IdStudent}",
                Phone = $"Phone{IdStudent}",
                Git = $"Git{IdStudent}",
                Ranking = IdStudent,
                IsDelete = false,
                comments = new List<CommentDTO>()

            };
        }

        public static Student GetStudentMock(int IdStudent)
        {
            return new Student(
                $"Name{IdStudent}",
                $"Surname{IdStudent}",
                $"Email{IdStudent}",
                $"Phone{IdStudent}",
                $"Git{IdStudent}",
                $"City{IdStudent}",
                $"AgreementNumber{IdStudent}")
            {
                Id = IdStudent,
                IsDelete = false,
                Ranking = IdStudent,
                Comments = new List<Comments>()
            };
        }

        public static CommentDTO GetCommentDTOMock(int IdComment)
        {
            return new CommentDTO()
            {
                Id = IdComment,
                Comment = $"Comment{IdComment}",
                Students = new List<StudentDTO>(),
                IdCommentType = IdComment
            };
        }

        public static Comments GetCommenMock(int IdComment)
        {
            return new Comments($"Comment{IdComment}", IdComment)
            {
                Id = IdComment,
                Students = new List<Student>()
            };
        }

        public static CommentTypeDTO GetCommenTypetDTOMock(int IdCommentTYpe)
        {
            return new CommentTypeDTO()
            {
                Id = IdCommentTYpe,
                Type = $"CommentType{IdCommentTYpe}"
            };
        }

        public static CommentType GetCommenTypeMock(int IdCommentTYpe)
        {
            return new CommentType($"CommentType{IdCommentTYpe}")
            {
                Id = IdCommentTYpe
            };
        }

        public static ProjectGroupDTO GetProjectGroupDTOMock(int IdProjectGroupe)
        {
            return new ProjectGroupDTO()
            {
                Id = IdProjectGroupe,
                Name = $"Name{IdProjectGroupe}",
                IdProject = IdProjectGroupe,
                Students = new List<StudentDTO>()
            };
        }

        public static ProjectGroup GetProjectGroupeMock(int IdProjectGroupe)
        {
            return new ProjectGroup($"Name{IdProjectGroupe}")
            {
                Id = IdProjectGroupe,
                IdProject = IdProjectGroupe,
                Students = new List<Student>()
            };
        }
        public static ExerciseDTO GetExerciseDTOMock(int IdExercise)
        {
            return new ExerciseDTO()
            {
                Id = IdExercise,
                Deadline = new DateTime(11, 11, 11),
                Description = $"Description{IdExercise}",
                ExerciseType = $"Hard{IdExercise}",
                IdGroup = IdExercise
            };
        }

        public static Exercise GetExerciseMock(int IdExercise)
        {
            return new Exercise()
            {
                Id = IdExercise,
                Deadline = new DateTime(11, 11, 11),
                Description = $"Description{IdExercise}",
                ExerciseType = $"Hard{IdExercise}",
                IdGroup = IdExercise
            };
        }

        public static GroupDTO GetGroupDTOMock(int IdGroup)
        {
            return new GroupDTO()
            {
                Id = IdGroup,
                Course = new CourseDTO(),
                IsDelete = false,
                IsFinish = false,
                Name = $"Name{IdGroup}",
                StudentsCount = IdGroup,


            };
        }

        public static Group GetGroupMock(int IdGroup)
        {
            return new Group()
            {
                Id = IdGroup,
                Course = new Course(),
                IsFinish = false,
                Name = $"Name{IdGroup}",
                StudentsCount = IdGroup
            };
        }

        public static ProjectGroupStudentDTO GetProjectGroupStudentDTOMock(int Id)
        {
            return new ProjectGroupStudentDTO()
            {
                IdProjectGroup = Id,
                IdStudent = Id + 1
            };
        }

        public static ProjectGroupStudent GetProjectGroupStudentMock(int Id)
        {
            return new ProjectGroupStudent()
            {
                IdProjectGroup = Id,
                IdStudent = Id + 1
            };
        }

        public static AttendanceDTO GetAttendanceDTOMock(int Id)
        {
            return new AttendanceDTO()
            {
                StudentDTO = new StudentDTO() { Name = "Name", Surname = "Surname", Email = "email", City = "city", Id = 1, AgreementNumber = "AN", Git = "git", IsDelete = false, Phone = "098031547", Ranking = 10, comments = new List<CommentDTO>() },
                IsPresence = true
            };
        }

        public static Attendances GetAttendancesMock(int Id)
        {
            return new Attendances()
            {
                Student = new Student() { Name = "Name", Surname = "Surname", Email = "email", City = "city", Id = 1, AgreementNumber = "AN", Git = "git", IsDelete = false, Phone = "098031547", Ranking = 10, Comments = new List<Comments>() },
                isPresent = true
            };
        }
    }
}
