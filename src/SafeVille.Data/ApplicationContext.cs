namespace SafeVille.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Community> Communities { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<VehicleReport> VehicleReports { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<CommunityUser>()
                .HasKey(bc => new { bc.CommunityId, bc.UserId });
            modelBuilder.Entity<CommunityUser>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserCommunities)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<CommunityUser>()
                .HasOne(bc => bc.Community)
                .WithMany(c => c.CommunityUsers)
                .HasForeignKey(bc => bc.CommunityId);
        }
    }
}