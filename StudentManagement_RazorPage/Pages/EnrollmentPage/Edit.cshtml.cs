using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages.EnrollmentPage
{
    public class EditModel : PageModel
    {
        private readonly IEnrollmentServices _enrollmentServices;
        private readonly IStudentServices _studentServices;
        private readonly ICourseServices _courseServices;
        public EditModel(IEnrollmentServices enrollmentServices, IStudentServices studentServices, ICourseServices courseServices)
        {
            _enrollmentServices = enrollmentServices;
            _studentServices = studentServices;
            _courseServices = courseServices;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment = await _enrollmentServices.GetEnrollmentByIdAsync(id.Value);
            if (Enrollment == null)
            {
                return NotFound();
            }

            ViewData["CourseId"] = new SelectList(await _courseServices.GetCourseListAsync(), "CourseId", "CourseName");
            ViewData["StudentId"] = new SelectList(await _studentServices.GetStudentListAsync(), "StudentId", "FullName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _enrollmentServices.UpdateEnrollmentAsync(Enrollment);

            return RedirectToPage("./Index");
        }
    }
}
