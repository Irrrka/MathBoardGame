namespace MathGame.Data
{
    using System.Data.Entity;

    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("DefaultConnection")
        {
            Database.SetInitializer<AppDBContext>(new CreateDatabaseIfNotExists<AppDBContext>());

        }

        public IDbSet<User> Users { get; set; }
    }
}
