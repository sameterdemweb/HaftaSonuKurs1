using AdminPanel.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("FavoriUrunler")]
    public class FavoriUrunler
    {

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppIdentityUser? User { get; set; }

        public int UrunId { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urunler? Urunler { get; set; }


    }
}
