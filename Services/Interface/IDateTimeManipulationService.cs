namespace CommonProjectsAmongEmpoyees.Services.Interface
{
	public interface IDateTimeManipulationService
	{
		bool TryParseDate(string dateString, out DateTime parsedDate);
	}
}