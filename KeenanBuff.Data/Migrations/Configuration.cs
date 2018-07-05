namespace KeenanBuff.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using KeenanBuff.Data.SteamAPI;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context.ApplicationDbContext context)
        {
            SeedDatabase databaseActions = new SeedDatabase();
            databaseActions.Update(context);
        }
    }
}
