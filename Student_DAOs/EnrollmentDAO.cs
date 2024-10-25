using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_DAOs
{
    public class EnrollmentDAO
    {
        private StudentManagementContext _Econtext;
        private static EnrollmentDAO instance = null;

        public static EnrollmentDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new EnrollmentDAO();
                return instance;
            }
        }

        public EnrollmentDAO() 
        {
            _Econtext = new StudentManagementContext();
        }

        public bool AddEnrollment(Enrollment enrollment)
        {
            bool isSuccess = false;
            try
            {
                _Econtext.Enrollments.Add(enrollment);
                _Econtext.SaveChanges();
                _Econtext.Entry(enrollment).State = EntityState.Detached;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public Enrollment GetEnrollment(int id)
        {
            return _Econtext.Enrollments.SingleOrDefault(item => item.EnrollmentId == id);
        }

        public List<Enrollment> GetEnrollmentList()
        {
            return _Econtext.Enrollments.ToList();
        }

        public bool UpdateEnrollment(Enrollment enrollment)
        {
            bool isSuccess = false;
            try
            {
                Enrollment enroll = GetEnrollment(enrollment.EnrollmentId);
                if (enroll != null)
                {
                    _Econtext.Enrollments.Update(enrollment);
                    _Econtext.SaveChanges();
                    _Econtext.Entry(enrollment).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isSuccess;
        }

        public bool DeleteEnrollment(int id)
        {
            bool isSuccess = false;
            try
            {
                Enrollment enrollment = GetEnrollment(id);
                if (enrollment != null)
                {
                    _Econtext.Enrollments.Remove(enrollment);
                    _Econtext.SaveChanges();
                    _Econtext.Entry(enrollment).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
        public List<Enrollment> SearchEnrollmentByStudentId(int id)
        {
            return _Econtext.Enrollments.Where(item => item.StudentId == (id)).ToList();
        }
        public async Task<IList<Enrollment>> GetAllAsync()
        {
            return await _Econtext.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Student)
                .ToListAsync();
        }
        public async Task<Enrollment> GetEnrollmentWithDetailsAsync(int id)
        {
            return await _Econtext.Enrollments.Include(e => e.Course).Include(e => e.Student).FirstOrDefaultAsync(m => m.EnrollmentId == id);
        }

        public async Task<bool> AddEnrollmentAsync(Enrollment enrollment)
        {
            bool isSuccess = false;
            try
            {
                await _Econtext.Enrollments.AddAsync(enrollment);
                await _Econtext.SaveChangesAsync();
                _Econtext.Entry(enrollment).State = EntityState.Detached;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
    }
}
