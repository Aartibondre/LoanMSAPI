
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLoanMSAPIConnect.Data;
using WebAppLoanMSAPIConnect.Models;

namespace WebAppLoanMSAPIConnect.Service
{
    public class UserService : IUserService
    {
        private readonly WebAppLoanMSAPIConnectContext _webAppLoanMSAPIConnectContext;
        public UserService(WebAppLoanMSAPIConnectContext webAppLoanMSAPIConnectContext)
        {
            _webAppLoanMSAPIConnectContext = webAppLoanMSAPIConnectContext;
        }
        public User AddUser(User user)
        {
            try
            {
                _webAppLoanMSAPIConnectContext.UserDetails.Add(user);
                _webAppLoanMSAPIConnectContext.SaveChanges();
                return user;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<User> GetAllUser()
        {
            if (_webAppLoanMSAPIConnectContext.UserDetails.Count() > 0)
                return _webAppLoanMSAPIConnectContext.UserDetails.ToList();
            return null;
        }
    }
}
