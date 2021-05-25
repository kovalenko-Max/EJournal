using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using DAL.Models.BasicModels;
using System.Data.SqlClient;

namespace EJournalDAL.Repository
{
    public class GroupsRepository
    {
        public string ConnectionString;

        public GroupsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<GroupDTO> GetAllGroupsDTO()
        {
            string command = "exec GetAllGroups";
            List<GroupDTO> groupsDTO = new List<GroupDTO>();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                groupsDTO = db.Query<GroupDTO>(command).ToList();
            }

            return groupsDTO;
        }

        public GroupDTO GetGroupDTO(int Id)
        {
            string command = "exec GetGroup @Id";
            GroupDTO groupDTO = null;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                groupDTO = db.Query<GroupDTO>(command, new { Id }).FirstOrDefault();
            }

            return groupDTO;
        }
    }
}
