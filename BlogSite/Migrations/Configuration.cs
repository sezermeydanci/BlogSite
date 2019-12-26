namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogSite.Models.BlogDbContext>
    {
        public Configuration()
        {
            //Otomatik migration yapmak için true yapıyoruz.
            AutomaticMigrationsEnabled = true;
            //Migration engel çıkartmasın diye data kayıpları olabileceğini kabul ediyoruz.
            AutomaticMigrationDataLossAllowed = true;


        }

        protected override void Seed(BlogSite.Models.BlogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
