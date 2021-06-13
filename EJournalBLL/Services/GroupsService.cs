using System.Collections.Generic;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using EJournalBLL.Models;

namespace EJournalBLL.Services
{
    public class GroupsService
    {
        public IGroupRepository groupsRepository { get; set; }

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

        public GroupsService()
        {
            Groups = new List<Group>();
            groupsRepository = new GroupsRepository();
        }
        public GroupsService(IGroupRepository groupRepository)
        {
            groupsRepository =groupRepository;
        }

        public void AddGroupAndStudentsToDB(Group group, List<Student> students)
        {
            GroupDTO groupDTO = ObjectMapper.Mapper.Map<GroupDTO>(group);
            groupDTO.IdCourse = group.Course.Id;

            groupDTO = groupsRepository.AddGroupWithStudents(groupDTO,
                ObjectMapper.Mapper.Map<List<StudentDTO>>(students));
            
            group.Id = groupDTO.Id;
        }

        public void AddGroupToDB(Group group)
        {
            GroupDTO groupDTO = new GroupDTO();
            groupDTO.Name = group.Name;
            groupDTO.IdCourse = group.Course.Id;
            groupDTO = groupsRepository.AddGroup(groupDTO);
            group.Id = groupDTO.Id;
        }

        public void UpdateGroupInDB(Group group)
        {
            GroupDTO groupDTO = new GroupDTO();
            groupDTO.Id = group.Id;
            groupDTO.Name = group.Name;
            groupDTO.IdCourse = group.Course.Id;
            groupDTO.IsFinish = group.IsFinish ? true : false;
            groupsRepository.UpdateGroup(groupDTO);
        }

        public List<Group> GetAllGroupsFromDB()
        {
            List<GroupDTO> groupDTOs = groupsRepository.GetAllGroups();

            return ObjectMapper.Mapper.Map<List<Group>>(groupDTOs);
        }

        public void UpdateGroupStudents(Group group, List<Student> students)
        {
            GroupDTO groupDTO = ObjectMapper.Mapper.Map<GroupDTO>(group);
            groupDTO.IdCourse = group.Course.Id;

            groupsRepository.UpdateGroupStudents(groupDTO,
                ObjectMapper.Mapper.Map<List<StudentDTO>>(students));
        }

        public void DeleteGroup(Group group)
        {
            groupsRepository.DeleteGroup(group.Id);
        }
    }
}
