using Student_BusinessObjects;
using Student_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Services
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly IEnrollmentRepo iEnrollmentRepo;
        private readonly IFileServices<Enrollment> _fileServices;

        public EnrollmentServices(IFileServices<Enrollment> fileServices)
        {
            this.iEnrollmentRepo = new EnrollmentRepo();
            this._fileServices = fileServices;
        }
        public bool AddEnrollment(Enrollment enrollment)
        {
            return iEnrollmentRepo.AddEnrollment(enrollment);
        }

        public bool DeleteEnrollment(int id)
        {
            return iEnrollmentRepo.DeleteEnrollment(id);
        }

        public async Task<IList<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await iEnrollmentRepo.GetAllAsync();   
        }

        public Enrollment GetEnrollment(int id)
        {
            return iEnrollmentRepo.GetEnrollment(id);
        }

        public List<Enrollment> GetEnrollmentList()
        {
            return iEnrollmentRepo.GetEnrollmentList();
        }

        public List<Enrollment> SearchEnrollmentByStudentId(int id)
        {
            return iEnrollmentRepo.SearchEnrollmentByStudentId(id);
        }

        public bool UpdateEnrollment(Enrollment enrollment)
        {
            return iEnrollmentRepo.UpdateEnrollment(enrollment);
        }

        public async Task<Enrollment> GetEnrollmentWithDetailsAsync(int id)
        {
            return await iEnrollmentRepo.GetEnrollmentWithDetailsAsync(id);
        }

        public async Task<bool> AddEnrollmentAsync(Enrollment enrollment)
        {
            return await iEnrollmentRepo.AddEnrollmentAsync(enrollment);
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            return await Task.FromResult(iEnrollmentRepo.GetEnrollment(id));
        }

        public async Task<bool> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            return await Task.FromResult(iEnrollmentRepo.UpdateEnrollment(enrollment));
        }
        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            return await Task.FromResult(iEnrollmentRepo.DeleteEnrollment(id));
        }
    }
}
