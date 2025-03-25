using Microsoft.EntityFrameworkCore;
using t5_pr1_LlucVelazquez.Model;

namespace t5_pr1_LlucVelazquez.Data
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<Simulation> Simulations { get; set; }
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}
