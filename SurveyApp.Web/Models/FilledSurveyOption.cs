using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
	public class FilledSurveyOption
	{
		public int FilledSurveyId { get; set; }

		public FilledSurvey FilledSurvey { get; set; }

		public int OptionId { get; set; }

		public Option Option { get; set; }
	}
}
