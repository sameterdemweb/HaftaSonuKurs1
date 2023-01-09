using AdminPanel.Entities;

namespace AdminPanel.Models
{
    public class OrderVM
    {
        public Siparisler Siparis { get; set; }
        public List<SiparisDetay> SiparisDetaylari { get; set; }
    }
}
