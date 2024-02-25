using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppLoanMSAPIConnect.Models;
 
namespace WebAppLoanMSAPIConnect.Data
{
    public class WebAppLoanMSAPIConnectContext : DbContext
    {
        public WebAppLoanMSAPIConnectContext (DbContextOptions<WebAppLoanMSAPIConnectContext> options)
            : base(options)
        {
        }
        public DbSet<WebAppLoanMSAPIConnect.Models.User> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserNameOrEmail = "admin",
                    Password = "A@123",



                });
        }
        public DbSet<WebAppLoanMSAPIConnect.Models.BorrowerInformation> BorrowerInformation { get; set; }

        public DbSet<WebAppLoanMSAPIConnect.Models.PropertyInformation> PropertyInformation { get; set; }

        public DbSet<WebAppLoanMSAPIConnect.Models.LegalDocuments> LegalDocuments { get; set; }
     
        public DbSet<WebAppLoanMSAPIConnect.Models.Contact> Contact_1 { get; set; }
    }
}
