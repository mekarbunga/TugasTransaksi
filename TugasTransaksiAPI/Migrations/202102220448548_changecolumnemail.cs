namespace TugasTransaksiAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecolumnemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_M_Employee", "EmployeeEmail", c => c.String());
            DropColumn("dbo.Tb_M_Employee", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_M_Employee", "Email", c => c.String());
            DropColumn("dbo.Tb_M_Employee", "EmployeeEmail");
        }
    }
}
