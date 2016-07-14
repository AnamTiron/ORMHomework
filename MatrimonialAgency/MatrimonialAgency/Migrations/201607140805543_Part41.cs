namespace MatrimonialAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Part41 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Agency.Members", "InterestedIn", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("Agency.Members", "InterestedIn", c => c.Boolean(nullable: false));
        }
    }
}
