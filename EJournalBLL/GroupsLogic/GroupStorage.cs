using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJournalDAL;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;

namespace EJournalBLL.GroupsLogic
{
    public class GroupStorage
    {
        public string ConnectionString;
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

        public GroupStorage(string connectionString)
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
            groupDTO = groupsRepository.AddGroupDTO(groupDTO);
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
            List<GroupDTO> groupDTOs = groupsRepository.GetAllGroupsDTO();

            return ConvertGroupsDTOToGroups(groupDTOs);
        }

        private List<Group> ConvertGroupsDTOToGroups(List<GroupDTO> groupsDTO)
        {
            CoursesRepository coursesRepository = new CoursesRepository(ConnectionString);
            List<Group> groups = new List<Group>();

            foreach (GroupDTO groupDTO in groupsDTO)
            {
                CourseDTO courseDTO = coursesRepository.GetCourseDTO(groupDTO.IdCourse);
                Course course = new Course(courseDTO);
                Group group = new Group(groupDTO, course);
                groups.Add(group);
            }

            return groups;
        }
    }
}
