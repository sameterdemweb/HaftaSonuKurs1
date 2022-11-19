namespace _13StaticClassveMethodlar
{

    internal class Program
    {
        static void Main(string[] args)
        {
            ClassimNewlenmez.sayi = 2;
            ClassimNewlenmez.sayi = 7; // Bellekte değişir ve tüm clientler aynı değeri alır.  Uzak durmamız gereken bir nesne türüdür.

            Islemler.EkranaYazStatic(); //Static newlenmeden direk sınıfın üzerinden tanımlanır.
            Console.WriteLine(ClassimNewlenmez.sayi);
            Console.ReadLine();

            string cumle= "Merhaba Arkadaşlar, Burada static olarak tanımlanmış AletCantam Classı içerisindeki static classlar ile işlem yapıyoruz.";

            string YeniCumle=aletCantam.BuyukHarfCevir(cumle);
            YeniCumle=aletCantam.TurkceKarakterleriYokEt(YeniCumle);

            Console.WriteLine(YeniCumle);
        }

        
    }

    static class ClassimNewlenmez // statik nesne newlenmeden kullanılabilir.
    {
        public static int sayi { get; set; }  //Field tanımlanırken Statik nesnelerde static etiketini eklemeliyiz.

    }

    class Islemler // Class static olursa alttaki tüm methodlarda static olmalıdır!
    {
        public void EkranaYaz()
        {
            Console.WriteLine("Merhaba Yazdım!");
        }

        public static void EkranaYazStatic()
        {

            Console.WriteLine("Merhaba Yazdım Static!!");
        }
    }

    static class StatikClassim
    {
        static StatikClassim() // static classsların constructor methodlarıda static olur !!
        {

        }
    }

}
