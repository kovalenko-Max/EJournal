using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;

namespace EJournalDAL.Repository
{
    public interface IGroupRepository
    {
        public GroupDTO AddGroup(GroupDTO groupDTO);
        public void DeleteGroup(int idGroup);
        public List<GroupDTO> GetAllGroups();
        public List<GroupDTO> GetAllGroupsWithCourses();
        public GroupDTO GetGroup(int id);
        public void UpdateGroup(GroupDTO groupDTO);
        public GroupDTO AddGroupWithStudents(GroupDTO groupDTO, List<StudentDTO> studentDTOs);
        public void UpdateGroupStudents(GroupDTO groupDTO, List<StudentDTO> studentDTOs);

    }
}
