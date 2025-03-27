using Microsoft.EntityFrameworkCore;
using t5_pr1_LlucVelazquez.Model;

namespace t5_pr1_LlucVelazquez.Data
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<DbSimulation> Simulations { get; set; }
        public DbSet<DbEnergyIndicator> EnergyIndicators { get; set; }
		public DbSet<DbWaterConsume> WaterConsumes { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
