using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_DAOs
{
    public class CourseDAO
    {
        private StudentManagementContext _Ccontext;
        private static CourseDAO instance = null;

        public static CourseDAO Instance
        {
            get
            {
                if(instance == null)
                    instance = new CourseDAO();
                return instance;
            }
        }

        public CourseDAO() 
        {
            _Ccontext = new StudentManagementContext();
        }

        public bool AddCourse(Course course)
        {
            bool isSuccess = false;
            try
            {
                _Ccontext.Courses.Add(course);
                _Ccontext.SaveChanges();
                _Ccontext.Entry(course).State = EntityState.Detached;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public Course GetCourse(int id) 
        {
            return _Ccontext.Courses.SingleOrDefault(item => item.CourseId == id);  
        }

        public List<Course> GetCourseList()
        {
            return _Ccontext.Courses.ToList();
        }

        public bool UpdateCourse(Course course)
        {
            bool isSuccess = false;
            try
            {
                Course cour = GetCourse(course.CourseId);
                if (cour != null)
                {
                    _Ccontext.Courses.Update(course);
                    _Ccontext.SaveChanges();
                    _Ccontext.Entry(course).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isSuccess;
        }

        public bool DeleteCourse(int id)
        {
            bool isSuccess = false;
            try
            {
                Course course = GetCourse(id);
                if (course != null)
                {
                    _Ccontext.Courses.Remove(course);
                    _Ccontext.SaveChanges();
                    _Ccontext.Entry(course).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public List<Course> SearchCourseByName(string name)
        {
            return _Ccontext.Courses.Where(item => item.CourseName.Contains(name)).ToList();
        }
    }
}
