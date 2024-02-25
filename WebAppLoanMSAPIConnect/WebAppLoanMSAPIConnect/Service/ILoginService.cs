
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLoanMSAPIConnect.Models;
using WebAppLoanMSAPIConnect.UserCredentials;

namespace WebAppLoanMSAPIConnect.Service
{
    public interface ILoginService
    {
        UserCreds Login(UserCreds userCreds);
        UserCreds Register(User user);
    }
}
