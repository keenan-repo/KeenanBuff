namespace KeenanBuff.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KeenanBuff.Data.SteamAPI;

    internal sealed class Configuration : DbMigrationsConfiguration<KeenanBuff.Data.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KeenanBuff.Data.Context.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            KeenanBuff.Data.SteamAPI.DatabaseActions databaseActions = new DatabaseActions();
            databaseActions.Update(context);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
