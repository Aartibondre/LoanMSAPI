using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLoanMSAPIConnect.Models
{
    [Table("BorrowerInformation")]
    public class BorrowerInformation
    {
        [Key]
        public int BorrowerId { get; set; }
        
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string Contact { get; set; }

        [Required]
        public DateTime Dob { get; set; }
        public String Gender { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public string IdentityType { get; set; }
        [Required]
        public string IdentityId { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        private string status = "UnderReview";
        public string Status { get {return status; } set { status = value; } }//Default value is Rejected
       
    }
}
