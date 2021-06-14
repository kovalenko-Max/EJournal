using EJournalDAL.Models.BaseModels;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace EJournalDAL.Repository
{
    public class ProjectGroupRepository: IProjectGroupRepository
    {
        string connectionString;
        public ProjectGroupRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ToString();

        }

        public int AddProjectGroup(ProjectGroupDTO projectGroup)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @Name, @IdProject";
                int projectGroupId = db.Query<int>(connectionQuery, projectGroup).FirstOrDefault();
                projectGroup.Id = projectGroupId;
            }
            return projectGroup.Id;
        }

        public void DeleteProjectGroup(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @id";
                db.Execute(connectionQuery, new { id });
            }
        }
        public void UpdateProjectGroup(ProjectGroupDTO projectGroup, DataTable dt)
        {

            string command = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}]";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", projectGroup.Id);
            parameters.Add("@Name", projectGroup.Name);
            parameters.Add("@Mark", projectGroup.Mark);
            parameters.Add("@Students", dt.AsTableValuedParameter("[EJournal].[StudentsIds]"));

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }

        }

        public List<ProjectGroupDTO> GetAllProjectGroups(int IdProject)
        {
            List<ProjectGroupDTO> projectGroups = new List<ProjectGroupDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @IdProject";
                projectGroups = db.Query<ProjectGroupDTO>(connectionQuery, new { IdProject }).ToList();

            }
            return projectGroups;

        }
        public void AddStudentToProjectGroup(ProjectGroupStudentDTO projectGroupStudent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @IdStudent, @IdProjectGroup";
                db.Execute(connectionQuery, projectGroupStudent );
            }
        }
        public void DeleteStudentFromProjectGroup(ProjectGroupStudentDTO projectGroupStudent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @IdStudent, @IdProjectGroup";
                db.Execute(connectionQuery, projectGroupStudent);
            }
        }


    }
}
