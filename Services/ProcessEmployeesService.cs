using CommonProjectsAmongEmpoyees.Pages;
using CommonProjectsAmongEmpoyees.Services.Interface;

namespace CommonProjectsAmongEmpoyees.Services
{
    public class ProcessEmployeesService : IProcessEmployeesService
	{
		public List<EmployeesInformation> FindEmployeesWorkedTogether(List<EmployeesInformation> projects)
		{
			var workedTogether = new List<EmployeesInformation>();

			foreach (var project in projects.GroupBy(p => p.ProjectID))
			{
				var employees = project.ToList();
				for (int i = 0; i < employees.Count; i++)
				{
					for (int j = i + 1; j < employees.Count; j++)
					{
						if (WorkedTogether(employees[i], employees[j], out int daysWorkedTogether))
						{
							var employee = new EmployeesInformation
							{
								EmployeeID1 = employees[i].EmployeeID1,
								EmployeeID2 = employees[j].EmployeeID1,
								ProjectID = project.Key,
								DaysWorked = daysWorkedTogether
							};

							workedTogether.Add(employee);
						}
					}
				}
			}

			return workedTogether;
		}

		private static bool WorkedTogether(EmployeesInformation emp1, EmployeesInformation emp2, out int daysWorkedTogether)
		{
			var start = emp1.StartDate > emp2.StartDate ? emp1.StartDate : emp2.StartDate;
			var end = emp1.EndDate < emp2.EndDate ? emp1.EndDate : emp2.EndDate;

			if (start < end)
			{
				daysWorkedTogether = (end - start).Days + 1;
				return true;
			}
			else
			{
				daysWorkedTogether = 0;
				return false;
			}
		}
	}
}
