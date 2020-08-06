using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurveyApp.Web.Areas.Identity.Data;
using SurveyApp.Web.Models;
using SurveyApp.Web.Services;

namespace SurveyApp.Web.Controllers
{
	[Authorize]
	public class SurveyController : Controller
	{
		private readonly SurveyService _surveyService;
		private readonly UserManager<ApplicationUser> _userManager;

		public SurveyController(SurveyService surveyService, UserManager<ApplicationUser> userManager)
		{
			_surveyService = surveyService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null) return Challenge();
			var surveys = await _surveyService.GetAllSurveys(currentUser);

			var model = new SurveyListViewModel()
			{
				Surveys = surveys
			};

			return View(model);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Create")]
		[ValidateAntiForgeryToken]
		public IActionResult CreatePost(SurveyViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			return Ok();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
