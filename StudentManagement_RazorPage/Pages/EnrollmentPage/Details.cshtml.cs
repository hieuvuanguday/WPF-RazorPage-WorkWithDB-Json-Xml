using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages.EnrollmentPage
{
    public class DetailsModel : PageModel
    {
        private readonly IEnrollmentServices _enrollmentServices;

        public DetailsModel(IEnrollmentServices enrollmentServices)
        {
            _enrollmentServices = enrollmentServices;
        }

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
    }
}
