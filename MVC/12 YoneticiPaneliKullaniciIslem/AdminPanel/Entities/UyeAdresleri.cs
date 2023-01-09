using AdminPanel.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("UyeAdresleri")]
    public class UyeAdresleri
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppIdentityUser? User { get; set; }
        public string AdresBaslik { get; set; }
        public string Address { get; set; }
        public string? PostalCode { get; set; }
        public string? CellPhone { get; set; }

        public virtual List<Siparisler>? Siparisler { get; set; }


    }
}
