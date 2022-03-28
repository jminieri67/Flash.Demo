using Microsoft.AspNetCore.Mvc;

namespace Flash.Demo.Controllers
{
	public class LotController : Controller
	{
		const string BASE_URL = "http://localhost:5240/";

		public async Task<IActionResult> Index(int id)
		{
			List<Models.Lot> items = new();

			using (var httpClient = new HttpClient())
			{
				swaggerClient? client = new(BASE_URL, httpClient);
				ICollection<Lot> lots = await client.GetLocationLotsAsync(id);

				foreach (var lot in lots)
				{
					items.Add(new()
					{
						Id = lot.Id,
						Name = lot.Name,
						SpaceCount = lot.SpaceCount,
						VehicleCount = lot.VehicleCount,
						LocationId = lot.LocationId
					});
				}
			}

			return View(items);
		}

		public async Task<IActionResult> CheckIn(int id)
		{
			using (var httpClient = new HttpClient())
			{
				swaggerClient? client = new(BASE_URL, httpClient);
				Lot? lot = await client.IncrementVehicleCountAsync(id);
			}

			return View("CheckInCompete");
		}

		public async Task<IActionResult> CheckOut(int id)
		{
			using (var httpClient = new HttpClient())
			{
				swaggerClient? client = new(BASE_URL, httpClient);
				Lot? lot = await client.DecrementVehicleCountAsync(id);
			}

			return View("CheckOutCompete");
		}
	}
}
