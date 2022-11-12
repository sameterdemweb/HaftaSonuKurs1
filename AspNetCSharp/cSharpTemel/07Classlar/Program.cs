namespace _07Classlar
{

    class Program
    {
        static void Main(string[] args)
        {
          
            AletCantam aletCantam = new AletCantam();
         
            string cumle = "Merhaba, Bu gün hava çooğğğğ güzel..";
            string yeniCumle = aletCantam.BuyukHarfCevir(cumle);
             yeniCumle = aletCantam.TurkceKarakterleriYokEt(yeniCumle);
            Console.WriteLine(yeniCumle);
            Console.WriteLine("############################");

            MusteriIslemleri musteriIslemleri = new MusteriIslemleri();
            musteriIslemleri.VeritabaninaEkle();
            Console.WriteLine("############################");
            int sonuc = musteriIslemleri.Toplama(4, 7);
            Console.WriteLine(sonuc);
            Console.WriteLine("############################");

            Console.WriteLine("Değer 1 Giriniz");
            int deger1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Değer 2 Giriniz");
            int deger2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(musteriIslemleri.Toplama(deger1,deger2));
            Console.WriteLine("############################");

            MatematikselIslemler matematikselIslemler = new MatematikselIslemler();
            int sonucToplama = matematikselIslemler.Toplama(deger1, deger2);
            int sonucCikartma = matematikselIslemler.Cikartma(deger1, deger2);
            Console.WriteLine(sonucToplama + " "+ sonucCikartma);



        }
    }
   
    class MusteriIslemleri
    {
        public int Toplama(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public void VeritabaninaEkle()
        {
            Console.WriteLine("Veritabanına veriler yazdırıldı.");
        }
    }



















    class MusteriIslemleri2
    {
        public void KayitYap()
        {
            Console.WriteLine("Kayıt İşlemi Yapıldı.");
        }

        public void KayitGuncelleme()
        {
            Console.WriteLine("Güncelleme İşlemi Yapıldı.");
        }

        public void KayitSilme()
        {
            Console.WriteLine("Silme İşlemi Yapıldı.");
        }

        public void ToplamaYap(int sayi1, int sayi2)
        {
            Console.WriteLine(sayi1 + sayi2);
        }

        public void CikartmaYap(int sayi1, int sayi2)
        {
            Console.WriteLine(sayi1 + sayi2);
        }
    }
}
