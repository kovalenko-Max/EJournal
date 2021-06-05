using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System.Collections.Generic;

namespace EJournalBLL.Services
{
    public class ProjectService
    {
        public ProjectRepository ProjectRepository { get; set; }

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

        public ProjectService()
        {
            ProjectRepository = new ProjectRepository();
        }

        public List<Project> GetAllProjects()
        {
            List<ProjectDTO> projectDTO = ProjectRepository.GetProjects();
            List<Project> project = ObjectMapper.Mapper.Map<List<Project>>(projectDTO);
            return project;
        }
        public int AddProject(Project projectInput)
        {
            ProjectDTO project = ObjectMapper.Mapper.Map<ProjectDTO>(projectInput);
            projectInput.Id= ProjectRepository.Create(project);
            return projectInput.Id;
        }

        public void UpdateProject(Project projectInput)
        {
            ProjectDTO project = ObjectMapper.Mapper.Map<ProjectDTO>(projectInput);
            ProjectRepository.Update(project);

        }

        public void DeleteProject(int Id)
        {
            ProjectRepository.Delete(Id);

        }
    }
}
