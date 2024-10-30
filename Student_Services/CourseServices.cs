using Student_BusinessObjects;
using Student_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepo iCourseRepo;

        public CourseServices()
        {
            this.iCourseRepo = new CourseRepo();
        }

        public bool AddCourse(Course course)
        {
            return iCourseRepo.AddCourse(course);
        }

        public bool DeleteCourse(int id)
        {
            return iCourseRepo.DeleteCourse(id);
        }

        public Course GetCourse(int id)
        {
            return iCourseRepo.GetCourse(id);
        }

        public List<Course> GetCourseList()
        {
            return iCourseRepo.GetCourseList();
        }

        public List<Course> SearchCourseByName(string name)
        {
            return iCourseRepo.SearchCourseByName(name);
        }

        public bool UpdateCourse(Course course)
        {
            return iCourseRepo.UpdateCourse(course);
        }
        public async Task<List<Course>> GetCourseListAsync()
        {
            return await Task.FromResult(iCourseRepo.GetCourseList());
        }
    }
}
