namespace _12YapiciBloklar
{

    internal class Program
    {
        static void Main(string[] args)
        {

            MusteriIslemleri musteriIslemleri = new MusteriIslemleri(); // '()' default olarak constructor yapı bloğu methodu otomatik olarak çalışır

            musteriIslemleri.Kaydet();



            MusteriIslemleriTekrarla musteriIslemleriTekrarla = new MusteriIslemleriTekrarla(25); // '()' default olarak constructor yapı bloğu methodu otomatik olarak çalışır ve bir değer göndermezsek hata verir. Çünkü zorunlu olarak constructor yapı methodunda bizi bunu talep etik

            musteriIslemleriTekrarla.Tekrarla();
            musteriIslemleriTekrarla.EkranaYazdir();

            Console.ReadLine();
        }
    }
    class MusteriIslemleri
    {
        public MusteriIslemleri() //ctor tab kullanarak Constructor Yapıları eklenmesi. New ile çağırıldığı anda bu method otomatik olarak çalışır.
        {
            Console.WriteLine("Default girdi");
        }
        public void Kaydet()
        {
            Console.WriteLine("Kaydetme Yapıldı");
        }
        public void Sil()
        {
            Console.WriteLine("Silme Yapıldı");
        }
    }

    class MusteriIslemleriTekrarla
    {
        private int _sayi = 10;  //Field oluşturuldu. Alt çizgi ile başlatılır isimlendirme standartı olarak.
        public MusteriIslemleriTekrarla()
        {
        }
        public MusteriIslemleriTekrarla(int sayi)  // Yapı bloğunda int sayfa istediğimiz için newlendiğinde bir sayı değeri gönderilmek zorunda artık !!!
        {
            _sayi = sayi;
        }

        // Sayfalama yapılacak mesela sayfa sayfa data gelecek ise eğer sayfa sayısı belirtilmez ise sayfa sayısı=15 eğer tanımlanırken gelirse  gelen sayfa sayısı kadar veriyi çeken bir uygulama yapabiliriz.

        public void Tekrarla()
        {
            Console.WriteLine("Yapı bloğu(Contstructor) methoduyla newlendiği anda gönderilen sayı:{0} Newlenmesinden sonra oluşturulacak tüm işlemlerde bu sayı kullanılabilir.", _sayi);
        }

        public void EkranaYazdir()
        {
            for (int i = 1; i <= _sayi; i++)
            {
                Console.WriteLine("{0}- Merhaba", i);
            }
        }

    }
}
