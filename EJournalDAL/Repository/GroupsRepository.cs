using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using EJournalDAL.Models.BaseModels;
using System.Configuration;

namespace EJournalDAL.Repository
{
    public class GroupsRepository
    {
        private string _connectionString;

        public GroupsRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
        }

        public GroupDTO AddGroup(GroupDTO groupDTO)
        {
            string command = "exec [EJournal].[AddGroup] @Name, @IdCourse";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                groupDTO.Id = db.Query<int>(command, new { groupDTO.Name, groupDTO.IdCourse }).First();
            }

            return groupDTO;
        }

        public void DeleteGroup(int idGroup)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdGroup", idGroup);

            string command = "[EJournal].[DeleteGroup]";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<GroupDTO> GetAllGroups()
        {
            string command = "exec [EJournal].[GetAllGroups]";
            List<GroupDTO> groupsDTO = new List<GroupDTO>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                groupsDTO = db.Query<GroupDTO,CourseDTO, GroupDTO>(command,
                    (group, course) =>
                    {
                        group.Course = course;
                        return group;
                    },
                    splitOn: "Id").ToList();
            }

            return groupsDTO;
        }
        public List<GroupDTO> GetAllGroupsWithCourses()
        {
            string command = "exec [EJournal].[GetAllGroupsWithCourses]";
            List<GroupDTO> groupsDTO = new List<GroupDTO>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query<CourseDTO, GroupDTO, List<GroupDTO>>(command,
                       (course, group) =>
                       {

                           if (course is null)
                           {
                               course = new CourseDTO();
                           }
                           group.Course = course;
                           groupsDTO.Add(group);

                           return groupsDTO;

                       }
                       , splitOn: "Id"
                       );
            }

            return groupsDTO;
        }


        public GroupDTO GetGroup(int id)
        {
            string command = "exec [EJournal].[GetGroup] @Id";
            GroupDTO groupDTO = null;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                groupDTO = db.Query<GroupDTO>(command, new { id }).FirstOrDefault();
            }

            return groupDTO;
        }

        public void UpdateGroup(GroupDTO groupDTO)
        {
            string command = "exec [EJournal].[UpdateGroup] @Id, @Name, @IdCourse";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, new { groupDTO.Id, groupDTO.Name, groupDTO.IdCourse });
            }
        }

        public void UpdateGroupStudents(GroupDTO groupDTO, List<StudentDTO> studentDTOs)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdGroup");
            dt.Columns.Add("IdStudents");

            foreach (var s in studentDTOs)
            {
                dt.Rows.Add(new object[] { groupDTO.Id, s.Id});
            }

            var parameters = new DynamicParameters();
            parameters.Add("@IdGroup", groupDTO.Id);
            parameters.Add("@NameGroup", groupDTO.Name);
            parameters.Add("@IdCourse", groupDTO.IdCourse);
            parameters.Add("@IdsStudent", dt.AsTableValuedParameter("[EJournal].[GroupIdsStudentsIds]"));

            string command = "[EJournal].[UpdateGroupStudents]";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
