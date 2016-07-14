namespace MatrimonialAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Part3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Agency.Members", name: "PassionId", newName: "Passion_PassionId");
            RenameIndex(table: "Agency.Members", name: "IX_PassionId", newName: "IX_Passion_PassionId");
            CreateTable(
                "Nom.Gender",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "Agency.MemberPassion",
                c => new
                    {
                        MemberId = c.Long(nullable: false),
                        PassionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.PassionId })
                .ForeignKey("Agency.Members", t => t.MemberId)
                .ForeignKey("Agency.Passion", t => t.PassionId)
                .Index(t => t.MemberId)
                .Index(t => t.PassionId);
            
            AddColumn("Agency.Members", "GenderId", c => c.Int());
            CreateIndex("Agency.Members", "GenderId");
            AddForeignKey("Agency.Members", "GenderId", "Nom.Gender", "GenderId");
            DropColumn("Agency.Members", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("Agency.Members", "Gender", c => c.String());
            DropForeignKey("Agency.MemberPassion", "PassionId", "Agency.Passion");
            DropForeignKey("Agency.MemberPassion", "MemberId", "Agency.Members");
            DropForeignKey("Agency.Members", "GenderId", "Nom.Gender");
            DropIndex("Agency.MemberPassion", new[] { "PassionId" });
            DropIndex("Agency.MemberPassion", new[] { "MemberId" });
            DropIndex("Agency.Members", new[] { "GenderId" });
            DropColumn("Agency.Members", "GenderId");
            DropTable("Agency.MemberPassion");
            DropTable("Nom.Gender");
            RenameIndex(table: "Agency.Members", name: "IX_Passion_PassionId", newName: "IX_PassionId");
            RenameColumn(table: "Agency.Members", name: "Passion_PassionId", newName: "PassionId");
        }
    }
}
