using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
	public class Option
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		public int QuestionId { get; set; }

		public Question Question { get; set; }

		public List<FilledSurveyOption> FilledSurveyOptions { get; set; }
	}
}
