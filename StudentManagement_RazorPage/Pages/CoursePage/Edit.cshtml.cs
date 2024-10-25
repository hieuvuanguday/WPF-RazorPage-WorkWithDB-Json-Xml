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

namespace StudentManagement_RazorPage.Pages.CoursePage
{
    public class EditModel : PageModel
    {
        private readonly ICourseServices _courseServices;

        public EditModel(ICourseServices courseServices)
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
            Course = course;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _courseServices.UpdateCourse(Course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.CourseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CourseExists(int id)
        {
            return _courseServices.GetCourse(id) != null;
        }
    }
}
