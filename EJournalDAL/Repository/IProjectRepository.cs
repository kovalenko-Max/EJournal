using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Repository
{
    public interface IProjectRepository
    {
        public List<ProjectDTO> GetProjects();
        public ProjectDTO GetProject(int id);
        public int AddProject(ProjectDTO project);
        public void UpdateProject(ProjectDTO project);
        public void DeleteProject(int Id);
    }
}
