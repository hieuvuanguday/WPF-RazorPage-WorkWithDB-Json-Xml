using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages.EnrollmentPage
{
    public class IndexModel : PageModel
    {
        private readonly IEnrollmentServices _enrollmentServices;

        public IndexModel(IEnrollmentServices enrollmentServices)
        {
            this._enrollmentServices = enrollmentServices;
        }

        public IList<Enrollment> Enrollment { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Enrollment = await _enrollmentServices.GetAllEnrollmentsAsync();
        }
    }
}
