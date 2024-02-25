
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLoanMSAPIConnect.Models;

namespace WebAppLoanMSAPIConnect.Service
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User AddUser(User user);
    }
}
