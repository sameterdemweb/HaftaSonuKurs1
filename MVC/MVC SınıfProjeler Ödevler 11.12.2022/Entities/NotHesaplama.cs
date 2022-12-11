using System.ComponentModel.DataAnnotations;

namespace MvcOdev.Entities
{
	public class NotHesaplama
	{
		public int Id { get; set; }

		[Required]

		public int Vize { get; set; }
		[Required]

		public int Final { get; set; }
		[Required]

		public int YüzdeFinal { get; set; }

		public double? Ortalama { get; set; }

		public string? Durum { get; set; }
	}
}
