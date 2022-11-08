namespace _01VeriTipleri
{
    internal class Program
    {


        enum Days  //enum veri tipi Magic Type
        {
            Pazartesi, Salı, Çarşamba, Perşembe, Cuma, Cumartesi, Pazar
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Merhaba İlk Consol Uygulamam !");
            Console.ReadLine();
       
            int number1 = 2147483647; //integer +2147483647 ve -2147483648 arasındaki sayıları ifade eder. Bellekte 32 bit yer kaplar
            int number2 = -2147483648; //integer +2147483647 ve -2147483648 arasındaki sayıları ifade eder. Bellekte 32 bit yer kaplar
            long number3 = 214748323232326427; //long 19 Karakterden oluşan sayıyı ifade eder. Bellekte 64 bit yer kaplar
            long number4 = -2134748323232648; //long 19 Karakterden oluşan sayıyı ifade eder. Bellekte 64 bit yer kaplar
            short number5 = -32768; //short -32768 ve 32767 Karakterden oluşan sayıyı ifade eder.  Bellekte 16 bit yer kaplar
            short number6 = 32767; //short  -32768 ve 32767 Karakterden oluşan sayıyı ifade eder.  Bellekte 16 bit yer kaplar
            byte number7 = 255;    //short 0 ile 255 Karakterden oluşan sayıyı ifade eder.  Bellekte 8 bit yer kaplar
            bool dogruMu = true; // Bool veri tipi, false yada true değerini alır sadece. 
            char karakter = 'S'; // char veri tipi, klavyenizde bulunan tek bir karakteri tutabilir.
            string karakterler = "Samet"; // string 5 karakterden oluşan bir dizi diyebiliriz. String kelime yazımları için uygundur.
            double number8 = 10.5; // dobule virgüllü olarak kullanabileceğimiz veri tipi ondalık sayıları kapsar.Vigülden sonra 15,16 karakter tutar. 64 Bitlik bellekte yer kaplar 
            decimal number9 = 4232124124.12323232m; //decimal virgülden sonra 28,29 basamaklı tane değer tutar. 128 bit yer tutar
            decimal number10 = 4232124124; //decimal virgülden sonra 28,29 tane değer tutar. 128 bit yer tutar
            var veriTipiNey = 10; // Atanmış olan değere göre otomatik veri tipi tanımlanmış olur.
            // veriTipiNey = "sadas"; // Daha önce bu değişken ismine integer tanımlandığı için sistem hata verir.
            var veriTipiNey2 = "Samet"; // Atanmış olan değere göre otomatik veri tipi tanımlanmış olur.

            Console.WriteLine("Sayı 1: " + number1 + " TL, Sayi 2: "+ number2+" TL");
            Console.WriteLine("Sayı 2: {0} TL, Sayi 2: {1} TL", number1, number2);
            Console.WriteLine("Sayı 3: {0}", number3);
            Console.WriteLine("Sayı 4: {0}", number4);
            Console.WriteLine("Sayı 5: {0}", number5);
            Console.WriteLine("Sayı 6: {0}", number6);
            Console.WriteLine("Sayı 7: {0}", number7);
            Console.WriteLine("Doğrumu {0}", dogruMu);
            Console.WriteLine("Karakter {0}", karakter);
            Console.WriteLine("Karakterler {0}", karakterler);
            Console.WriteLine("Karakterler {0}", karakterler[2]);
            Console.WriteLine("Sayı 8 {0}", number8);
            Console.WriteLine("Sayı 9 {0}", number9);
            Console.WriteLine("Sayı 10 {0}", number10);
            Console.WriteLine("Enum Tipi {0}", Days.Cuma);
            Console.WriteLine("Enum Tipi İndex  {0}", (int)Days.Cuma);
            Console.WriteLine("Veri Tipi:  {0}", veriTipiNey);
            Console.WriteLine("Veri Tipi 2:  {0}", veriTipiNey2);
            Console.ReadLine();



        }
    }
}