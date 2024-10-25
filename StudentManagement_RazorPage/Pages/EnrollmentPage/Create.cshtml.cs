using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages.EnrollmentPage
{
    public class CreateModel : PageModel
    {
        private readonly IEnrollmentServices _enrollmentServices;
        private readonly IStudentServices _studentServices;
        private readonly ICourseServices _courseServices;

        public CreateModel(IEnrollmentServices enrollmentServices, IStudentServices studentServices, ICourseServices courseServices)
        {
            _enrollmentServices = enrollmentServices;
            _studentServices = studentServices;
            _courseServices = courseServices;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["CourseId"] = new SelectList(_courseServices.GetCourseList(), "CourseId", "CourseName");
            ViewData["StudentId"] = new SelectList(_studentServices.GetStudentList(), "StudentId", "FullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _enrollmentServices.AddEnrollmentAsync(Enrollment);
            if (!result)
            {
                ModelState.AddModelError("", "Unable to save enrollment.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
