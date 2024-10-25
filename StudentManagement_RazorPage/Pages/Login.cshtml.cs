using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Student_BusinessObjects;
using Student_Services;

namespace StudentManagement_RazorPage.Pages
{
    public class LoginModel : PageModel
    {
        private IAccountServices _accountService;

        public LoginModel (IAccountServices accountSer)
        {
            this._accountService = accountSer;
        }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            string email = Request.Form["txtEmail"];
            string password = Request.Form["txtPassword"];
            Account account = _accountService.GetAccount(email);
            if (account != null && account.Password.Equals(password))
            {
                int? roleID = account.Role;
                HttpContext.Session.SetString("RoleID", roleID.ToString());
                //Response.Redirect("/StudentPage/Index");
                Response.Redirect("SelectionModePage");
            }
        }
    }
}
