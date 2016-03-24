using System.Data.Entity.Migrations;
using ApplicationMVC.EntityModels;

namespace ApplicationMVC.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            for (int index = 1; index <= 100; index++)
            {
                context.TestEntities.AddOrUpdate(new TestEntity()
                {
                    Id = index,
                    Number = index,
                    Text = string.Format("Id: {0}, Number: {1}", index, index)
                });
            }
        }
    }
}
