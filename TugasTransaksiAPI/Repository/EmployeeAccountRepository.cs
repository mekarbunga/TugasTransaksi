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
    public class EmployeeAccountRepository : IEmployeeAccountRepository
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Create(VM_EmployeeAccount vM_EmployeeAccount)
        {
            parameters.Add("@name", vM_EmployeeAccount.EmployeeName);
            parameters.Add("@birthdate", vM_EmployeeAccount.EmployeeBirthDate);
            parameters.Add("@email", vM_EmployeeAccount.EmployeeEmail);
            parameters.Add("@password", vM_EmployeeAccount.AccountPassword);
            var spName = "SP_CreateAccountEmployee";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<VM_EmployeeAccount> Get()
        {
            var spName = "SP_RetrieveAccountEmployee";
            var result = connection.Query<VM_EmployeeAccount>(spName, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<VM_EmployeeAccount> Get(int id)
        {
            parameters.Add("@id", id);
            var spName = "SP_RetrieveAccountEmployeeById";
            var result = await connection.QueryAsync<VM_EmployeeAccount>(spName, parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}