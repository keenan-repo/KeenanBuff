namespace KeenanBuff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        HeroId = c.Int(nullable: false, identity: true),
                        HeroName = c.String(),
                        HeroUrl = c.String(),
                    })
                .PrimaryKey(t => t.HeroId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ItemUrl = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.MatchDetails",
                c => new
                    {
                        MatchDetailId = c.Guid(nullable: false),
                        PlayerID = c.Long(nullable: false),
                        MatchID = c.Long(nullable: false),
                        SteamName = c.String(),
                        PlayerSlot = c.Int(nullable: false),
                        HeroId = c.Int(nullable: false),
                        Kills = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        LeaverStatus = c.Int(nullable: false),
                        LastHits = c.Int(nullable: false),
                        Denies = c.Int(nullable: false),
                        GoldPerMin = c.Int(nullable: false),
                        XpPerMin = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Gold = c.Int(nullable: false),
                        GoldSpent = c.Int(nullable: false),
                        HeroDamage = c.Int(nullable: false),
                        TowerDamage = c.Int(nullable: false),
                        HeroHealing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchDetailId)
                .ForeignKey("dbo.Heroes", t => t.HeroId, cascadeDelete: true)
                .ForeignKey("dbo.Matches", t => t.MatchID, cascadeDelete: true)
                .Index(t => t.MatchID)
                .Index(t => t.HeroId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchID = c.Long(nullable: false),
                        MatchSeqNum = c.Long(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        LobbyType = c.Int(nullable: false),
                        LobbyString = c.String(),
                        GameMode = c.Int(nullable: false),
                        GameModeString = c.String(),
                        RadiantTeamId = c.Int(nullable: false),
                        DireTeamId = c.Int(nullable: false),
                        RadiantWin = c.Boolean(nullable: false),
                        Duration = c.Int(nullable: false),
                        TowerStatusRadiant = c.Int(nullable: false),
                        TowerStatusDire = c.Int(nullable: false),
                        BarracksStatusRadiant = c.Int(nullable: false),
                        BarracksStatusDire = c.Int(nullable: false),
                        FirstBloodTime = c.Int(nullable: false),
                        RadiantScore = c.Int(nullable: false),
                        DireScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchID);
            
            CreateTable(
                "dbo.PlayerItems",
                c => new
                    {
                        PlayerItemId = c.Guid(nullable: false),
                        MatchDetailId = c.Guid(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerItemId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.MatchDetails", t => t.MatchDetailId, cascadeDelete: true)
                .Index(t => t.MatchDetailId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerItems", "MatchDetailId", "dbo.MatchDetails");
            DropForeignKey("dbo.PlayerItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.MatchDetails", "MatchID", "dbo.Matches");
            DropForeignKey("dbo.MatchDetails", "HeroId", "dbo.Heroes");
            DropIndex("dbo.PlayerItems", new[] { "ItemId" });
            DropIndex("dbo.PlayerItems", new[] { "MatchDetailId" });
            DropIndex("dbo.MatchDetails", new[] { "HeroId" });
            DropIndex("dbo.MatchDetails", new[] { "MatchID" });
            DropTable("dbo.PlayerItems");
            DropTable("dbo.Matches");
            DropTable("dbo.MatchDetails");
            DropTable("dbo.Items");
            DropTable("dbo.Heroes");
        }
    }
}
