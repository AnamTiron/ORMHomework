namespace MatrimonialAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Part2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Agency.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 30),
                        StateProvince = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "Agency.Members",
                c => new
                    {
                        MemberId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        InterestedIn = c.Boolean(nullable: false),
                        LocationId = c.Int(),
                        PassionId = c.Int(),
                        Email = c.String(nullable: false, maxLength: 25),
                        PhoneNumber = c.String(),
                        DateOfJoining = c.DateTime(),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("Agency.Location", t => t.LocationId)
                .ForeignKey("Agency.Passion", t => t.PassionId)
                .Index(t => t.LocationId)
                .Index(t => t.PassionId)
                .Index(t => t.Email, unique: true, name: "UX_Email");
            
            CreateTable(
                "Agency.Passion",
                c => new
                    {
                        PassionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        YearsOfTraining = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PassionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Agency.Members", "PassionId", "Agency.Passion");
            DropForeignKey("Agency.Members", "LocationId", "Agency.Location");
            DropIndex("Agency.Members", "UX_Email");
            DropIndex("Agency.Members", new[] { "PassionId" });
            DropIndex("Agency.Members", new[] { "LocationId" });
            DropTable("Agency.Passion");
            DropTable("Agency.Members");
            DropTable("Agency.Location");
        }
    }
}
