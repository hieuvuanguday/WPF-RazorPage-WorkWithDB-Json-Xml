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
    public class IndexModel : PageModel
    {
        private readonly ICourseServices _courseServices;

        public IndexModel(ICourseServices courseServices)
        {
            this._courseServices = courseServices;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if(_courseServices.GetCourseList() != null)
            {
                Course = _courseServices.GetCourseList();
            }
        }
    }
}
