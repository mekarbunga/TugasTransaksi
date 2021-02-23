using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TugasTransaksiAPI.Models;
using TugasTransaksiAPI.Repository;

namespace TugasTransaksiAPI.Controllers
{
    public class EmployeeAccountsController : ApiController
    {
        readonly EmployeeAccountRepository employeeAccountRepository = new EmployeeAccountRepository();

        public IHttpActionResult Get()
        {
            var actionResult = employeeAccountRepository.Get();
            return Ok(actionResult);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var actionResult = await employeeAccountRepository.Get(id);
            return Ok(actionResult);
        }

        public IHttpActionResult Post(VM_EmployeeAccount vM_EmployeeAccount)
        {
            int result = employeeAccountRepository.Create(vM_EmployeeAccount);
            if (result > 0)
                return Ok();
            return InternalServerError();
        }
    }
}