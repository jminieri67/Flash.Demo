using Flash.Api.Data;
using Flash.Api.Data.Models;
using Flash.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Flash.Api.Services
{
	public class LotServices : ILotServices
	{
		private readonly FlashContext Db;

		public LotServices(FlashContext db)
		{
			Db = db;
		}

		public IEnumerable<Lot> GetLocationLots(int locationId) => 
			Db.Lots.Where(l => l.LocationId == locationId).ToList();

		public Lot? GetLot(int lotId) => 
			Db.Lots.FirstOrDefault(l => l.Id == lotId);

		public Lot? IncrementVehicleCount(int lotId)
		{
			Lot? lot = GetLot(lotId);

			if ((lot != null) && (lot.VehicleCount < lot.SpaceCount))
			{
				lot.VehicleCount++;
				Db.Update(lot);
				Db.SaveChanges();
			}

			return lot;
		}

		public Lot? DecrementVehicleCount(int lotId)
		{
			Lot? lot = GetLot(lotId);

			if ((lot != null) && (lot.VehicleCount > 0))
			{
				lot.VehicleCount--;
				Db.Update(lot);
				Db.SaveChanges();
			}

			return lot;
		}
	}
}
