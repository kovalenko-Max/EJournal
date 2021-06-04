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
        public ProjectGroupRepository(string connectionString)
        {
            this.connectionString = connectionString;
         
        }

        public ProjectGroupDTO GetStudentsFromOneProjectGroup(int idProjectGroup)
        {
            ProjectGroupDTO projectGroup = new ProjectGroupDTO();
            List<StudentDTO> students = null;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"exec GetListStudentsInOneProjectGroup @idProjectGroup";

                db.Query<ProjectGroupDTO, StudentDTO, ProjectGroupDTO>(connectionQuery,

                      (projectsGroupStudents, student) =>
                      {
                          if (students is null)
                          {
                              students = new List<StudentDTO>();
                          }


                          students.Add(student);


                          projectsGroupStudents.Students = students;
                          projectsGroupStudents.Id = idProjectGroup;
                          projectGroup = projectsGroupStudents;
                          return projectGroup;

                      }
                      , param: new { idProjectGroup }
                      , splitOn: "Id"
                      );
                return projectGroup;
            }

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

        public List<ProjectGroupDTO> GetAllProjects()
        {
            List<ProjectGroupDTO> projectGroups = new List<ProjectGroupDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetProjects";
                projectGroups = db.Query<ProjectGroupDTO>(connectionQuery).ToList();

            }
            return projectGroups;
        }
    }
}
