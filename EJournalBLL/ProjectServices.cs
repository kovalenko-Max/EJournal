using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;

namespace EJournalBLL
{
    public class ProjectServices
    {
        ProjectRepository projectRepository;

        public ProjectServices()
        {
            projectRepository = new ProjectRepository();
        }

        public List<Project> GetAllProjects()
        {
            List<ProjectDTO> projectDTO = projectRepository.GetAllProjects();
            List<Project> project = ObjectMapper.Mapper.Map<List<Project>>(projectDTO);
            return project;
        }
    }
}
