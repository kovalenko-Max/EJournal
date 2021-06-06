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
                    .ForMember(dto => dto.City, map => map.MapFrom(source => source.City))
                    .ForMember(dto => dto.Comments, map => map.MapFrom(source => source.comments))
                    .ForMember(dto => dto.AgreementNumber, map => map.MapFrom(source => source.AgreementNumber))
                    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<CommentDTO, Comments>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Comment, map => map.MapFrom(source => source.Comment))
                    .ForMember(dto => dto.CommentType, map => map.MapFrom(source => source.CommentType))
                    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<ProjectDTO, Project>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description))
                    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<ProjectGroupDTO, ProjectGroup>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.IdProject, map => map.MapFrom(source => source.IdProject))
                    .ForMember(dto => dto.Students, map => map.MapFrom(source => source.Students))
                    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<ExerciseDTO, Exercise>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description))
                    .ForMember(dto => dto.Deadline, map => map.MapFrom(source => source.Deadline))
                    .ForMember(dto => dto.ExerciseType, map => map.MapFrom(source => source.ExerciseType))
                    .ForMember(dto => dto.IdGroup, map => map.MapFrom(source => source.IdGroup))
                    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<Student, StudentDTO>()
                    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                    .ForMember(dto => dto.Surname, map => map.MapFrom(source => source.Surname))
                    .ForMember(dto => dto.Phone, map => map.MapFrom(source => source.Phone))
                    .ForMember(dto => dto.Email, map => map.MapFrom(source => source.Email))
                    .ForMember(dto => dto.Git, map => map.MapFrom(source => source.Git))
                    .ForMember(dto => dto.Ranking, map => map.MapFrom(source => source.Ranking))
                    .ForMember(dto => dto.City, map => map.MapFrom(source => source.City))
                    .ForMember(dto => dto.comments, map => map.MapFrom(source => source.Comments))
                    .ForMember(dto => dto.AgreementNumber, map => map.MapFrom(source => source.AgreementNumber))
                    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<ProjectGroup, ProjectGroupDTO>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                   .ForMember(dto => dto.Students, map => map.MapFrom(source => source.Students))
                   .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<Project, ProjectDTO>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                   .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description))
                   .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                cfg.CreateMap<CourseDTO, Course>()
                .ForMember(dto => dto.Id, map => map.MapFrom(sourse => sourse.Id))
                .ForMember(dto => dto.Name, map => map.MapFrom(sourse => sourse.Name));

                cfg.CreateMap<Course, CourseDTO>()
                .ForMember(dto => dto.Id, map => map.MapFrom(sourse => sourse.Id))
                .ForMember(dto => dto.Name, map => map.MapFrom(sourse => sourse.Name));

                cfg.CreateMap<Group, GroupDTO>()
                   .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                   .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                   .ForMember(dto => dto.IsFinish, map => map.MapFrom(source => source.IsFinish))
                   .ForMember(dto => dto.StudentsCount, map => map.MapFrom(source => source.StudentsCount))
                   .ForMember(dto => dto.Course, map => map.MapFrom(source => source.Course));

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
                        .ForMember(dto => dto.Students, map => map.MapFrom(source => source.Students))
                        .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

            });
            return config.CreateMapper();
        }
    }
}
