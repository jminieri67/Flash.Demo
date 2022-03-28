using Flash.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Flash.Demo.Controllers
{
	public class HomeController : Controller
	{
		private const string BASE_URL = "http://localhost:5240/";
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			List<Models.Location> items = new();

			using (var httpClient = new HttpClient())
			{
				swaggerClient? client = new(BASE_URL, httpClient);
				IEnumerable<Location> locations = await client.GetLocationsAsync();

				foreach (var location in locations)
				{
					items.Add(new()
					{
						Id = location.Id,
						Name = location.Name,
					});
				}
			}

			return View(items);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}