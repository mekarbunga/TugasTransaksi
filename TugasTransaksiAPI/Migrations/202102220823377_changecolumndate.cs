namespace TugasTransaksiAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecolumndate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_M_Employee", "EmployeeBirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_M_Employee", "EmployeeBirthDate", c => c.DateTime(nullable: false));
        }
    }
}
