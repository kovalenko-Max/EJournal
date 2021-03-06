using AutoMapper;
using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;

namespace EJournalBLL
{
    public class ObjectMapper
    {
        private static IMapper _config;
        public static IMapper Mapper
        {
            get
            {
                if (_config == null)
                {
                    _config = Initialize();
                }
                return _config;
            }
        }

        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.Surname, map => map.MapFrom(source => source.Surname))
                    .ForMember(dto => dto.Phone, map => map.MapFrom(source => source.Phone))
                    .ForMember(dto => dto.Email, map => map.MapFrom(source => source.Email))
                    .ForMember(dto => dto.Git, map => map.MapFrom(source => source.Git))
                    .ForMember(dto => dto.Ranking, map => map.MapFrom(source => source.Ranking))
                    .ForMember(dto => dto.TeacherAssessment, map => map.MapFrom(source => source.TeacherAssessment))
                    .ForMember(dto => dto.City, map => map.MapFrom(source => source.City))
                    .ForMember(dto => dto.Comments, map => map.MapFrom(source => source.comments))
                    .ForMember(dto => dto.AgreementNumber, map => map.MapFrom(source => source.AgreementNumber))
                    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<Student, StudentDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.Surname, map => map.MapFrom(source => source.Surname))
                    .ForMember(dto => dto.Phone, map => map.MapFrom(source => source.Phone))
                    .ForMember(dto => dto.Email, map => map.MapFrom(source => source.Email))
                    .ForMember(dto => dto.Git, map => map.MapFrom(source => source.Git))
                    .ForMember(dto => dto.TeacherAssessment, map => map.MapFrom(source => source.TeacherAssessment))
                    .ForMember(dto => dto.Ranking, map => map.MapFrom(source => source.Ranking))
                    .ForMember(dto => dto.City, map => map.MapFrom(source => source.City))
                    .ForMember(dto => dto.comments, map => map.MapFrom(source => source.Comments))
                    .ForMember(dto => dto.AgreementNumber, map => map.MapFrom(source => source.AgreementNumber))
                    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<ProjectDTO, Project>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description));

                cfg.CreateMap<ProjectGroupDTO, ProjectGroup>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.IdProject, map => map.MapFrom(source => source.IdProject))
                    .ForMember(dto => dto.Students, map => map.MapFrom(source => source.Students));

                cfg.CreateMap<ExerciseDTO, Exercise>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description))
                    .ForMember(dto => dto.Deadline, map => map.MapFrom(source => source.Deadline))
                    .ForMember(dto => dto.ExerciseType, map => map.MapFrom(source => source.ExerciseType))
                    .ForMember(dto => dto.IdGroup, map => map.MapFrom(source => source.IdGroup))
                    .ForMember(dto => dto.StudentMarks, map => map.MapFrom(source => source.StudentsExercisesDTO));


                cfg.CreateMap<LessonDTO, Lesson>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Topic, map => map.MapFrom(source => source.Topic))
                   .ForMember(dto => dto.DateLesson, map => map.MapFrom(source => source.DateLesson))
                   .ForMember(dto => dto.IdGroup, map => map.MapFrom(source => source.IdGroup));

                cfg.CreateMap<CourseDTO, Course>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(sourse => sourse.Id))
                     .ForMember(dto => dto.Name, map => map.MapFrom(sourse => sourse.Name));

                cfg.CreateMap<GroupDTO, Group>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                   .ForMember(dto => dto.IsFinish, map => map.MapFrom(source => source.IsFinish))
                   .ForMember(dto => dto.StudentsCount, map => map.MapFrom(source => source.StudentsCount))
                   .ForMember(dto => dto.Course, map => map.MapFrom(source => source.Course));

                cfg.CreateMap<AttendanceDTO, Attendances>()
                    .ForMember(dto => dto.isPresent, map => map.MapFrom(sourse => sourse.IsPresence))
                     .ForMember(dto => dto.Student, map => map.MapFrom(sourse => sourse.StudentDTO));

                cfg.CreateMap<ProjectGroupStudent, ProjectGroupStudentDTO>()
                    .ForMember(dto => dto.IdStudent, map => map.MapFrom(source => source.IdStudent))
                    .ForMember(dto => dto.IdProjectGroup, map => map.MapFrom(source => source.IdProjectGroup));

                cfg.CreateMap<ProjectGroup, ProjectGroupDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.IdProject, map => map.MapFrom(source => source.IdProject))
                    .ForMember(dto => dto.Mark, map => map.MapFrom(source => source.Mark))
                    .ForMember(dto => dto.Students, map => map.MapFrom(source => source.Students));

                cfg.CreateMap<Project, ProjectDTO>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                   .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description));

                cfg.CreateMap<Course, CourseDTO>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(sourse => sourse.Id))
                   .ForMember(dto => dto.Name, map => map.MapFrom(sourse => sourse.Name));

                cfg.CreateMap<Group, GroupDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.IsFinish, map => map.MapFrom(source => source.IsFinish))
                    .ForMember(dto => dto.StudentsCount, map => map.MapFrom(source => source.StudentsCount))
                    .ForMember(dto => dto.Course, map => map.MapFrom(source => source.Course));

                cfg.CreateMap<Lesson, LessonDTO>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Topic, map => map.MapFrom(source => source.Topic))
                   .ForMember(dto => dto.DateLesson, map => map.MapFrom(source => source.DateLesson))
                   .ForMember(dto => dto.IdGroup, map => map.MapFrom(source => source.IdGroup));

                cfg.CreateMap<LessonDTO, Lesson>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Topic, map => map.MapFrom(source => source.Topic))
                   .ForMember(dto => dto.DateLesson, map => map.MapFrom(source => source.DateLesson))
                   .ForMember(dto => dto.IdGroup, map => map.MapFrom(source => source.IdGroup));

                cfg.CreateMap<GroupDTO, Group>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                   .ForMember(dto => dto.IsFinish, map => map.MapFrom(source => source.IsFinish))
                   .ForMember(dto => dto.StudentsCount, map => map.MapFrom(source => source.StudentsCount))
                   .ForMember(dto => dto.Course, map => map.MapFrom(source => source.Course));

                cfg.CreateMap<ProjectGroup, ProjectGroupDTO>()
                        .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                        .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                        .ForMember(dto => dto.IdProject, map => map.MapFrom(source => source.IdProject))
                        .ForMember(dto => dto.Mark, map => map.MapFrom(source => source.Mark))
                        .ForMember(dto => dto.Students, map => map.MapFrom(source => source.Students));

                cfg.CreateMap<CommentDTO, Comment>()
                        .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                        .ForMember(dto => dto.Comments, map => map.MapFrom(source => source.Comment))
                        .ForMember(dto => dto.CommentTypeValue, map => map.MapFrom(source => source.CommentType));

                cfg.CreateMap<Comment, CommentDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Comment, map => map.MapFrom(source => source.Comments))
                    .ForMember(dto => dto.CommentType, map => map.MapFrom(source => source.CommentTypeValue));

                cfg.CreateMap<Exercise, ExerciseDTO>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description))
                   .ForMember(dto => dto.Deadline, map => map.MapFrom(source => source.Deadline))
                   .ForMember(dto => dto.ExerciseType, map => map.MapFrom(source => source.ExerciseType));

                cfg.CreateMap<Attendances, AttendanceDTO>()
                    .ForMember(dto => dto.IsPresence, map => map.MapFrom(sourse => sourse.isPresent))
                     .ForMember(dto => dto.StudentDTO, map => map.MapFrom(sourse => sourse.Student));
            });

            return config.CreateMapper();
        }
    }
}

