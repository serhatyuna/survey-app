using Microsoft.EntityFrameworkCore;
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

		public Task<Survey[]> GetAllSurveys(ApplicationUser user)
		{
			return _context.Surveys.Where(s => s.UserId == user.Id).ToArrayAsync();
		}
	}
}
