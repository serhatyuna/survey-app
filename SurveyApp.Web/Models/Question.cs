using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
	public class Question
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		public int SurveyId { get; set; }

		public Survey Survey { get; set; }

		public List<Option> Options { get; set; }
	}
}
