using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Web.Areas.Identity.Data;
using SurveyApp.Web.Models;
using System;

namespace SurveyApp.Web.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
				: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<FilledSurveyOption>()
					.HasKey(t => new { t.FilledSurveyId, t.OptionId });
		}

		public DbSet<Survey> Surveys { get; set; }

		public DbSet<Question> Questions { get; set; }

		public DbSet<Option> Options { get; set; }

		public DbSet<FilledSurvey> FilledSurveys { get; set; }

		internal void UpdateRange(object testRowFatContents)
		{
			throw new NotImplementedException();
		}
	}
}
