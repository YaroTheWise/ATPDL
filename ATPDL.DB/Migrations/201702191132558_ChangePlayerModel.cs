namespace ATPDL.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePlayerModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "BirthdayPlace", c => c.String(maxLength: 100));
            AlterColumn("dbo.Players", "Residence", c => c.String(maxLength: 100));
            AlterColumn("dbo.Players", "NationalityCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Players", "HeightFoot", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "HeightFoot", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Players", "NationalityCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Players", "Residence", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Players", "BirthdayPlace", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
