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
    }
}
