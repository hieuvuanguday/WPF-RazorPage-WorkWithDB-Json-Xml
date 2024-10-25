using Student_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Services
{
    public interface IStudentServices
    {
        public bool AddStudent(Student student);
        public Student GetStudent(int id);
        public List<Student> GetStudentList();
        public bool UpdateStudent(Student student);
        public List<Student> SearchStudentByName(string name);
        public bool DeleteStudent(int id);
        public Task<List<Student>> GetStudentListAsync();
    }
}
