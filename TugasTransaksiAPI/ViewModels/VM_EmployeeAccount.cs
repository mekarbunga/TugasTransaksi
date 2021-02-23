using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TugasTransaksiAPI.Models
{
    public class VM_EmployeeAccount
    {
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }
        [DisplayName("Name")]
        public string EmployeeName { get; set; }
        [DisplayName("Birth Date")]
        public DateTime EmployeeBirthDate { get; set; }
        [DisplayName("Email")]
        public string EmployeeEmail { get; set; }
        public int AccountId { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string AccountPassword { get; set; }

        public Account Account { get; set; }
        public Employee Employee { get; set; }
    }
}