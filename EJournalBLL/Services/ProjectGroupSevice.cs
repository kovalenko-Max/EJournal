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


        public int AddProjectGroup (ProjectGroup projectGroupInput)
        {
            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            projectGroupInput.Id = ProjectGroupRepository.Create(projectGroup);
            return projectGroupInput.Id;
        }
        public void Update(ProjectGroup projectGroupInput)
        {
            _updateProjectGroup.Clear();
            foreach (var a in projectGroupInput.Students)
            {
                _updateProjectGroup.Rows.Add(new object[] { projectGroupInput.Id, a.Id });
            }

            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            ProjectGroupRepository.Update(projectGroup, _updateProjectGroup);
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
