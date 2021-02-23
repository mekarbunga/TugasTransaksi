using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TugasTransaksiAPI.Models;
using TugasTransaksiAPI.Repository;

namespace TugasTransaksiAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        readonly EmployeeRepository employeeRepository = new EmployeeRepository();
        public IHttpActionResult Get()
        {
            var actionResult = employeeRepository.Get();
            if (actionResult.Any())
                return Ok(actionResult);
            return InternalServerError();
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var actionResult = await employeeRepository.Get(id);
            if (!(actionResult.Equals(null)))
                return Ok(actionResult);
            return InternalServerError();
        }

        public IHttpActionResult Put(Employee employee, int id)
        {
            int result = employeeRepository.Put(employee, id);
            if (result > 0)
                return Ok();
            return InternalServerError();
        }
    }
}
