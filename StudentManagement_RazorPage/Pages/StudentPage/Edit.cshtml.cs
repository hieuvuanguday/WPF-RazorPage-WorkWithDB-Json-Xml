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

namespace StudentManagement_RazorPage.Pages.StudentPage
{
    public class EditModel : PageModel
    {
        private readonly IStudentServices _studentServices;

        public EditModel(IStudentServices studentServices)
        {
            this._studentServices = studentServices;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0 || _studentServices.GetStudentList() == null)
            {
                return NotFound();
            }

            var student = _studentServices.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
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
                _studentServices.UpdateStudent(Student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.StudentId))
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

        private bool StudentExists(int id)
        {
            return _studentServices.GetStudent(id) != null;
        }
    }
}
