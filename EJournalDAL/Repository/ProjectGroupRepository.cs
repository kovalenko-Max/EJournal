using EJournalDAL.Models.BaseModels;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Configuration;

namespace EJournalDAL.Repository
{
    public class ProjectGroupRepository
    {
        string connectionString;
        public ProjectGroupRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ToString();

        }

        public int Create(ProjectGroupDTO projectGroup)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec AddProjectGroup @Name, @IdProject";
                int? projectGroupId = db.Query<int>(connectionQuery, projectGroup).FirstOrDefault();
                projectGroup.Id = projectGroupId;
            }
            return projectGroup.Id.Value;
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec DeleteProjectGroup @id";
                db.Execute(connectionQuery, new { id });
            }
        }
        public void Update(ProjectGroupDTO projectGroup)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec UpdateProject @Id,  @IdProject";
                db.Execute(connectionQuery, projectGroup);
            }
        }

        public List<ProjectGroupDTO> GetAllProjects(int IdProject)
        {
            List<ProjectGroupDTO> projectGroups = new List<ProjectGroupDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetAllProjectGroups  @IdProject";
                projectGroups = db.Query<ProjectGroupDTO>(connectionQuery, new { IdProject }).ToList();

            }
            return projectGroups;
        }
    }
}
