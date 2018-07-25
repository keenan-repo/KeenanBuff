namespace KeenanBuff.Entites.Migrations
{
    using System.Data.Entity.Migrations;
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
            //data will be seeded through web
        }
    }
}
