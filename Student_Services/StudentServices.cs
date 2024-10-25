using Student_BusinessObjects;
using Student_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepo iStudentRepo = null;
        private readonly IFileServices<Student> _fileServices;

        public StudentServices(IFileServices<Student> fileServices)
        {
            this.iStudentRepo = new StudentRepo();
            this._fileServices = fileServices;
        }

        public bool AddStudent(Student student)
        {
            return iStudentRepo.AddStudent(student);
        }

        public bool DeleteStudent(int id)
        {
            return iStudentRepo.DeleteStudent(id);
        }

        public Student GetStudent(int id)
        {
            return iStudentRepo.GetStudent(id);
        }

        public List<Student> GetStudentList()
        {
            return iStudentRepo.GetStudentList();
        }

        public List<Student> SearchStudentByName(string name)
        {
            return iStudentRepo.SearchStudentByName(name);
        }

        public bool UpdateStudent(Student student)
        {
            return iStudentRepo.UpdateStudent(student);
        }
        public async Task<List<Student>> GetStudentListAsync()
        {
            return await Task.FromResult(iStudentRepo.GetStudentList());
        }
    }
}
