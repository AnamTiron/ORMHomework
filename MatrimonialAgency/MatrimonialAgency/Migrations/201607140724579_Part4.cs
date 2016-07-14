namespace MatrimonialAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Part4 : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "Agency.Members", name: "UX_Email", newName: "IX_Email");
            AddColumn("Agency.Location", "PostalCode", c => c.String(maxLength: 30));
            AlterColumn("Nom.Gender", "Name", c => c.String(maxLength: 150));
            AlterColumn("Agency.Location", "StateProvince", c => c.String(maxLength: 150));
            AlterColumn("Agency.Members", "FirstName", c => c.String(maxLength: 150));
            AlterColumn("Agency.Members", "LastName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("Agency.Members", "PhoneNumber", c => c.String(maxLength: 150));
            AlterColumn("Agency.Passion", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("Agency.Passion", "YearsOfTraining", c => c.Decimal(precision: 10, scale: 2));
            CreateIndex("Agency.Location", new[] { "City", "PostalCode" }, unique: true, name: "UX_CityAndPostalCode");
            CreateIndex("Agency.Members", "LastName");
        }
        
        public override void Down()
        {
            DropIndex("Agency.Members", new[] { "LastName" });
            DropIndex("Agency.Location", "UX_CityAndPostalCode");
            AlterColumn("Agency.Passion", "YearsOfTraining", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("Agency.Passion", "Name", c => c.String(nullable: false));
            AlterColumn("Agency.Members", "PhoneNumber", c => c.String());
            AlterColumn("Agency.Members", "LastName", c => c.String(nullable: false));
            AlterColumn("Agency.Members", "FirstName", c => c.String());
            AlterColumn("Agency.Location", "StateProvince", c => c.String());
            AlterColumn("Nom.Gender", "Name", c => c.String());
            DropColumn("Agency.Location", "PostalCode");
            RenameIndex(table: "Agency.Members", name: "IX_Email", newName: "UX_Email");
        }
    }
}
