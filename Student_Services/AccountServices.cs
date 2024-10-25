using Student_BusinessObjects;
using Student_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Services
{
    public class AccountServices : IAccountServices
    {
        public readonly IAccountRepo iAccountRepo = null;

        public AccountServices()
        {
            iAccountRepo = new AccountRepo();
        }

        public Account GetAccount(string email)
        {
            return iAccountRepo.GetAccount(email);
        }
    }
}
