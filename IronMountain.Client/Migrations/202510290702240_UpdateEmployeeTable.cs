namespace Iron_Mountain_Coding_Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeTable : DbMigration
    {
        public override void Up()
        {
            //Changed ID in Database directly

            //DropPrimaryKey("dbo.Employees");
            //AlterColumn("dbo.Employees", "EmployeeID", c => c.String(nullable: false, maxLength: 8, unicode: false));
            //AddPrimaryKey("dbo.Employees", "EmployeeID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmployeeID");
        }
    }
}
