using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages.StudentPage
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentServices _studentServices;

        public DetailsModel(IStudentServices studentServices)
        {
            this._studentServices = studentServices;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0 || _studentServices.GetStudent == null)
            {
                return NotFound();
            }

            var student = _studentServices.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
