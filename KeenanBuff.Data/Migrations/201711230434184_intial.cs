namespace KeenanBuff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        localized_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        localized_name = c.String(),
                        url = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MatchDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PlayerID = c.Long(nullable: false),
                        MatchID = c.Long(nullable: false),
                        SteamName = c.String(),
                        PlayerSlot = c.Int(nullable: false),
                        HeroId = c.Int(nullable: false),
                        HeroName = c.String(),
                        HeroUrl = c.String(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.MatchID, cascadeDelete: true)
                .Index(t => t.MatchID);
            
            CreateTable(
                "dbo.PlayerItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ItemId = c.Long(nullable: false),
                        localized_name = c.String(),
                        url = c.String(),
                        MatchDetail_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MatchDetails", t => t.MatchDetail_Id)
                .Index(t => t.MatchDetail_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchDetails", "MatchID", "dbo.Matches");
            DropForeignKey("dbo.PlayerItems", "MatchDetail_Id", "dbo.MatchDetails");
            DropIndex("dbo.PlayerItems", new[] { "MatchDetail_Id" });
            DropIndex("dbo.MatchDetails", new[] { "MatchID" });
            DropTable("dbo.Matches");
            DropTable("dbo.PlayerItems");
            DropTable("dbo.MatchDetails");
            DropTable("dbo.Items");
            DropTable("dbo.Heroes");
        }
    }
}
