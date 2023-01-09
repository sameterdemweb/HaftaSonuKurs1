using AdminPanel.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel
{
    public class SiparisDetayViewModel
    {

        public Siparisler SiparisBilgi { get; set; }
        public List<SiparisDetay> SiparisDetay { get; set; }


       
    }
}