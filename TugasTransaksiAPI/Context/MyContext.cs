using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TugasTransaksiAPI.Models;

namespace TugasTransaksiAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("myConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}