using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasTransaksiAPI.Models;

namespace TugasTransaksiAPI.Repository
{
    interface IAccountRepository
    {
        int Put(Account account, int id);
    }
}
