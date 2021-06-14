using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Repository
{
    public interface IProjectGroupRepository
    {
        public int AddProjectGroup(ProjectGroupDTO projectGroup);
        public void DeleteProjectGroup(int id);
        public void UpdateProjectGroup(ProjectGroupDTO projectGroup, DataTable dt);
        public List<ProjectGroupDTO> GetAllProjectGroups(int IdProject);
        public void AddStudentToProjectGroup(ProjectGroupStudentDTO projectGroupStudent);
        public void DeleteStudentFromProjectGroup(ProjectGroupStudentDTO projectGroupStudent);
    }
}
