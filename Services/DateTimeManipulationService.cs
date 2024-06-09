using System.Globalization;
using CommonProjectsAmongEmpoyees.Models;
using CommonProjectsAmongEmpoyees.Services.Interface;

namespace CommonProjectsAmongEmpoyees.Services
{
    public class DateTimeManipulationService : IDateTimeManipulationService
	{
		public bool TryParseDate(string dateString, out DateTime parsedDate)
		{

			if (string.IsNullOrWhiteSpace(dateString))
			{
				dateString = DateTime.Now.ToString();
			}

			if (DateTime.TryParseExact(dateString, DateTimeFormats.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
			{
				return true;
			}

			return DateTime.TryParse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
		}
	}
}
