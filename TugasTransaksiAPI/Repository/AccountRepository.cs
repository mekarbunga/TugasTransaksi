using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TugasTransaksiAPI.Models;

namespace TugasTransaksiAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Put(Account account, int id)
        {
            parameters.Add("@password", account.AccountPassword);
            parameters.Add("@id", id);
            var spName = "SP_UpdateAccount";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}