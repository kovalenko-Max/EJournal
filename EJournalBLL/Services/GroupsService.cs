using System.Collections.Generic;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using EJournalBLL.Models;

namespace EJournalBLL.Services
{
    public class GroupsService
    {
        public string ConnectionString { get; set; }
        public List<Group> Groups
        {
            get
            {
                return Groups = GetAllGroupsFromDB();
            }
            set
            {

            }
        }

        public GroupsService(string connectionString)
        {
            Groups = new List<Group>();
            ConnectionString = connectionString;
        }

        public void AddGroupToDB(Group group)
        {
            GroupsRepository groupsRepository = new GroupsRepository(ConnectionString);
            GroupDTO groupDTO = new GroupDTO();
            groupDTO.Name = group.Name;
            groupDTO.IdCourse = group.Course.Id;
            groupDTO = groupsRepository.AddGroup(groupDTO);
            group.Id = groupDTO.Id;
        }

        public void UpdateGroupInDB(Group group)
        {
            GroupsRepository groupsRepository = new GroupsRepository(ConnectionString);
            GroupDTO groupDTO = new GroupDTO();
            groupDTO.Id = group.Id;
            groupDTO.Name = group.Name;
            groupDTO.IdCourse = group.Course.Id;
            groupDTO.IsFinish = group.IsFinish ? 1 : 0;
            groupsRepository.UpdateGroupDTO(groupDTO);
        }

        private List<Group> GetAllGroupsFromDB()
        {
            GroupsRepository groupsRepository = new GroupsRepository(ConnectionString);
            List<GroupDTO> groupDTOs = groupsRepository.GetAllGroups();

            return ObjectMapper.Mapper.Map<List<Group>>(groupDTOs);
        }
    }
}
