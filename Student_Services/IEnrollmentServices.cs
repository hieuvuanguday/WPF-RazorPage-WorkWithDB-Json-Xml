using Student_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Services
{
    public interface IEnrollmentServices
    {
        public bool AddEnrollment(Enrollment enrollment);
        public Enrollment GetEnrollment(int id);
        public List<Enrollment> GetEnrollmentList();
        public bool UpdateEnrollment(Enrollment enrollment);
        public bool DeleteEnrollment(int id);
        public List<Enrollment> SearchEnrollmentByStudentId(int id);
        public Task<IList<Enrollment>> GetAllEnrollmentsAsync();
        public Task<Enrollment> GetEnrollmentWithDetailsAsync(int id);
        public Task<bool> AddEnrollmentAsync(Enrollment enrollment);
        public Task<Enrollment> GetEnrollmentByIdAsync(int id);
        public Task<bool> UpdateEnrollmentAsync(Enrollment enrollment);
        public Task<bool> DeleteEnrollmentAsync(int id);
    }
}
