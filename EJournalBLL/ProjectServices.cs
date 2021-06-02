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

        public List<Project> Projects
        {
            get
            {
                return Projects = GetAllProjects();
            }
            set
            {

            }
        }

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
        public void AddProject(Project projectInput)
        {

            ProjectDTO project = ObjectMapper.Mapper.Map<ProjectDTO>(projectInput);
            projectRepository.Create(project);

        }

        public void UpdateProject(Project projectInput)
        {

            ProjectDTO project = ObjectMapper.Mapper.Map<ProjectDTO>(projectInput);
            projectRepository.Update(project);

        }

        public void DeleteProject(int Id)
        {
            projectRepository.Delete(Id);

        }

    }
}
