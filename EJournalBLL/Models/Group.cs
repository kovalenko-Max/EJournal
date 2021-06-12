using System;
using System.Collections.Generic;

namespace EJournalBLL.Models
{
    public class Group
    {
        private string _name;
        private Course _course;
        private bool _isFinish;
        private int _studentsCount;
        private List<Student> _students;
        private List<Lesson> _lessons;

        public int Id;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                GrouChanged?.Invoke(this, new EventArgs());
            }
        }
        public Course Course
        {
            get
            {
                return _course;
            }
            set
            {
                _course = value;
                GrouChanged?.Invoke(this, new EventArgs());
            }
        }
        
        public bool IsFinish
        {
            get
            {
                return _isFinish;
            }
            set
            {
                _isFinish = value;
                GrouChanged?.Invoke(this, new EventArgs());
            }
        }
        public int StudentsCount { get; set; }

        public List<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                StudentsCount = _students.Count;
                GrouChanged?.Invoke(this, new EventArgs());
            }
        }
        public List<Lesson> Lessons 
        {
            get
            {
                return _lessons;
            }
            set
            {
                _lessons = value;
                GrouChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler GrouChanged;
        public Group(string name, Course course)
        {
            Name = name;
            Course = course;
            IsFinish = false;
            Students = new List<Student>();
        }
    }
}
