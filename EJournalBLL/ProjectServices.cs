﻿using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System.Collections.Generic;

namespace EJournalBLL
{
    public class ProjectServices
    {
        private ProjectRepository _projectRepository;

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
            _projectRepository = new ProjectRepository();
        }

        public List<Project> GetAllProjects()
        {
            List<ProjectDTO> projectDTO = _projectRepository.GetProjects();
            List<Project> project = ObjectMapper.Mapper.Map<List<Project>>(projectDTO);
            return project;
        }
        public int AddProject(Project projectInput)
        {

            ProjectDTO project = ObjectMapper.Mapper.Map<ProjectDTO>(projectInput);
            projectInput.Id= _projectRepository.Create(project);
            GetAllProjects();
            return projectInput.Id;

        }

        public void UpdateProject(Project projectInput)
        {

            ProjectDTO project = ObjectMapper.Mapper.Map<ProjectDTO>(projectInput);
            _projectRepository.Update(project);

        }

        public void DeleteProject(int Id)
        {
            _projectRepository.Delete(Id);

        }

    }
}
