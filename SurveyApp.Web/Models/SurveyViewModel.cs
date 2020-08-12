using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
	public class SurveyViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Title")]
		[Required(ErrorMessage = "Title is required.")]
		public string Title { get; set; }

		[Display(Name = "Created At")]
		public DateTime? CreatedAt { get; set; }

		[Display(Name = "Updated At")]
		public DateTime? UpdatedAt { get; set; }

		[Display(Name = "Questions")]
		public List<Question> Questions { get; set; }

		[Display(Name = "Answers")]
		public List<FilledSurvey> FilledSurveys { get; set; }
	}
}
