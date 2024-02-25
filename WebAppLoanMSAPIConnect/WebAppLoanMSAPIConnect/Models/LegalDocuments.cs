using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLoanMSAPIConnect.Models
{
    [Table("LegalDocuments")]
    public class LegalDocuments
    {
        [Key]
        public int ApplicationNo { get; set; }

        [StringLength(50)]
        public string PropertyProof { get; set; }
        [Required]
        [StringLength(50)]
        public string BankSalarySlip { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressProof { get; set; }

        [Required]
        [StringLength(50)]
        public string GuarantorName { get; set; }

        [Required]
        [StringLength(50)]
        public string GuarantorProofType { get; set; }

        [Required]
        [StringLength(50)]
        public string GuarantorProofId { get; set; }

        public int ApplicantId { get; set; }

        public PropertyInformation Property { get; set; }
    }
}
