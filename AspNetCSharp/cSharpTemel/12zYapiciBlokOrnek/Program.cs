namespace _12zYapiciBlokOrnek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SORU: IslemYap classı newlendiğinde, eğer 2 adet değer gönderilir ise yapıcı blok (constructor)  ile Ekrana ikisinin toplamını eğer 1 adet değer gönderilirse değerin kendisini, hiç gönderilmezse de değer gönderilmedi yazsın.

            // SORU: IslemYap classı içerisinde EkranaYaz() Methodu kullanıldığında da sonuc sayisi kadar ekrana Merhaba Yazsın.
            IslemYap islemYap = new  IslemYap(5,6);
            islemYap.EkranaYaz();

        }
    }
    class IslemYap
    {
        private  int _sonuc=1;
        public IslemYap()
        {
            Console.WriteLine("Parametre Gelmedi.");
        }
        public IslemYap(int sayi1, int sayi2)
        {
            _sonuc = sayi1 + sayi2;
            Console.WriteLine("İki Sayının toplamı: {0}", _sonuc);
        }
        public IslemYap(int sayi1)
        {
            _sonuc = sayi1;
            Console.WriteLine("Gelen Parametre :{0}", _sonuc);
        }
        public void EkranaYaz() {
            for (int i = 0; i <=_sonuc ; i++)
            {
                Console.WriteLine("Merhaba {0}",i);
            }
        }
    }
}