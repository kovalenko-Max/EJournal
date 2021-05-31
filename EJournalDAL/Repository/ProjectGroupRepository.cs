using EJournalDAL.Models.BaseModels;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace EJournalDAL.Repository
{
    public class ProjectGroupRepository
    {
        string connectionString;
        public ProjectGroupRepository()
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EJournalDB; Integrated Security=True;";
        }

        public ProjectGroupDTO GetStudentsFromOneGroup(int idProjectGroup)
        {
            ProjectGroupDTO projectGroup = new ProjectGroupDTO();
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = $"exec GetListStudentsInOneProjectGroup {idProjectGroup}";

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

                    },
                    splitOn: "Id"
                    );
                return projectGroup;
            }

        }
    }
}
