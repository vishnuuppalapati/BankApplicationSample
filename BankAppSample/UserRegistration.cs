using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppSample
{
    //User Registration Class
    public class UserRegistration
    {
        //RegistrationId is Primarykey.
        [Key]
        [Column("RegistrationId", Order = 0)]
        [Required]
        public int RegistrationId { get; set; }

        [Column("FullName", Order = 1)]
        [Required]
        [StringLength(35)]
        public string FullName { get; set; }

        [Column("FatherName", Order = 2)]
        [Required]
        [StringLength(35)]
        public string FatherName { get; set; }

        [Column("MotherName", Order = 3)]
        [Required]
        [StringLength(35)]
        public string MotherName { get; set; }

        [Column("Dateofbirth", Order = 4)]
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dateofbirth { get; set; }
        
        [Column("Age", Order =5)]
        [Required]
        [MaxLength(4)]
        public int Age { get; set; }

        [Column("MobileNumber", Order =6)]
        [Required]
        [MinLength(10),MaxLength(10)]

        public long MobileNumber { get; set; }

        [Column("PermanemtAddress", Order =7)]
        [Required]
        [StringLength(150)]
        public string PermanentAddress { get; set; }

        [Column("ResidentialAddress", Order =8)]
        [Required]
        [StringLength(150)]
        public string ResidentialAddress { get; set; }

        [Column("UserName", Order =9)]
        [Required]
        [MinLength(4), MaxLength(20)]
        public string UserName { get; set; }

        
        [Column("Password",Order =10)]
        [Required]
        [MinLength(4), MaxLength(16)]
        public string Password { get; set; }

        
    }
}