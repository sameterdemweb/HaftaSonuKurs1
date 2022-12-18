using Office.Entities;

namespace Office.Services
{
    public class FiyatHesapla
    {
        public double KDVHesap(double urunFiyat,int kdvOran) {

            return (urunFiyat/100)* kdvOran;
        }

        public double GenelToplamHesapla(int adet, double fiyat, double kdvFiyat)
        {
            return (kdvFiyat + fiyat) * adet;
        }
      
    }
}
