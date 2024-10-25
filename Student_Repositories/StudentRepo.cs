using Student_BusinessObjects;
using Student_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Repositories
{
    public class StudentRepo : IStudentRepo
    {
        public bool AddStudent(Student student) => StudentDAO.Instance.AddStudent(student);
        public bool DeleteStudent(int id) => StudentDAO.Instance.DeleteStudent(id);
        public Student GetStudent(int id) => StudentDAO.Instance.GetStudent(id);
        public List<Student> GetStudentList() => StudentDAO.Instance.GetStudentList();

        public List<Student> SearchStudentByName(string name) => StudentDAO.Instance.SearchStudentByName(name);
        public bool UpdateStudent(Student student) => StudentDAO.Instance.UpdateStudent(student);
    }
}
