using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SurveyApp.Web.Areas.Identity.Data;
using SurveyApp.Web.Data;
using SurveyApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Services
{
	public class SurveyService
	{
		private readonly ApplicationDbContext _context;

		public SurveyService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Survey[]> GetAllSurveysAsync(ApplicationUser user)
		{
			return await _context.Surveys
				.Where(s => s.UserId == user.Id)
				.Include(s => s.Questions)
				.Include(s => s.FilledSurveys)
				.ToArrayAsync();
		}

		public async Task<Survey> GetSurveyOfUserByIdAsync(int id, ApplicationUser user)
		{
			return await _context.Surveys
				.Where(s => s.Id == id && s.UserId == user.Id)
				.Include(s => s.Questions)
					.ThenInclude(q => q.Options)
				.Include(s => s.FilledSurveys)
				.FirstOrDefaultAsync();
		}

		public async Task<Survey> GetSurveyByIdAsync(int id)
		{
			return await _context.Surveys
				.Where(s => s.Id == id)
				.Include(s => s.Questions)
					.ThenInclude(q => q.Options)
				.FirstOrDefaultAsync();
		}

		public async Task<bool> CreateSurveyAsync(SurveyViewModel model, ApplicationUser user)
		{
			var survey = new Survey()
			{
				Title = model.Title,
				Questions = model.Questions,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				UserId = user.Id
			};

			_context.Surveys.Add(survey);
			var saveResult = await _context.SaveChangesAsync();
			return saveResult > 1;
		}

		public async Task<bool> DeleteSurveyAsync(Survey survey, ApplicationUser user)
		{
			_context.Surveys.Remove(survey);
			var saveResult = await _context.SaveChangesAsync();
			return saveResult > 1;
		}
	}
}
