namespace TugasTransaksiAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        AccountPassword = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Tb_M_Employee", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Tb_M_Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Account", "AccountId", "dbo.Tb_M_Employee");
            DropIndex("dbo.Tb_M_Account", new[] { "AccountId" });
            DropTable("dbo.Tb_M_Employee");
            DropTable("dbo.Tb_M_Account");
        }
    }
}
