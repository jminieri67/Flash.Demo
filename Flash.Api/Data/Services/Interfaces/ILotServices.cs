using Flash.Api.Data.Models;

namespace Flash.Api.Services.Interfaces
{
	public interface ILotServices
	{
		IEnumerable<Lot> GetLocationLots(int locationId);
		Lot? GetLot(int lotId);
		Lot? IncrementVehicleCount(int lotId);
		Lot? DecrementVehicleCount(int lotId);
	}
}
