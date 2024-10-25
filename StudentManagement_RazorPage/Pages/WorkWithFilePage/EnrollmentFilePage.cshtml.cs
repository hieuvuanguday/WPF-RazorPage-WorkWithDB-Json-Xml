using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_BusinessObjects;
using Student_Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement_RazorPage.Pages.WorkWithFilePage
{
    public class EnrollmentFilePageModel : PageModel
    {
        private readonly IFileServices<Enrollment> _fileServices;
        private readonly string _filePath = UploadModel.DataFilePath;

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public EnrollmentFilePageModel(IFileServices<Enrollment> fileServices)
        {
            _fileServices = fileServices;
        }

        public async Task OnGetAsync()
        {
            Enrollments = await _fileServices.ReadFileAsync(_filePath);
        }

        public async Task<IActionResult> OnPostCreateAsync(int studentId, int courseId, DateOnly enrollmentDate, string? grade, string status)
        {
            Enrollments = await _fileServices.ReadFileAsync(_filePath);

            var newEnrollment = new Enrollment
            {
                EnrollmentId = Enrollments.Count > 0 ? Enrollments.Max(e => e.EnrollmentId) + 1 : 1,
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = enrollmentDate,
                Grade = grade,
                Status = status
            };

            Enrollments.Add(newEnrollment);
            await _fileServices.WriteFileAsync(Enrollments, _filePath);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Enrollments = await _fileServices.ReadFileAsync(_filePath);
            var enrollmentToDelete = Enrollments.FirstOrDefault(e => e.EnrollmentId == id);
            if (enrollmentToDelete != null)
            {
                Enrollments.Remove(enrollmentToDelete);
                await _fileServices.WriteFileAsync(Enrollments, _filePath);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int enrollmentId, int studentId, int courseId, DateOnly enrollmentDate, string? grade, string status)
        {
            Enrollments = await _fileServices.ReadFileAsync(_filePath);
            var enrollmentToEdit = Enrollments.FirstOrDefault(e => e.EnrollmentId == enrollmentId);
            if (enrollmentToEdit != null)
            {
                enrollmentToEdit.StudentId = studentId;
                enrollmentToEdit.CourseId = courseId;
                enrollmentToEdit.EnrollmentDate = enrollmentDate;
                enrollmentToEdit.Grade = grade;
                enrollmentToEdit.Status = status;

                await _fileServices.WriteFileAsync(Enrollments, _filePath);
            }
            return RedirectToPage();
        }
    }
}
