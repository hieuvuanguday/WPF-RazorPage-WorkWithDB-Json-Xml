using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages.StudentPage
{
    public class CreateModel : PageModel
    {
        private readonly IStudentServices _studentServices;

        public CreateModel(IStudentServices studentServices)
        {
            this._studentServices = studentServices;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (_studentServices.GetStudentList() == null || Student == null)
            {
                return Page();
            }
            _studentServices.AddStudent(Student);

            return RedirectToPage("./Index");
        }
    }
}
