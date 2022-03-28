using System.ComponentModel.DataAnnotations;

namespace Flash.Api.Data.Models
{
	public class Lot
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int SpaceCount { get; set; }

        public int VehicleCount { get; set; }  

        public int LocationId { get; set; }
    }
}
