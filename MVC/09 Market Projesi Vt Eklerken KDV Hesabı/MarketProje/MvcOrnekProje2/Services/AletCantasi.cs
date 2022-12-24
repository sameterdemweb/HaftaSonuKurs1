namespace MvcOrnekProje2.Services
{
    public static class AletCantasi
    {
        public static double KdvliFiyatHesapla(double fiyat, double kdvOrani)
        {
            double kdvliFiyat = ((fiyat * kdvOrani) / 100) + fiyat;
            return kdvliFiyat;
        }

        public static double FiyatHesapla(int adet, double kdvliFiyat)
        {
            double genelToplamFiyat = kdvliFiyat * adet;
            return genelToplamFiyat;
        }
    }
}
