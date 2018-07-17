namespace KeenanBuff.Entites.Migrations
{
    using System.Data.Entity.Migrations;
    using KeenanBuff.Common.Logger.Interfaces;
    using KeenanBuff.Entites.SteamAPI;
    using KeenanBuff.Entities.Context;
    

    internal sealed class Configuration : DbMigrationsConfiguration<KeenanBuffContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KeenanBuffContext context)
        {
            var databaseActions = new SeedDatabase();
            databaseActions.Update(context);
        }
    }
}
