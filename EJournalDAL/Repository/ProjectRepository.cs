using Dapper;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EJournalDAL.Repository
{
    public class ProjectRepository
    {
        string connectionString;
        public ProjectRepository()
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EJournalDB; Integrated Security=True;";
        }

        public List<ProjectDTO> GetAllProjects()
        {
            List<ProjectDTO> projects = new List<ProjectDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetProjects";
                projects = db.Query<ProjectDTO>(connectionQuery).ToList();

            }
            return projects;
        }

        public ProjectDTO GetProject(int id)
        {
            ProjectDTO project = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetProject @Id";
                project = db.Query<ProjectDTO>(connectionQuery, new { id }).FirstOrDefault();

            }
            return project;
        }

        public ProjectDTO Create(ProjectDTO project)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec AddProject @Name, @Description, @IdProjectGroup";
                int? projectId = db.Query<int>(connectionQuery, project).FirstOrDefault();
                project.Id = projectId;
            }
            return project;
        }
        public void Update(ProjectDTO project)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec UpdateProject @Id, @Name, @Description, @IdProjectGroup";
                db.Execute(connectionQuery, project);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec DeleteProject @id";
                db.Execute(connectionQuery, new { id });
            }
        }
    }
}
