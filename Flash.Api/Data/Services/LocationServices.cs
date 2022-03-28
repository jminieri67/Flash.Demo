using Flash.Api.Data;
using Flash.Api.Data.Models;
using Flash.Api.Services.Interfaces;

namespace Flash.Api.Services
{
	public class LocationServices : ILocationServices
	{
		private readonly FlashContext Db;

		public LocationServices(FlashContext db)
		{
			Db = db;
		}
		
		public IEnumerable<Location> GetAllLocations() => 
			Db.Locations.ToList();
	}
}
