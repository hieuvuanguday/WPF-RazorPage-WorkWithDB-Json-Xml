using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using Student_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Repositories
{
    public class EnrollmentRepo : IEnrollmentRepo
    {
        public bool AddEnrollment(Enrollment enrollment) => EnrollmentDAO.Instance.AddEnrollment(enrollment);
        public bool DeleteEnrollment(int id) => EnrollmentDAO.Instance.DeleteEnrollment(id);

        public Task<IList<Enrollment>> GetAllAsync() => EnrollmentDAO.Instance.GetAllAsync();

        public Enrollment GetEnrollment(int id) => EnrollmentDAO.Instance.GetEnrollment(id);
        public List<Enrollment> GetEnrollmentList() => EnrollmentDAO.Instance.GetEnrollmentList();

        public List<Enrollment> SearchEnrollmentByStudentId(int id) => EnrollmentDAO.Instance.SearchEnrollmentByStudentId((int)id);
        public bool UpdateEnrollment(Enrollment enrollment) => EnrollmentDAO.Instance.UpdateEnrollment(enrollment);
        public async Task<Enrollment> GetEnrollmentWithDetailsAsync(int id) => await EnrollmentDAO.Instance.GetEnrollmentWithDetailsAsync(id);
        public async Task<bool> AddEnrollmentAsync(Enrollment enrollment) => await EnrollmentDAO.Instance.AddEnrollmentAsync(enrollment);
    }
}
