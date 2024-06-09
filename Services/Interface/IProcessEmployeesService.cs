using CommonProjectsAmongEmpoyees.Pages;

namespace CommonProjectsAmongEmpoyees.Services.Interface
{
    public interface IProcessEmployeesService
    {
        List<EmployeesInformation> FindEmployeesWorkedTogether(List<EmployeesInformation> projects);
    }
}