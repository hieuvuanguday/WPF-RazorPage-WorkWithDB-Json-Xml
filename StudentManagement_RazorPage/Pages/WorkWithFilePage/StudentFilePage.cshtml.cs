using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_BusinessObjects;
using Student_Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement_RazorPage.Pages.WorkWithFilePage
{
    public class StudentFilePageModel : PageModel
    {
        private readonly IFileServices<Student> _fileServices;
        private readonly string _filePath = UploadModel.DataFilePath;

        public List<Student> Students { get; set; } = new List<Student>();

        public StudentFilePageModel(IFileServices<Student> fileServices)
        {
            _fileServices = fileServices;
        }

        public async Task OnGetAsync()
        {
            Students = await _fileServices.ReadFileAsync(_filePath);
        }

        public async Task<IActionResult> OnPostCreateAsync(string fullName, DateOnly dateOfBirth, string gender, string phoneNumber, string email, string? address, string status)
        {
            Students = await _fileServices.ReadFileAsync(_filePath);

            var newStudent = new Student
            {
                StudentId = Students.Count > 0 ? Students.Max(s => s.StudentId) + 1 : 1,
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                PhoneNumber = phoneNumber,
                Email = email,
                Address = address,
                Status = status
            };

            Students.Add(newStudent);
            await _fileServices.WriteFileAsync(Students, _filePath);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Students = await _fileServices.ReadFileAsync(_filePath);
            var studentToDelete = Students.FirstOrDefault(s => s.StudentId == id);
            if (studentToDelete != null)
            {
                Students.Remove(studentToDelete);
                await _fileServices.WriteFileAsync(Students, _filePath);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int studentId, string fullName, DateOnly dateOfBirth, string gender, string phoneNumber, string email, string? address, string status)
        {
            Students = await _fileServices.ReadFileAsync(_filePath);
            var studentToEdit = Students.FirstOrDefault(s => s.StudentId == studentId);
            if (studentToEdit != null)
            {
                studentToEdit.FullName = fullName;
                studentToEdit.DateOfBirth = dateOfBirth;
                studentToEdit.Gender = gender;
                studentToEdit.PhoneNumber = phoneNumber;
                studentToEdit.Email = email;
                studentToEdit.Address = address;
                studentToEdit.Status = status;

                await _fileServices.WriteFileAsync(Students, _filePath);
            }
            return RedirectToPage();
        }
    }
}
