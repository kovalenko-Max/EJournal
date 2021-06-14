using EJournalDAL.Repository;
using EJournalDAL.Models.BaseModels;
using NUnit.Framework;
using System.Collections.Generic;
using EJournalBLL.Models;
using System.Collections;

namespace EJournalBLL.Tests
{
    public class Tests
    {

        [TestCaseSource(typeof(GetStudentDataSource))]
        public void StudentDTO_WhenMapToStudent_ShouldMapCorrectly (StudentDTO studentDTO, Student expectedStudent)
        {
            var result = ObjectMapper.Mapper.Map<Student>(studentDTO);

            Assert.AreEqual(expectedStudent, result);
        }

        [TestCaseSource(typeof(GetCommentDataSource))]
        public void CommentDTO_WhenMapToComments_ShouldMapCorrectly(CommentDTO commentDTO, Comment expectedComment)
        {
            var result = ObjectMapper.Mapper.Map<Comment>(commentDTO);

            Assert.AreEqual(expectedComment, result);
        }

        [TestCaseSource(typeof(GetProjectDataSource))]
        public void ProjectDTO_WhenMapToProject_ShouldMapCorrectly(ProjectDTO projectDTO, Project expectedProject)
        {
            var result = ObjectMapper.Mapper.Map<Project>(projectDTO);

            Assert.AreEqual(expectedProject, result);
        }

        [TestCaseSource(typeof(GetProjectGroupDataSource))]
        public void ProjectGroupDTO_WhenMapToProjectGroup_ShouldMapCorrectly(ProjectGroupDTO projectGroupDTO, ProjectGroup expectedProjectGroup)
        {
            var result = ObjectMapper.Mapper.Map<ProjectGroup>(projectGroupDTO);

            Assert.AreEqual(expectedProjectGroup, result);
        }

        [TestCaseSource(typeof(GetExerciseDataSource))]
        public void ExerciseDTO_WhenMapToExercise_ShouldMapCorrectly(ExerciseDTO exerciseDTO, Exercise expectedExercise)
        {
            var result = ObjectMapper.Mapper.Map<Exercise>(exerciseDTO);

            Assert.AreEqual(expectedExercise, result);
        }

        [TestCaseSource(typeof(GetLessonDataSource))]
        public void LessonDTO_WhenMapToLesson_ShouldMapCorrectly(LessonDTO lessonDTO, Lesson expectedlesson)
        {
            var result = ObjectMapper.Mapper.Map<Lesson>(lessonDTO);

            Assert.AreEqual(expectedlesson, result);
        }

        [TestCaseSource(typeof(GetCourseDataSource))]
        public void CourseDTO_WhenMapToCourse_ShouldMapCorrectly(CourseDTO courseDTO, Course expectedCourse)
        {
            var result = ObjectMapper.Mapper.Map<Course>(courseDTO);

            Assert.AreEqual(expectedCourse, result);
        }

        [TestCaseSource(typeof(GetGroupDataSource))]
        public void GroupDTO_WhenMapToGroup_ShouldMapCorrectly(GroupDTO GroupDTO, Group expectedGroup)
        {
            var result = ObjectMapper.Mapper.Map<Group>(GroupDTO);

            Assert.AreEqual(expectedGroup, result);
        }

        [TestCaseSource(typeof(GetProjectGroupStudentDataSource))]
        public void ProjectGroupStudent_WhenMapToProjectGroupStudentDTO_ShouldMapCorrectly(ProjectGroupStudent projectGroupStudent
            , ProjectGroupStudentDTO expectedprojectGroupStudentDTO)
        {
            var result = ObjectMapper.Mapper.Map<ProjectGroupStudentDTO>(projectGroupStudent);

            Assert.AreEqual(expectedprojectGroupStudentDTO, result);
        }

        [TestCaseSource(typeof(GetStudentDTODataSource))]
        public void Student_WhenMapToStudentDTO_ShouldMapCorrectly(Student student, StudentDTO expectedStudentDTO)
        {
            var result = ObjectMapper.Mapper.Map<StudentDTO>(student);

            Assert.AreEqual(expectedStudentDTO, result);
        }

        [TestCaseSource(typeof(GetCommentDTODataSource))]
        public void Comment_WhenMapToCommentDTO_ShouldMapCorrectly(Comment comment, CommentDTO expectedCommentDTO)
        {
            var result = ObjectMapper.Mapper.Map<CommentDTO>(comment);

            Assert.AreEqual(expectedCommentDTO, result);
        }

        [TestCaseSource(typeof(GetProjectDTODataSource))]
        public void Project_WhenMapToProjectDTO_ShouldMapCorrectly(Project project, ProjectDTO expectedProjectDTO)
        {
            var result = ObjectMapper.Mapper.Map<ProjectDTO>(project);

            Assert.AreEqual(expectedProjectDTO, result);
        }

        [TestCaseSource(typeof(GetProjectGroupDTODataSource))]
        public void ProjectGroup_WhenMapToProjectGroupDTO_ShouldMapCorrectly(ProjectGroup projectGroup, ProjectGroupDTO expectedProjectGroupDTO)
        {
            var result = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroup);

            Assert.AreEqual(expectedProjectGroupDTO, result);
        }

        [TestCaseSource(typeof(GetExerciseDTODataSource))]
        public void Exercise_WhenMapToExerciseDTO_ShouldMapCorrectly(Exercise exercise, ExerciseDTO expectedExerciseDTO)
        {
            var result = ObjectMapper.Mapper.Map<ExerciseDTO>(exercise);

            Assert.AreEqual(expectedExerciseDTO, result);
        }

        [TestCaseSource(typeof(GetLessonDTODataSource))]
        public void Lesson_WhenMapToLessonDTO_ShouldMapCorrectly(Lesson lesson, LessonDTO expectedlessonDTO)
        {
            var result = ObjectMapper.Mapper.Map<LessonDTO>(lesson);

            Assert.AreEqual(expectedlessonDTO, result);
        }

        [TestCaseSource(typeof(GetCourseDTODataSource))]
        public void Course_WhenMapToCourseDTO_ShouldMapCorrectly(Course course, CourseDTO expectedCourseDTO)
        {
            var result = ObjectMapper.Mapper.Map<CourseDTO>(course);

            Assert.AreEqual(expectedCourseDTO, result);
        }

        [TestCaseSource(typeof(GetGroupDTODataSource))]
        public void Group_WhenMapToGroupDTO_ShouldMapCorrectly(Group group, GroupDTO expectedGroupDTO)
        {
            var result = ObjectMapper.Mapper.Map<GroupDTO>(group);

            Assert.AreEqual(expectedGroupDTO, result);
        }

        [TestCaseSource(typeof(GetAttandanceDTODataSource))]
        public void Attendance_WhenMapToCourseDTO_ShouldMapCorrectly(Attendances attandance, AttendanceDTO expectedAttandanceDTO)
        {
            var result = ObjectMapper.Mapper.Map<AttendanceDTO>(attandance);

            Assert.AreEqual(expectedAttandanceDTO, result);
        }

        public class GetStudentDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                StudentDTO studentDTO = BLLMock.GetStudentDTOMock(1);
                Student student = BLLMock.GetStudentMock(1);

                yield return new object[]
                {
                    studentDTO,
                    student
                };

               studentDTO = BLLMock.GetStudentDTOMock(3);
               student = BLLMock.GetStudentMock(3);

                yield return new object[]
                {
                    studentDTO,
                    student
                };

                studentDTO = BLLMock.GetStudentDTOMock(15);
                student = BLLMock.GetStudentMock(15);

                yield return new object[]
                {
                    studentDTO,
                    student
                };
            }
        }
        public class GetCommentDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                CommentDTO commentDTO = BLLMock.GetCommentDTOMock(1);
                Comment comment = BLLMock.GetCommenMock(1);

                yield return new object[]
                {
                    commentDTO,
                    comment
                };

                commentDTO = BLLMock.GetCommentDTOMock(3);
                comment = BLLMock.GetCommenMock(3);

                yield return new object[]
                {
                    commentDTO,
                    comment
                };

                commentDTO = BLLMock.GetCommentDTOMock(11);
                comment = BLLMock.GetCommenMock(11);

                yield return new object[]
                {
                    commentDTO,
                    comment
                };
            }
        }
        
        public class GetProjectDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {

                ProjectDTO projectDTO = BLLMock.GetProjectDTOMock(1);
                Project project = BLLMock.GetProjectMock(1);

                yield return new object[]
                {
                    projectDTO,
                    project
                };

                projectDTO = BLLMock.GetProjectDTOMock(4);
                project = BLLMock.GetProjectMock(4);

                yield return new object[]
                {
                    projectDTO,
                    project
                };

                projectDTO = BLLMock.GetProjectDTOMock(14);
                project = BLLMock.GetProjectMock(14);

                yield return new object[]
                {
                    projectDTO,
                    project
                };
            }
        }

        public class GetProjectGroupDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                ProjectGroupDTO projectDTO = BLLMock.GetProjectGroupDTOMock(1);
                ProjectGroup project = BLLMock.GetProjectGroupeMock(1);

                yield return new object[]
                {
                    projectDTO,
                    project
                };

                projectDTO = BLLMock.GetProjectGroupDTOMock(9);
                project = BLLMock.GetProjectGroupeMock(9);


                yield return new object[]
                {
                    projectDTO,
                    project
                };

                projectDTO = BLLMock.GetProjectGroupDTOMock(20);
                project = BLLMock.GetProjectGroupeMock(20);

                yield return new object[]
                {
                    projectDTO,
                    project
                };
            }
        }

        public class GetExerciseDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                ExerciseDTO projectDTO = BLLMock.GetExerciseDTOMock(1);
                Exercise project = BLLMock.GetExerciseMock(1);

                yield return new object[]
                {
                    projectDTO,
                    project
                };

                projectDTO = BLLMock.GetExerciseDTOMock(8);
                project = BLLMock.GetExerciseMock(8);

                yield return new object[]
                {
                    projectDTO,
                    project
                };

                projectDTO = BLLMock.GetExerciseDTOMock(11);
                project = BLLMock.GetExerciseMock(11);

                yield return new object[]
                {
                    projectDTO,
                    project
                };
            }
        }

        public class GetLessonDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                LessonDTO lessonDTO = BLLMock.GetLessonDTOMock(1,2,0,0);
                Lesson lesson= BLLMock.GetLesson(1, 2, 0, 0);

                yield return new object[]
                {
                    lessonDTO,
                    lesson
                };

                lessonDTO = BLLMock.GetLessonDTOMock(3, 4, 0, 0);
                lesson = BLLMock.GetLesson(3, 4, 0, 0);

                yield return new object[]
                {
                    lessonDTO,
                    lesson
                };

                lessonDTO = BLLMock.GetLessonDTOMock(5, 5, 0, 0);
                lesson = BLLMock.GetLesson(5,5,0,0);

                yield return new object[]
                {
                    lessonDTO,
                    lesson
                };
            }
        }

        public class GetCourseDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                CourseDTO courseDTO = BLLMock.GetCourseDTOMock(2);
                Course course = BLLMock.GetCourseMock(2);

                yield return new object[]
                {
                    courseDTO,
                    course
                };

                courseDTO = BLLMock.GetCourseDTOMock(5);
                course = BLLMock.GetCourseMock(5);

                yield return new object[]
                {
                    courseDTO,
                    course
                };

                courseDTO = BLLMock.GetCourseDTOMock(5);
                course = BLLMock.GetCourseMock(5);

                yield return new object[]
                {
                    courseDTO,
                    course
                };
            }
        }

        public class GetGroupDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                GroupDTO groupDTO = BLLMock.GetGroupDTOMock(4);
                Group course = BLLMock.GetGroupMock(4);

                yield return new object[]
                {
                    groupDTO,
                    course
                };

                groupDTO = BLLMock.GetGroupDTOMock(10);
                course = BLLMock.GetGroupMock(10);

                yield return new object[]
                {
                    groupDTO,
                    course
                };

                groupDTO = BLLMock.GetGroupDTOMock(50);
                course = BLLMock.GetGroupMock(50);

                yield return new object[]
                {
                    groupDTO,
                    course
                };
            }
        }

        public class GetProjectGroupStudentDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                ProjectGroupStudent projectGroupStudent = BLLMock.GetProjectGroupStudentMock(5);
                ProjectGroupStudentDTO projectGroupStudentDTO = BLLMock.GetProjectGroupStudentDTOMock(5);

                yield return new object[]
                {
                    projectGroupStudent,
                    projectGroupStudentDTO
                };

                projectGroupStudent = BLLMock.GetProjectGroupStudentMock(15);
                projectGroupStudentDTO = BLLMock.GetProjectGroupStudentDTOMock(15);

                yield return new object[]
                {
                    projectGroupStudent,
                    projectGroupStudentDTO
                };

                projectGroupStudent = BLLMock.GetProjectGroupStudentMock(25);
                projectGroupStudentDTO = BLLMock.GetProjectGroupStudentDTOMock(25);

                yield return new object[]
                {
                    projectGroupStudent,
                    projectGroupStudentDTO
                };
            }
        }

        public class GetStudentDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Student student = BLLMock.GetStudentMock(1);
                StudentDTO studentDTO = BLLMock.GetStudentDTOMock(1);

                yield return new object[]
                {
                    student,
                    studentDTO
                };

                student = BLLMock.GetStudentMock(3);
                studentDTO = BLLMock.GetStudentDTOMock(3);

                yield return new object[]
                {
                    student,
                    studentDTO
                };

                student = BLLMock.GetStudentMock(15);
                studentDTO = BLLMock.GetStudentDTOMock(15);

                yield return new object[]
                {
                    student,
                    studentDTO
                };
            }
        }

        public class GetCommentDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Comment comment = BLLMock.GetCommenMock(1);
                CommentDTO commentDTO = BLLMock.GetCommentDTOMock(1);

                yield return new object[]
                {
                    comment,
                    commentDTO
                };

                comment = BLLMock.GetCommenMock(3);
                commentDTO = BLLMock.GetCommentDTOMock(3);

                yield return new object[]
                {
                    comment,
                    commentDTO
                };

                comment = BLLMock.GetCommenMock(11);
                commentDTO = BLLMock.GetCommentDTOMock(11);

                yield return new object[]
                {
                    comment,
                    commentDTO
                };
            }
        }
       
        public class GetProjectDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Project project = BLLMock.GetProjectMock(1);
                ProjectDTO projectDTO = BLLMock.GetProjectDTOMock(1);

                yield return new object[]
                {
                    project,
                    projectDTO
                };

                project = BLLMock.GetProjectMock(4);
                projectDTO = BLLMock.GetProjectDTOMock(4);

                yield return new object[]
                {
                    project,
                    projectDTO
                };

                project = BLLMock.GetProjectMock(14);
                projectDTO = BLLMock.GetProjectDTOMock(14);

                yield return new object[]
                {
                    project,
                    projectDTO
                };
            }
        }

        public class GetProjectGroupDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                ProjectGroup project = BLLMock.GetProjectGroupeMock(1);
                ProjectGroupDTO projectDTO = BLLMock.GetProjectGroupDTOMock(1);

                yield return new object[]
                {
                    project,
                    projectDTO
                };

                project = BLLMock.GetProjectGroupeMock(9);
                projectDTO = BLLMock.GetProjectGroupDTOMock(9);


                yield return new object[]
                {
                    project,
                    projectDTO
                };

                project = BLLMock.GetProjectGroupeMock(20);
                projectDTO = BLLMock.GetProjectGroupDTOMock(20);

                yield return new object[]
                {
                    project,
                    projectDTO
                };
            }
        }

        public class GetExerciseDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Exercise project = BLLMock.GetExerciseMock(1);
                ExerciseDTO projectDTO = BLLMock.GetExerciseDTOMock(1);

                yield return new object[]
                {
                    project,
                    projectDTO
                };

                project = BLLMock.GetExerciseMock(8);
                projectDTO = BLLMock.GetExerciseDTOMock(8);


                yield return new object[]
                {
                    project,
                    projectDTO
                };

                project = BLLMock.GetExerciseMock(11);
                projectDTO = BLLMock.GetExerciseDTOMock(11);

                yield return new object[]
                {
                    project,
                    projectDTO
                };
            }
        }

        public class GetLessonDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Lesson lesson = BLLMock.GetLesson(1, 2, 3, 4);
                LessonDTO lessonDTO = BLLMock.GetLessonDTOMock(1, 2, 3, 4);

                yield return new object[]
                {
                    lesson,
                    lessonDTO
                };

                lesson = BLLMock.GetLesson(3, 4, 3, 4);
                lessonDTO = BLLMock.GetLessonDTOMock(3, 4, 3, 4);


                yield return new object[]
                {
                    lesson,
                    lessonDTO
                };

                lesson = BLLMock.GetLesson(5, 5, 5, 5);
                lessonDTO = BLLMock.GetLessonDTOMock(5, 5, 5, 5);

                yield return new object[]
                {
                   lesson,
                    lessonDTO
                };
            }
        }

        public class GetCourseDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Course course = BLLMock.GetCourseMock(2);
                CourseDTO courseDTO = BLLMock.GetCourseDTOMock(2);

                yield return new object[]
                {
                    course,
                    courseDTO
                };

                course = BLLMock.GetCourseMock(5);
                courseDTO = BLLMock.GetCourseDTOMock(5);


                yield return new object[]
                {
                    course,
                    courseDTO
                };

                course = BLLMock.GetCourseMock(5);
                courseDTO = BLLMock.GetCourseDTOMock(5);

                yield return new object[]
                {
                    course,
                    courseDTO
                };
            }
        }

        public class GetGroupDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Group group = BLLMock.GetGroupMock(4);
                GroupDTO groupDTO = BLLMock.GetGroupDTOMock(4);

                yield return new object[]
                {
                    group,
                    groupDTO
                };

                group = BLLMock.GetGroupMock(10);
                groupDTO = BLLMock.GetGroupDTOMock(10);

                yield return new object[]
                {
                    group,
                    groupDTO
                };

                group = BLLMock.GetGroupMock(50);
                groupDTO = BLLMock.GetGroupDTOMock(50);

                yield return new object[]
                {
                    group,
                    groupDTO
                };
            }
        }

        public class GetAttandanceDTODataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Attendances attandance = BLLMock.GetAttendancesMock(10);
                AttendanceDTO attandanceDTO = BLLMock.GetAttendanceDTOMock(10);

                yield return new object[]
                {
                    attandance,
                    attandanceDTO
                };

                attandance = BLLMock.GetAttendancesMock(30);
                attandanceDTO = BLLMock.GetAttendanceDTOMock(30);

                yield return new object[]
                {
                    attandance,
                    attandanceDTO
                };

                attandance = BLLMock.GetAttendancesMock(20);
                attandanceDTO = BLLMock.GetAttendanceDTOMock(20);

                yield return new object[]
                {
                    attandance,
                    attandanceDTO
                };
            }
        }

    }
}
