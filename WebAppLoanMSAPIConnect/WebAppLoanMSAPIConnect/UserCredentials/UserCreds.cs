using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLoanMSAPIConnect.UserCredentials
{
 
    public class UserCreds
    {
         
        public string username { get; set; }

        public string password { get; set; }

#nullable enable
        public string? token { get; set; }

    }
}
