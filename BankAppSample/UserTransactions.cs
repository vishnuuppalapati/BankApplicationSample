using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankAppSample
{
    //Transaction Class
    public class UserTransactions
    {
        //TransactionId is PrimaryKey.
        [Key]
        [Column(Order =0)]
        public int TransactionId { get; set; }

        [Column(Order = 1)]
        public decimal DepositAmount { get; set; }

        [Column(Order = 2)]
        public decimal WithdrawAmount { get; set; }

        [Column(Order = 3)]
        public decimal AvailBal { get; set; }
        [Column(Order = 3)]
        public string AccountHolderName { get; set; }

        [Column(Order =4)]
        public DateTime DateofTransaction { get; set; }

        //ForeignKey for AccountNumber.
        public virtual string AccountNumber { get; set; }

        [ForeignKey("AccountNumber")]
        public virtual AccountHolderDetails AccountHolderInfo { get; set; }
    }
}
