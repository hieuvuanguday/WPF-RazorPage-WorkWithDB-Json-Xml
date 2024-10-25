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
    public class DetailsModel : PageModel
    {
        private readonly ICourseServices _courseServices;

        public DetailsModel(ICourseServices courseServices)
        {
            this._courseServices = courseServices;
        }

        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0 || _courseServices.GetCourse == null)
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
    }
}
