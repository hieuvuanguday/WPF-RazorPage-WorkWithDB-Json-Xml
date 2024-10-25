using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages.CoursePage
{
    public class CreateModel : PageModel
    {
        private readonly ICourseServices _courseServices;

        public CreateModel(ICourseServices courseServices)
        {
            this._courseServices = courseServices;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (_courseServices.GetCourseList() == null || Course == null)
            {
                return Page();
            }

            _courseServices.AddCourse(Course);

            return RedirectToPage("./Index");
        }
    }
}
