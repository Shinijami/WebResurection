namespace WebResurection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerDifficulty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "Difficulty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "Difficulty");
        }
    }
}
