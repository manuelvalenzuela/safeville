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

        public DbSet<User> Users { get; set; }

        public DbSet<VehicleReport> VehicleReports { get; set; }

        public DbSet<Vehicle> Vehicles  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cnn = "Server=safeville.database.windows.net; Initial Catalog=safeville_dev_db;Persist Security Info=False;User ID=safeville_sa; Password=$af3Vill3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(cnn);
        }
    }
}