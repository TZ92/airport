namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class samar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deals", "Active", c => c.Boolean(nullable: false));
            DropColumn("dbo.Deals", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deals", "Photo", c => c.String(unicode: false));
            AlterColumn("dbo.Deals", "Active", c => c.Int());
        }
    }
}
