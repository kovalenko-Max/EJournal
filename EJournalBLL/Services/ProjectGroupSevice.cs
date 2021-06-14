using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System.Collections.Generic;
using System.Data;

namespace EJournalBLL
{
    public class ProjectGroupSevice
    {
        public IProjectGroupRepository ProjectGroupRepository { get; set; }
        private DataTable _updateProjectGroup;

        public ProjectGroupSevice()
        {
            ProjectGroupRepository = new ProjectGroupRepository();
            _updateProjectGroup = new DataTable();
            _updateProjectGroup.Columns.Add("IdProjectGroup");
            _updateProjectGroup.Columns.Add("IdStudent");
        }
        public ProjectGroupSevice(IProjectGroupRepository projectGroupRepository)
        {
            ProjectGroupRepository = projectGroupRepository;
        }


        public int AddProjectGroup(ProjectGroup projectGroupInput)
        {
            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            projectGroupInput.Id = ProjectGroupRepository.AddProjectGroup(projectGroup);
            return projectGroupInput.Id;
        }
        public void UpdateProjectGroup(ProjectGroup projectGroupInput)
        {
            _updateProjectGroup.Clear();
            foreach (var a in projectGroupInput.Students)
            {
                _updateProjectGroup.Rows.Add(new object[] { projectGroupInput.Id, a.Id });
            }

            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            ProjectGroupRepository.UpdateProjectGroup(projectGroup, _updateProjectGroup);
        }

        public void DeleteProjectGroup(int Id)
        {
            ProjectGroupRepository.DeleteProjectGroup(Id);
        }

        public List<ProjectGroup> GetProjectGroups(int IdProject)
        {
            List<ProjectGroupDTO> projectGroupsDTO = ProjectGroupRepository.GetAllProjectGroups(IdProject);
            List<ProjectGroup> projectGroups = ObjectMapper.Mapper.Map<List<ProjectGroup>>(projectGroupsDTO);
            return projectGroups;
        }
    }
}
