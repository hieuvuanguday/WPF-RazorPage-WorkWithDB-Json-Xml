using Student_BusinessObjects;
using Student_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Repositories
{
    public class AccountRepo : IAccountRepo
    {
        public Account GetAccount(string email) => AccountDAO.Instance.GetAccount(email);
    }
}
