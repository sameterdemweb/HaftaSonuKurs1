using MvcOdev.Entities;

namespace MvcOdev.Services
{
    public static class KitapSayfaHesapla
    {
        public static int KalanSayfaHesapla(int ilkGunOkunanSayfa, int herGunOkunanSayfa, int kitapSayfaSayisi)
        {

            int kitapSayfa = kitapSayfaSayisi;
            int kalanSayfaSayisi = kitapSayfa - ilkGunOkunanSayfa;
            int gun = 1;
            while (kalanSayfaSayisi > 0)
            {
                gun++;
                kalanSayfaSayisi -= herGunOkunanSayfa;
            }
            return gun;
        }
    }
}
