using System.ComponentModel.DataAnnotations;

namespace MvcOdev.Entities
{
	public class Otopark
	{
		public int Id { get; set; }
		[Required]
		public int GirenArac { get; set; }
		[Required]
		public int CikanArac { get; set; }
		[Required]
		public int MevcutArac { get; set; }
		[Required]
		public int Saat { get; set; }

		public int? KalanArac { get; set; }
	}
}
