namespace WebResurection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        HealthPoints = c.Double(nullable: false),
                        Damage = c.Double(nullable: false),
                        isPlayer = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ImplementedSkill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        Modifier = c.Double(nullable: false),
                        hasPassed = c.Boolean(nullable: false),
                        hasCritPassed = c.Boolean(nullable: false),
                        SkillId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Skill", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ImplementedStat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        Modifier = c.Double(nullable: false),
                        StatId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Stat", t => t.StatId, cascadeDelete: true)
                .Index(t => t.StatId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Stat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NPC",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NpcString = c.String(),
                        CharacterId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlayerString = c.String(),
                        CharacterId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.NPC", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.ImplementedStat", "StatId", "dbo.Stat");
            DropForeignKey("dbo.ImplementedStat", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.ImplementedSkill", "SkillId", "dbo.Skill");
            DropForeignKey("dbo.ImplementedSkill", "CharacterId", "dbo.Character");
            DropIndex("dbo.Player", new[] { "CharacterId" });
            DropIndex("dbo.NPC", new[] { "CharacterId" });
            DropIndex("dbo.ImplementedStat", new[] { "CharacterId" });
            DropIndex("dbo.ImplementedStat", new[] { "StatId" });
            DropIndex("dbo.ImplementedSkill", new[] { "CharacterId" });
            DropIndex("dbo.ImplementedSkill", new[] { "SkillId" });
            DropTable("dbo.Player");
            DropTable("dbo.NPC");
            DropTable("dbo.Stat");
            DropTable("dbo.ImplementedStat");
            DropTable("dbo.Skill");
            DropTable("dbo.ImplementedSkill");
            DropTable("dbo.Character");
        }
    }
}
