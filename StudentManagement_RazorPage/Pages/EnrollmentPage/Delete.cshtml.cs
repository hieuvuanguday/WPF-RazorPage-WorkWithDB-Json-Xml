using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_BusinessObjects;
using Student_Services;
using System.Threading.Tasks;

namespace StudentManagement_RazorPage.Pages.EnrollmentPage
{
    public class DeleteModel : PageModel
    {
        private readonly IEnrollmentServices _enrollmentServices;

        public DeleteModel(IEnrollmentServices enrollmentServices)
        {
            _enrollmentServices = enrollmentServices;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _enrollmentServices.GetEnrollmentWithDetailsAsync(id.Value);

            if (enrollment == null)
            {
                return NotFound();
            }
            else
            {
                Enrollment = enrollment;
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _enrollmentServices.DeleteEnrollmentAsync(id.Value);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}

