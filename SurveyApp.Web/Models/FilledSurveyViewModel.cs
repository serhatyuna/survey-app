using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Web.Models
{
	public class FilledSurveyViewModel
	{
		[Required]
		public string Email { get; set; }

		public DateTime CreatedAt { get; set; }

		public int SurveyId { get; set; }

		public Survey Survey { get; set; }

		public List<FilledSurveyOption> FilledSurveyOptions { get; set; }
	}
}
