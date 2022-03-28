using Flash.Api.Data.Models;

namespace Flash.Api.Services.Interfaces
{
	public interface ILocationServices
	{
		IEnumerable<Location> GetAllLocations();
	}
}
