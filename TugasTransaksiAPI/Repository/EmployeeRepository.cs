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
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public IEnumerable<Employee> Get()
        {
            var spName = "SP_RetrieveEmployee";
            var result = connection.Query<Employee>(spName, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<Employee> Get(int id)
        {
            parameters.Add("@id", id);
            var spName = "SP_RetrieveEmployeeById";
            var result = await connection.QueryAsync<Employee>(spName, parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        
        public int Put(Employee employee, int id)
        {
            parameters.Add("@name", employee.EmployeeName);
            parameters.Add("@birthdate", employee.EmployeeBirthDate);
            parameters.Add("@email", employee.EmployeeEmail);
            parameters.Add("@id", id);
            var spName = "SP_UpdateEmployee";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}