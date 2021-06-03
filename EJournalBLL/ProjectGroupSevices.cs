﻿using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL
{
    class ProjectGroupSevices
    {
        private ProjectGroupRepository _projectGroupRepository;
        private string _connectionString;
        public ProjectGroupSevices(string connectionString)
        {
            this._connectionString = connectionString;
            _projectGroupRepository = new ProjectGroupRepository(connectionString);
        }

        public ProjectGroup GetProjectGroups(int IdProjectGroup)
        {
            ProjectGroupDTO projectGroupDTO = _projectGroupRepository.GetStudentsFromOneProjectGroup(IdProjectGroup);
            ProjectGroup projectGroup = ObjectMapper.Mapper.Map<ProjectGroup>(projectGroupDTO);
            return projectGroup;
        }
        public void AddProjectGroup (ProjectGroup projectGroupInput)
        {

            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            _projectGroupRepository.Create(projectGroup);

        }
        public void Update(ProjectGroupDTO projectGroupInput)
        {
            ProjectGroupDTO projectGroup = ObjectMapper.Mapper.Map<ProjectGroupDTO>(projectGroupInput);
            _projectGroupRepository.Update(projectGroup);
        }

        public void Delete(int Id)
        {
            _projectGroupRepository.Delete(Id);
        }
    }
}
