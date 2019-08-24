using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankAppSample
{
    //Account Holder Class
    public class AccountHolderDetails
    {
        //AccountNumber is PrimaryKey.
        [Key]
        [Column("AccountNumber",Order =0)]
        [Required]
        public string AccountNumber { get; set; }

        [Column("AcHolderName",Order =1)]
        [Required]
        [StringLength(35)]
        public string AcHolderName { get; set; }
        [Column("Availbalance",Order =2)]
        [Required]
        public decimal AvailBalance { get; set; }
        
        //ForeignKey for RegistrationId.
        public virtual int RegistrationId { get; set; } 

        [ForeignKey("RegistrationId")]
        public virtual UserRegistration RegistrationInfo { get; set; }

    }
}
