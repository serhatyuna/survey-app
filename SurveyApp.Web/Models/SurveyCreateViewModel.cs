using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
	public class SurveyCreateViewModel
	{
		public int NumberOfQuestions { get; set; }

		public int NumberOfOptions { get; set; }
	}
}
