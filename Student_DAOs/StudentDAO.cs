using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_DAOs
{
    public class StudentDAO
    {
        private StudentManagementContext _Scontext;
        private static StudentDAO instance = null;

        public static StudentDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StudentDAO();
                return instance;
            }
        }

        public StudentDAO() 
        {
            _Scontext = new StudentManagementContext();
        }

        public bool AddStudent(Student student) 
        {
            bool isSuccess = false;
            try
            {
                _Scontext.Students.Add(student);
                _Scontext.SaveChanges();
                _Scontext.Entry(student).State = EntityState.Detached;
                isSuccess = true;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return isSuccess;
        }

        public Student GetStudent(int id) 
        {
            return _Scontext.Students.SingleOrDefault(item => item.StudentId == id);
        }

        public List<Student> GetStudentList()
        {
            return _Scontext.Students.ToList();
        }

        public bool UpdateStudent(Student student)
        {
            bool isSuccess = false;
            try
            {
                Student stud = GetStudent(student.StudentId);
                if (student != null)
                {
                    _Scontext.Students.Update(student);
                    _Scontext.SaveChanges();
                    _Scontext.Entry(student).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isSuccess;
        }

        public bool DeleteStudent(int id)
        {
            bool isSuccess = false;
            try
            {
                Student stud = GetStudent(id);
                if (stud != null)
                {
                    _Scontext.Students.Remove(stud);
                    _Scontext.SaveChanges();
                    _Scontext.Entry(stud).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isSuccess;
        }

        public List<Student> SearchStudentByName(string name)
        {
            return _Scontext.Students.Where(item => item.FullName.Contains(name)).ToList();
        }
    }
}
