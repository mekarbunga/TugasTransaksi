using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasTransaksiAPI.Models;

namespace TugasTransaksiAPI.Repository
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Task<Employee> Get(int id);
        int Put(Employee employee, int id);
    }
}
