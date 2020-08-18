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
			var surveys = await _surveyService.GetAllSurveysAsync(currentUser);

			var model = new SurveyListViewModel()
			{
				Surveys = surveys
			};

			return View(model);
		}

		public IActionResult Create(SurveyCreateViewModel model)
		{
			int maxQuestions = 15;
			int maxOptions = 10;

			bool isInvalid = model == null
				|| model.NumberOfQuestions <= 0
				|| model.NumberOfOptions <= 1
				|| model.NumberOfQuestions > maxQuestions
				|| model.NumberOfOptions > maxOptions;

			if (isInvalid) return NotFound();

			ViewBag.Numbers = model;
			return View();
		}

		[HttpPost]
		[ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreatePost([Bind("Id", "Title", "Questions")] SurveyViewModel model)
		{
			if (!ModelState.IsValid)
			{
				string messages = string.Join("; ", ModelState.Values
																				.SelectMany(x => x.Errors)
																				.Select(x => x.ErrorMessage));

				return RedirectToAction("Create");
			}

			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null) return Challenge();

			var isSuccessful = await _surveyService.CreateSurveyAsync(model, currentUser);

			if (!isSuccessful)
			{
				return RedirectToAction("Create");
			}

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null) return Challenge();

			if (id <= 0) return RedirectToAction("Index");

			var survey = await _surveyService.GetSurveyOfUserByIdAsync(id, currentUser);

			if (survey == null) return RedirectToAction("Index");

			await _surveyService.DeleteSurveyAsync(survey, currentUser);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Details(int id)
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null) return Challenge();

			if (id <= 0) return RedirectToAction("Index");

			var survey = await _surveyService.GetSurveyOfUserByIdAsync(id, currentUser);

			if (survey == null) RedirectToAction("Index");

			var model = new SurveyViewModel()
			{
				Id = survey.Id,
				Title = survey.Title,
				CreatedAt = survey.CreatedAt,
				UpdatedAt = survey.UpdatedAt,
				Questions = survey.Questions,
				FilledSurveys = survey.FilledSurveys
			};

			return View(model);
		}

		[AllowAnonymous]
		public async Task<IActionResult> Answer(int id)
		{
			if (id <= 0) return RedirectToAction("Index", "Home");

			var survey = await _surveyService.GetSurveyByIdAsync(id);

			if (survey == null) RedirectToAction("Index", "Home");

			var surveyModel = new SurveyViewModel()
			{
				Id = survey.Id,
				Title = survey.Title,
				CreatedAt = survey.CreatedAt,
				UpdatedAt = survey.UpdatedAt,
				Questions = survey.Questions,
				FilledSurveys = survey.FilledSurveys
			};

			var filledSurveyModel = new FilledSurveyViewModel()
			{
				Survey = survey
			};

			var tupleModel = new Tuple<SurveyViewModel, FilledSurveyViewModel>(surveyModel, filledSurveyModel);

			return View(tupleModel);
		}

		[AllowAnonymous]
		[HttpPost]
		[ActionName("Answer")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AnswerPost(FilledSurveyViewModel model)
		{
			if (!ModelState.IsValid)
			{
				string messages = string.Join("; ", ModelState.Values
																				.SelectMany(x => x.Errors)
																				.Select(x => x.ErrorMessage));

				return RedirectToAction("Answer");
			}

			var isEmailUsed = await _surveyService.isEmailAnsweredSurvey(model.Email, model.SurveyId);

			if (isEmailUsed) return RedirectToAction("Answer"); // TODO: implement an error structure

			var isSuccessful = await _surveyService.CreateFilledSurveyAsync(model);

			if (!isSuccessful)
			{
				return RedirectToAction("Answer");
			}
			return RedirectToAction("Index", "Home");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
