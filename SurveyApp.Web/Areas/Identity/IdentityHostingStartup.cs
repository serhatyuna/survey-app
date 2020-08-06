using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Web.Areas.Identity.Data;
using SurveyApp.Web.Data;

[assembly: HostingStartup(typeof(SurveyApp.Web.Areas.Identity.IdentityHostingStartup))]
namespace SurveyApp.Web.Areas.Identity
{
	public class IdentityHostingStartup : IHostingStartup
	{
		public void Configure(IWebHostBuilder builder)
		{
			builder.ConfigureServices((context, services) =>
			{
				services.AddDefaultIdentity<ApplicationUser>()
						.AddEntityFrameworkStores<ApplicationDbContext>();

				services.Configure<IdentityOptions>(options =>
				{
					// Password settings.
					options.Password.RequireDigit = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequiredLength = 6;
					options.Password.RequiredUniqueChars = 1;

					// Lockout settings.
					options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
					options.Lockout.MaxFailedAccessAttempts = 5;
					options.Lockout.AllowedForNewUsers = true;

					// User settings.
					options.User.AllowedUserNameCharacters =
		"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
					options.User.RequireUniqueEmail = true;
				});

				services.ConfigureApplicationCookie(options =>
				{
					// Cookie settings
					options.Cookie.HttpOnly = true;
					options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
					options.LoginPath = "/Identity/Account/Login";
					options.AccessDeniedPath = "/Identity/Account/AccessDenied";
					options.SlidingExpiration = true;
				});
			});
		}
	}
}