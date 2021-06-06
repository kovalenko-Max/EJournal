using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System.Collections.Generic;

namespace EJournalBLL
{
    public class ProjectGroupSevice
    {
        public ProjectGroupRepository ProjectGroupRepository { get; set; }
     
        public ProjectGroupSevice()
        {
            ProjectGroupRepository = new ProjectGroupRepository();
        }

       
        public int AddProjectGroup (ProjectGroup projectGroupInput)
        {
            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            projectGroupInput.Id = ProjectGroupRepository.Create(projectGroup);
            return projectGroupInput.Id;
        }
        public void Update(ProjectGroupDTO projectGroupInput)
        {
            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            ProjectGroupRepository.Update(projectGroup);
        }

        public void Delete(int Id)
        {
            ProjectGroupRepository.Delete(Id);
        }

        public List<ProjectGroup> GetProjectGroups(int IdProject)
        {
            List<ProjectGroupDTO> projectGroupsDTO = ProjectGroupRepository.GetAllProjectsGroup(IdProject);
            List<ProjectGroup> projectGroups = ObjectMapper.Mapper.Map<List<ProjectGroup>>(projectGroupsDTO);
            return projectGroups;
        }
        public void AddStudentToProjectGroup( ProjectGroupStudent projectGroupStudent)
        {
            ProjectGroupStudentDTO projectGroupStudentDTO = ObjectMapper.Mapper.Map<ProjectGroupStudentDTO>(projectGroupStudent);
            ProjectGroupRepository.AddStudentToProjectGroup(projectGroupStudentDTO);
        }

        public void DeleteStudentFromProjectGroup(ProjectGroupStudent projectGroupStudent)
        {
            ProjectGroupStudentDTO projectGroupStudentDTO = ObjectMapper.Mapper.Map<ProjectGroupStudentDTO>(projectGroupStudent);
            ProjectGroupRepository.DeleteStudentFromProjectGroup(projectGroupStudentDTO);
        }
    }
}
