using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_BusinessObjects;
using Student_Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement_RazorPage.Pages.WorkWithFilePage
{
    public class CourseFilePageModel : PageModel
    {
        private readonly IFileServices<Course> _fileServices;
        private readonly string _filePath = UploadModel.DataFilePath;

        public List<Course> Courses { get; set; } = new List<Course>();

        public CourseFilePageModel(IFileServices<Course> fileServices)
        {
            _fileServices = fileServices;
        }

        public async Task OnGetAsync()
        {
            Courses = await _fileServices.ReadFileAsync(_filePath);
        }

        public async Task<IActionResult> OnPostCreateAsync(string courseName, int credits, DateOnly startDate, DateOnly endDate)
        {
            Courses = await _fileServices.ReadFileAsync(_filePath);

            var newCourse = new Course
            {
                CourseId = Courses.Count > 0 ? Courses.Max(c => c.CourseId) + 1 : 1,
                CourseName = courseName,
                Credits = credits,
                StartDate = startDate,
                EndDate = endDate
            };

            Courses.Add(newCourse);

            await _fileServices.WriteFileAsync(Courses, _filePath);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Courses = await _fileServices.ReadFileAsync(_filePath);
            var courseToDelete = Courses.FirstOrDefault(c => c.CourseId == id);
            if (courseToDelete != null)
            {
                Courses.Remove(courseToDelete);
                await _fileServices.WriteFileAsync(Courses, _filePath);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int courseId, string courseName, int credits, DateOnly startDate, DateOnly endDate)
        {
            Courses = await _fileServices.ReadFileAsync(_filePath);
            var courseToEdit = Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (courseToEdit != null)
            {
                courseToEdit.CourseName = courseName;
                courseToEdit.Credits = credits;
                courseToEdit.StartDate = startDate;
                courseToEdit.EndDate = endDate;
                await _fileServices.WriteFileAsync(Courses, _filePath);
            }
            return RedirectToPage();
        }
    }
}
