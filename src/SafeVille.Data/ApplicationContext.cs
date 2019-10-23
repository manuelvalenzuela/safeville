namespace SafeVille.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        private static ApplicationContext _context;
        public ApplicationContext()
        {
        }

        public static ApplicationContext GetInstance => _context ??= new ApplicationContext();

        public DbSet<Community> Communities  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cnn = "Server=safeville.database.windows.net; Initial Catalog=safeville_dev_db;Persist Security Info=False;User ID=safeville_sa; Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(cnn);
        }
    }
}