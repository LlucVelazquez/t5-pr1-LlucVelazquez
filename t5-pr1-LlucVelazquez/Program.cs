using t5_pr1_LlucVelazquez.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System;

namespace t5_pr1_LlucVelazquez
{
	public class Program
	{

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<ApplicationDBContext>(
					options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
					ServiceLifetime.Scoped
				);

			// Add services to the container.
			builder.Services.AddRazorPages();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}"
				);
			});

			//app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}

