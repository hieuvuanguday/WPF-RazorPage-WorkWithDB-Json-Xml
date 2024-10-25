using Student_BusinessObjects;
using Student_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Repositories
{
    public class CourseRepo : ICourseRepo
    {
        public bool AddCourse(Course course) => CourseDAO.Instance.AddCourse(course);
        public bool DeleteCourse(int id) => CourseDAO.Instance.DeleteCourse(id);
        public Course GetCourse(int id) => CourseDAO.Instance.GetCourse(id);
        public List<Course> GetCourseList() => CourseDAO.Instance.GetCourseList();
        public List<Course> SearchCourseByName(string name) => CourseDAO.Instance.SearchCourseByName(name);
        public bool UpdateCourse(Course course) => CourseDAO.Instance.UpdateCourse(course);
    }
}
