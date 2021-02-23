namespace TugasTransaksiAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_M_Account", "AccountPassword", c => c.String(nullable: false));
            CreateIndex("dbo.Tb_M_Employee", "EmployeeEmail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tb_M_Employee", new[] { "EmployeeEmail" });
            AlterColumn("dbo.Tb_M_Account", "AccountPassword", c => c.String());
        }
    }
}
