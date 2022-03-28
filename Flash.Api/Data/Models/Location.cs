using System.ComponentModel.DataAnnotations;

namespace Flash.Api.Data.Models
{
	public class Location
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		public List<Lot> Lots { get; set; } = new List<Lot>();
	}
}
