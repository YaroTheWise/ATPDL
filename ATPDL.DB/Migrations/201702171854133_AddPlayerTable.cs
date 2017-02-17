namespace ATPDL.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlayerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 10),
                        NameCode = c.String(nullable: false, maxLength: 200),
                        Birthday = c.DateTime(nullable: false),
                        StartYear = c.Int(nullable: false),
                        BirthdayPlace = c.String(nullable: false, maxLength: 100),
                        Residence = c.String(nullable: false, maxLength: 100),
                        NationalityCode = c.String(nullable: false, maxLength: 10),
                        Hand = c.Int(nullable: false),
                        Backhand = c.Int(nullable: false),
                        WeightKg = c.Int(nullable: false),
                        WeightLbs = c.Int(nullable: false),
                        HeightCm = c.Int(nullable: false),
                        HeightFoot = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.PlayerId)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Players", new[] { "Code" });
            DropTable("dbo.Players");
        }
    }
}
