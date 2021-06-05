using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System.Collections.Generic;

namespace EJournalBLL.Services
{
    public class ProjectGroupSevice
    {
        private ProjectGroupRepository _projectGroupRepository;
     
        public ProjectGroupSevices()
        {
            _projectGroupRepository = new ProjectGroupRepository();
        }

       
        public int AddProjectGroup (ProjectGroup projectGroupInput)
        {
            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            projectGroupInput.Id = _projectGroupRepository.Create(projectGroup);
            return projectGroupInput.Id;
        }
        public void Update(ProjectGroupDTO projectGroupInput)
        {
            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            _projectGroupRepository.Update(projectGroup);
        }

        public void Delete(int Id)
        {
            _projectGroupRepository.Delete(Id);
        }

        public List<ProjectGroup> GetProjectGroups(int IdProject)
        {
            List<ProjectGroupDTO> projectGroupsDTO = _projectGroupRepository.GetAllProjects(IdProject);
            List<ProjectGroup> projectGroups = ObjectMapper.Mapper.Map<List<ProjectGroup>>(projectGroupsDTO);
            return projectGroups;
        }
    }
}
