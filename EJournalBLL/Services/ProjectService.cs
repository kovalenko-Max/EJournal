using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System.Collections.Generic;

namespace EJournalBLL
{
    public class ProjectService
    {
        public IProjectRepository ProjectRepository { get; set; }

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

        public ProjectService(IProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
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
            projectInput.Id= ProjectRepository.AddProject(project);
            return projectInput.Id;

        }

        public void UpdateProject(Project projectInput)
        {

            ProjectDTO project = ObjectMapper.Mapper.Map<ProjectDTO>(projectInput);
            ProjectRepository.UpdateProject(project);

        }

        public void DeleteProject(int Id)
        {
            ProjectRepository.DeleteProject(Id);

        }

    }
}
