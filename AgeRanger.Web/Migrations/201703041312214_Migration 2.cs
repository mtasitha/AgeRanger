namespace AgeRanger.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AgeGroups", "MinAge", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AgeGroups", "MinAge", c => c.Int(nullable: false));
        }
    }
}
