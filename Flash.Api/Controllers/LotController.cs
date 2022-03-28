using Flash.Api.Data.Models;
using Flash.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flash.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LotController : ControllerBase
	{
		private readonly ILotServices LotServices;

		public LotController(ILotServices locationServices)
		{
			LotServices = locationServices;
		}

		[HttpGet("getLocationLots/{locationId}")]
		public IEnumerable<Lot> GetLocationLots(int locationId)
		{
			IEnumerable<Lot> lots = LotServices.GetLocationLots(locationId);

			return lots;
		}

		[HttpGet("getLot/{lotId}")]
		public Lot? GetLot(int lotId)
		{
			Lot? lot = LotServices.GetLot(lotId);

			return lot;
		}

		[HttpPost("incrementVehicleCount/{lotId}")]
		public Lot? IncrementVehicleCount(int lotId)
		{
			Lot? lot = LotServices.IncrementVehicleCount(lotId);

			return lot;
		}

		[HttpPost("decrementVehicleCount/{lotId}")]
		public Lot? DecrementVehicleCount(int lotId)
		{
			Lot? lot = LotServices.DecrementVehicleCount(lotId);

			return lot;
		}
	}
}
