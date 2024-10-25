using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Repositories
{
    public interface ICourseRepo
    {
        public bool AddCourse(Course course);
        public Course GetCourse(int id);
        public List<Course> GetCourseList();
        public bool UpdateCourse(Course course);
        public bool DeleteCourse(int id);
        public List<Course> SearchCourseByName(string name);
    }
}
