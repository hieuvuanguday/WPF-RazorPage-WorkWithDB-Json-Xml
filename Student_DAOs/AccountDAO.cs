using Student_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_DAOs
{
    public class AccountDAO
    {
        private StudentManagementContext _Acontext;
        private static AccountDAO instance = null;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
        }

        public AccountDAO()
        {
            _Acontext = new StudentManagementContext();
        }

        public Account GetAccount(string email) 
        {
            return _Acontext.Accounts.SingleOrDefault(item => item.Email.Equals(email));
        }
    }
}
