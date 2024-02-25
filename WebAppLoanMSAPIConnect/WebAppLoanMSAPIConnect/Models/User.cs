using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLoanMSAPIConnect.Models
{
    [Table("UserDetails")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        //[RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Numeric only not allowed")]
        public string UserNameOrEmail { get; set; }
        [Required]

        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]

        public string Confirm_Password { get; set; }



#nullable enable
        //public byte[]? PasswordHashCode { get; set; }
        //public byte[]? Key { get; set; }
    }
}
