using CommonProjectsAmongEmpoyees.Models;
using CommonProjectsAmongEmpoyees.Services;
using CommonProjectsAmongEmpoyees.Services.Interface;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace CommonProjectsAmongEmpoyees.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		[BindProperty]
		public IFormFile UploadedFile { get; set; }

		public List<EmployeesProjectsInformation> EmployeesInfo { get; set; }

		public List<EmployeesInformation> EmployeesInformation { get; set; }

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			EmployeesInfo = new List<EmployeesProjectsInformation>();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (UploadedFile == null || UploadedFile.Length == 0 || !UploadedFile.FileName.EndsWith(".csv"))
			{
				ViewData["Message"] = "Please upload a valid CSV file.";
				return Page();
			}

			try
			{
				using (var reader = new StreamReader(UploadedFile.OpenReadStream()))
				{
					using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
					{
						EmployeesInfo = csv.GetRecords<EmployeesProjectsInformation>().ToList();
					}
				}
			}
			catch (Exception ex)
			{
				ViewData["Message"] = $"Error: {ex.Message}";
				return Page();
			}

			IDateTimeManipulationService dateTimeManipulationService = new DateTimeManipulationService();
			ProcessFile(dateTimeManipulationService);

			IProcessEmployeesService processEmployeesService = new ProcessEmployeesService();
			EmployeesInformation = processEmployeesService.FindEmployeesWorkedTogether(EmployeesInformation);

			if (EmployeesInformation.Count == 0)
			{
				ViewData["Message"] = "No employees worked together on any project.";
			}

			return Page();
		}

		private void ProcessFile(IDateTimeManipulationService dateTimeManipulationService)
		{
			EmployeesInformation = new();
			foreach (var employee in EmployeesInfo)
			{
				if (dateTimeManipulationService.TryParseDate(employee.DateFrom, out DateTime convertedDateFrom) && dateTimeManipulationService.TryParseDate(employee.DateTo, out DateTime convertedDateTo))
				{
					var employees = new EmployeesInformation
					{
						EmployeeID1 = employee.EmpID,
						ProjectID = employee.ProjectID,
						StartDate = convertedDateFrom,
						EndDate = convertedDateTo,
					};
					EmployeesInformation.Add(employees);
				}
				else
				{
					ViewData["Message"] = $"Coudn't parse the date from DateFrom/DateTo. Skipping record for EmpID: {employee.EmpID}";
				}

			}
		}
	}
}

