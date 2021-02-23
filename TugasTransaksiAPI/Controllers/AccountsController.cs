using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TugasTransaksiAPI.Repository;
using TugasTransaksiAPI.Models;

namespace TugasTransaksiAPI.Controllers
{
    public class AccountsController : ApiController
    {
        AccountRepository accountRepository = new AccountRepository();
        public IHttpActionResult Put(Account account, int id)
        {
            int result = accountRepository.Put(account, id);
            if (result > 0)
                return Ok();
            return InternalServerError();
        }
    }
}