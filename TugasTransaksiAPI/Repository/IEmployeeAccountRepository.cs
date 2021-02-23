using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TugasTransaksiAPI.Models;

namespace TugasTransaksiAPI.Repository
{
    interface IEmployeeAccountRepository
    {
        IEnumerable<VM_EmployeeAccount> Get();
        Task<VM_EmployeeAccount> Get(int id);
        int Create(VM_EmployeeAccount vM_EmployeeAccount);
    }
}