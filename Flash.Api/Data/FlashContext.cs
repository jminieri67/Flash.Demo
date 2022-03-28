using Flash.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Flash.Api.Data
{
	public class FlashContext : DbContext
	{
		public DbSet<Location> Locations { get; set; }
		public DbSet<Lot> Lots { get; set; }

		public FlashContext(DbContextOptions<FlashContext> options)
			: base(options)
		{
		}
	}
}
