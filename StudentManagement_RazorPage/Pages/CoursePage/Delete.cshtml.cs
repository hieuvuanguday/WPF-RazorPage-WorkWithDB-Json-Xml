using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages.CoursePage
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseServices _courseServices;

        public DeleteModel(ICourseServices courseServices)
        {
            this._courseServices = courseServices;
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0 || _courseServices.GetCourseList() == null)
            {
                return NotFound();
            }

            var course = _courseServices.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _courseServices.GetCourseList() == null)
            {
                return NotFound();
            }

            var course = _courseServices.GetCourse(id);
            if (course != null)
            {
                Course = course;
                _courseServices.DeleteCourse(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
