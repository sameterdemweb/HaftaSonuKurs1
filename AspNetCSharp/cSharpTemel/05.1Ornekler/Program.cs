namespace _05._1Ornekler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             AsalSayiMi(18);
             AsalSayiMi(22);
             AsalSayiMi(98);
             
            ToplamlariBul3eBolunen();*/
            // 1 ürünün adeti ile KDV'sini ekleyip fiyat bulma.

            int kdv = 18;

            UrunFiyatHesaplaKullanicidanDataAl(kdv);

        }

        private static void UrunFiyatHesaplaKullanicidanDataAl(int kdv)
        {
            Console.Write("Ürün Adını Giriniz; ");
            string adi = Console.ReadLine();
            Console.Write("Ürün Adet Giriniz; ");
            int adet = int.Parse(Console.ReadLine());
            Console.Write("Ürün Fiyat Giriniz; ");
            double fiyat = double.Parse(Console.ReadLine());

            double toplamFiyat = adet * fiyat;
            double kdvFiyat = (toplamFiyat * kdv) / 100;
            double genelToplam = toplamFiyat + kdvFiyat;

            Console.WriteLine("{0} İsimli Ürünün Adet Fiyatı;{1}, Alınan Adet;{2}, Toplam Fiyat;{3}, KDV fiyat;{4}, Ödemeniz Gereken Genel Toplam Fiyat {5}", adi, fiyat, adet, toplamFiyat, kdvFiyat, genelToplam);
        }

        private static void ToplamlariBul3eBolunen()
        {

            // 50 ile 100 arasındaki 3'e bölünen tam sayıları bulan program.

            int sayi1 = 50;
            int sayi2 = 100;
            int toplam = 0;

            for (int i = sayi1; i <= sayi2; i++)
            {
                if (i % 3 == 0)
                {
                    toplam += i;
                }
            }
            Console.WriteLine("{0} ile {1} arasında 3 tam bölünen sayıların toplamı: {2} ", sayi1, sayi2, toplam);
        }

        private static void AsalSayiMi(int sayi)
        {
            bool asalMi = true;
            for (int i = 2; i < sayi; i++)
            {
                if (sayi % i == 0)
                {
                    asalMi = false;
                    break;
                }
            }
            if (asalMi == true)
            {
                Console.WriteLine("Bu sayı asaldır");
            }
            else
            {
                Console.WriteLine("Bu sayı asal değildir");
            }
            Console.ReadLine();
        }
    }
}