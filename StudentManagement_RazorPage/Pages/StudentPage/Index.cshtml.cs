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
    public class IndexModel : PageModel
    {
        private readonly IStudentServices _studentServices;

        public IndexModel(IStudentServices studentServices)
        {
            this._studentServices = studentServices;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if(_studentServices.GetStudentList != null)
                Student = _studentServices.GetStudentList();
        }
    }
}
