using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TugasTransaksiAPI.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        [Key]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }
        [DisplayName("Name")]
        public string EmployeeName { get; set; }
        [DisplayName("Birth Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime EmployeeBirthDate { get; set; }
        [DisplayName("Email")]
        public string EmployeeEmail { get; set; }
        public virtual Account Account { get; set; }
    }
}