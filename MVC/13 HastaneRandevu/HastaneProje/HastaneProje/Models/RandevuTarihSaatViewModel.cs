using System.ComponentModel.DataAnnotations;

namespace HastaneProje.Models
{
    public class RandevuTarihSaatViewModel
    {
        public string DoktorId { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Tarih"), DataType(DataType.Date)]
        public DateTime Tarih { get; set; }
    }
}
