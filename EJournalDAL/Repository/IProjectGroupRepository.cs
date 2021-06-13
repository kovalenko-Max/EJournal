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
        public int Create(ProjectGroupDTO projectGroup);
        public void Delete(int id);
        public void Update(ProjectGroupDTO projectGroup, DataTable dt);
        public List<ProjectGroupDTO> GetAllProjectsGroup(int IdProject);
        public void AddStudentToProjectGroup(ProjectGroupStudentDTO projectGroupStudent);
        public void DeleteStudentFromProjectGroup(ProjectGroupStudentDTO projectGroupStudent);
    }
}
