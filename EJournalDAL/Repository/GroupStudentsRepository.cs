using Dapper;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EJournalDAL.Repository
{
    public class GroupStudentsRepository
    {
        public string ConnectionString;

        public GroupStudentsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<GroupStudentsDTO> GetGroupsAndNumberOfStudentsInThemAndGroupStatus()
        {
            string command = "exec GetGroupsAndNumberOfStudentsInThemAndGroupStatus";
            List<GroupStudentsDTO> groupStudentsDTO = new List<GroupStudentsDTO>();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                groupStudentsDTO = db.Query<GroupStudentsDTO>(command).ToList();
            }

            return groupStudentsDTO;
        }

        public GroupStudentsDTO GetGroupAndStudentsInIt(int id)
        {
            string command = $"exec GetGroupAndStudentsInIt {id}";
            GroupStudentsDTO groupStudentsDTO = new GroupStudentsDTO();
            List<StudentDTO> students = null;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Query<GroupStudentsDTO, StudentDTO, GroupStudentsDTO>(command,
                (group, student) =>
                {
                    if (students is null)
                    {
                        students = new List<StudentDTO>();
                    }

                    students.Add(student);

                    group.students = students;
                    group.IdGroup = id;
                    groupStudentsDTO = group;

                    return groupStudentsDTO;
                },
                splitOn: "Id"
                );
            }

            return groupStudentsDTO;
        }
    }
}
