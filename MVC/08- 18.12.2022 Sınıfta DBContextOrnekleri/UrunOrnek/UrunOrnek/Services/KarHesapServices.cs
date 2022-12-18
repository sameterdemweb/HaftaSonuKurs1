namespace UrunOrnek.Services
{
    public static class KarHesapServices
    {
        public static double KarHesap(double birimFiyat,int adet)
        {
            double genelToplam=birimFiyat*adet;

            return genelToplam*0.20;
        }
    }
}
