using System.Collections.Generic;
using System.Linq;
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

        public GroupDTO AddGroupDTO(string name, int IdCourse)
        {
            string command = "exec DeleteGroup @Name, @IdCourse";
            GroupDTO groupDTO = null;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                groupDTO = db.Query<GroupDTO>(command, new { name, IdCourse }).FirstOrDefault();
            }

            return groupDTO;
        }

        public void DeleteGroupDTO(int Id)
        {
            string command = "exec DeleteGroup @Id";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(command, new { Id });
            }
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

        public GroupDTO GetGroupDTO(int id)
        {
            string command = "exec GetGroup @Id";
            GroupDTO groupDTO = null;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                groupDTO = db.Query<GroupDTO>(command, new { id }).FirstOrDefault();
            }

            return groupDTO;
        }

        public void UpdateGroupDTO(GroupDTO groupDTO)
        {
            string command = "exec UpdateGroup @Id, @Name, @IdCourse";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(command, new { groupDTO.Id, groupDTO.Name, groupDTO.IdCourse });
            }
        }
    }
}
