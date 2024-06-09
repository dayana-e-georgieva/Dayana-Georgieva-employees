using System.Globalization;

namespace CommonProjectsAmongEmpoyees.Models
{
	public static class DateTimeFormats
	{
		public static string[] Formats = {
				"yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd",
				"dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy",
				"MM-dd-yyyy", "MM/dd/yyyy", "MM.dd.yyyy",
				"MMMM dd, yyyy", "dd MMMM yyyy",
				"MM/dd/yy", "dd-MM-yy",
				"HH:mm", "HH:mm:ss", "HH:mm:ss.fff",
				"hh:mm tt", "hh:mm:ss tt", "hh:mm:ss.fff tt",
				"yyyy-MM-ddTHH:mm:ss", "yyyy/MM/dd HH:mm:ss", "dd-MM-yyyy HH:mm:ss",
				"MM/dd/yyyy hh:mm tt", "dd MMMM yyyy hh:mm:ss tt",
				"yyyy-MM-ddTHH:mm:ssZ", "yyyy-MM-ddTHH:mm:sszzz",
				"ddd, dd MMM yyyy HH:mm:ss GMT", "\"yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK\"",
				"yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss"
			};
	}
}
