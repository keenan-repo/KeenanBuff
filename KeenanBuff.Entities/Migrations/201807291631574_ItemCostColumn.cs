namespace KeenanBuff.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemCostColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Cost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Cost");
        }
    }
}
