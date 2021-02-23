namespace TugasTransaksiAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_M_Employee", "EmployeeBirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tb_M_Employee", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_M_Employee", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tb_M_Employee", "EmployeeBirthDate");
        }
    }
}
