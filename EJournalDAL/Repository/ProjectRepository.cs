using Dapper;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EJournalDAL.Repository
{
    public class ProjectRepository
    {
        string connectionString;
        public ProjectRepository()
        {
             connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ToString();
        }

        public List<ProjectDTO> GetProjects()
        {
            List<ProjectDTO> projects = new List<ProjectDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"exec [EJournal].[{MethodBase.GetCurrentMethod().Name}]";
                projects = db.Query<ProjectDTO>(connectionQuery).ToList();

            }
            return projects;
        }

        public ProjectDTO GetProject(int id)
        {
            ProjectDTO project = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec [EJournal].[GetProject] @Id";
                project = db.Query<ProjectDTO>(connectionQuery, new { id }).FirstOrDefault();

            }
            return project;
        }


        public int Create(ProjectDTO project)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec [EJournal].[AddProject] @Name, @Description";
                int? projectId = db.Query<int>(connectionQuery, project).FirstOrDefault();
                project.Id = projectId;
            }
            return project.Id.Value;
        }
        public void Update(ProjectDTO project)
        {

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec [EJournal].[UpdateProject] @Id, @Name, @Description";
                db.Execute(connectionQuery, project);
                
            }

        }
        public void Delete(int Id)
        {
           
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec [EJournal].[DeleteProject] @Id";
                db.Execute(connectionQuery, new { Id });
            }
        }
    }
}
