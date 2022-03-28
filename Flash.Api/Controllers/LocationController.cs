using Flash.Api.Data.Models;
using Flash.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flash.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly ILocationServices LocationServices;

		public LocationController(ILocationServices locationServices)
		{
			LocationServices = locationServices;
		}

		[HttpGet("getLocations")]
		public IEnumerable<Location> GetLocations()
		{
			IEnumerable<Location> locations = LocationServices.GetAllLocations();

			return locations;
		}
	}
}
