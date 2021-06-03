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
            var conString = ConfigurationManager.ConnectionStrings["example"];
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

        public ProjectGroupDTO Create(ProjectGroupDTO projectGroup)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec AddProjectGroup @Name, @IdProject";
                int? projectGroupId = db.Query<int>(connectionQuery, projectGroup).FirstOrDefault();
                projectGroup.Id = projectGroupId;
            }
            return projectGroup;
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


    }
}
