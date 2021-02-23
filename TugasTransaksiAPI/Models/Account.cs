using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TugasTransaksiAPI.Models
{
    [Table("Tb_M_Account")]
    public class Account
    {
        [Key]
        [ForeignKey("Employee")]
        public int AccountId { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string AccountPassword { get; set; }
        public virtual Employee Employee { get; set; }
    }
}