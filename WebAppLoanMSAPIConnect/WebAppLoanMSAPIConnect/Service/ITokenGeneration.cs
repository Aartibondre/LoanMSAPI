
using WebAppLoanMSAPIConnect.Models;
using WebAppLoanMSAPIConnect.UserCredentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLoanMSAPIConnect.Service
{
    public interface ITokenGeneration
    {
        public string GenerateToken(UserCreds userCreds);

    }
}
