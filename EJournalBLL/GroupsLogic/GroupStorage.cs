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
        public List<Group> Groups { get; set; }

        public GroupStorage(string connectionString)
        {
            Groups = new List<Group>();
            ConnectionString = connectionString;
        }

        public void GetAllGroupsFromDB()
        {
            GroupsRepository groupsRepository = new GroupsRepository(ConnectionString);
            CoursesRepository coursesRepository = new CoursesRepository(ConnectionString);
            List<GroupDTO> groupDTOs = groupsRepository.GetAllGroupsDTO();

            foreach(var groupDTO in groupDTOs)
            {
                CourseDTO courseDTO = coursesRepository.GetCourseDTO(groupDTO.IdCourse);
                Course course = new Course(courseDTO);
                Group group = new Group(groupDTO, course);
                Groups.Add(group);
            }
        }

        private Group GetGroupFromGroupDTO(GroupDTO groupDTO, CourseDTO courseDTO)
        {
            Group group = new Group(groupDTO.Name, new Course(courseDTO.Name));

            return group;
        }
    }
}
