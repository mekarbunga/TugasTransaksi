
namespace TugasTransaksiAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tb_M_Employee", new[] { "EmployeeEmail" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Tb_M_Employee", "EmployeeEmail", unique: true);
        }
    }
}
