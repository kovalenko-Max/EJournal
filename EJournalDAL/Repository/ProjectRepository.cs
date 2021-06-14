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
    public class ProjectRepository: IProjectRepository
    {
        string connectionString;
        public ProjectRepository()
        {
             connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ToString();
        }

        public List<ProjectDTO> GetAllProjects()
        {
            List<ProjectDTO> projects = new List<ProjectDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}]";
                projects = db.Query<ProjectDTO>(connectionQuery).ToList();

            }
            return projects;
        }

        public ProjectDTO GetProject(int id)
        {
            ProjectDTO project = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @Id";
                project = db.Query<ProjectDTO>(connectionQuery, new { id }).FirstOrDefault();

            }
            return project;
        }


        public int AddProject(ProjectDTO project)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @Name, @Description";
                int? projectId = db.Query<int>(connectionQuery, project).FirstOrDefault();
                project.Id = projectId;
            }
            return project.Id.Value;
        }
        public void UpdateProject(ProjectDTO project)
        {

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @Id, @Name, @Description";
                db.Execute(connectionQuery, project);
                
            }

        }
        public void DeleteProject(int Id)
        {
           
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec [EJournal].[DeleteProject] @Id";
                db.Execute(connectionQuery, new { Id });
            }
        }
    }
}
