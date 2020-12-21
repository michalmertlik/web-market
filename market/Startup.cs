using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using market.Data;
using market.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace market
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlite(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddDefaultIdentity<IdentityUser>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddControllersWithViews()
				.AddJsonOptions(c => {
					c.JsonSerializerOptions.Converters.Add(new GenderTypeConvertor());
					c.JsonSerializerOptions.Converters.Add(new DateTimeConvertor());
				});
			services.AddSingleton<ImageService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				//app.UseHsts();
			}
			//app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}

	class GenderTypeConvertor : JsonConverter<GenderType>
	{
		public override GenderType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, GenderType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(Enum.GetName(typeof(GenderType), value));
		}
	}

	class DateTimeConvertor : JsonConverter<DateTime>
	{
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToString("MMM d, yyyy, hh:mm:ss tt"));
		}
	}
}
