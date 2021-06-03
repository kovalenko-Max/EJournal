using AutoMapper;
using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        .ForMember(dto => dto.IdCommentType, map => map.MapFrom(source => source.IdCommentType))
                        .ForMember(dto => dto.IdTeacher, map => map.MapFrom(source => source.IdTeacher))
                        .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                    cfg.CreateMap<ProjectDTO, Project>()
                        .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                        .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                        .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description))
                        .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                    cfg.CreateMap<ProjectGroupDTO, ProjectGroup>()
                        .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                        .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                        .ForMember(dto => dto.Students, map => map.MapFrom(source => source.Students))
                        .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                    cfg.CreateMap<GroupDTO, Group>()
                        .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                        .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                        .ForMember(dto => dto.IsFinish, map => map.MapFrom(source => source.IsFinish))
                        .ForMember(dto => dto.Course, map => map.MapFrom(source => source.Course));

                    //cfg.CreateMap<LessonDTO, Lesson>()
                    //    .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                    //    .ForMember(dto => dto.DateLesson, map => map.MapFrom(source => source.DateLesson))
                    //    .ForMember(dto => dto.Topic, map => map.MapFrom(source => source.Topic))
                    //    .ForMember(dto => dto.IdTeacher, map => map.MapFrom(source => source.IdTeacher))
                    //    .ForMember(dto => dto.IdGroup, map => map.MapFrom(source => source.IdGroup))
                    //    .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));
                    

                    cfg.CreateMap<ExerciseDTO, Exercise>()
                        .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                        .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description))
                        .ForMember(dto => dto.Deadline, map => map.MapFrom(source => source.Deadline))
                        .ForMember(dto => dto.IdExerciseType, map => map.MapFrom(source => source.IdExerciseType))
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

                    cfg.CreateMap<Project, ProjectDTO>()
                       .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                       .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                       .ForMember(dto => dto.Description, map => map.MapFrom(source => source.Description))
                       .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                    cfg.CreateMap<Group, GroupDTO>()
                        .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                        .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                        .ForMember(dto => dto.IsFinish, map => map.MapFrom(source => source.IsFinish))
                        .ForMember(dto => dto.Course, map => map.MapFrom(source => source.Course));

                    cfg.CreateMap<ProjectGroup, ProjectGroupDTO>()
                        .ForMember(dto => dto.Id, map => map.MapFrom(source => source.Id))
                        .ForMember(dto => dto.Name, map => map.MapFrom(source => source.Name))
                        .ForMember(dto => dto.Students, map => map.MapFrom(source => source.Students))
                        .ForMember(dto => dto.IsDelete, map => map.MapFrom(source => source.IsDelete));

                });
                return config.CreateMapper();

            }

        
    }
}
