using System.Data.Entity;
using ApplicationMVC.EntityModels;

namespace ApplicationMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
            : base("ApplicationMVC-Database")
        {
            this.Database.Log = (log => System.Diagnostics.Debug.WriteLine(log));
        }

        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
