﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
	public class FilledSurvey
	{
		public int Id { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public DateTime CreatedAt { get; set; }

		public int SurveyId { get; set; }

		public Survey Survey { get; set; }

		public List<FilledSurveyOption> FilledSurveyOptions { get; set; }
	}
}
