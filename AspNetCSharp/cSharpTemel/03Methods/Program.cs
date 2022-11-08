namespace _03Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Program çalıştığı anda çalışan method içerisindeyim!");
            //Console.ReadLine();
            //Console.WriteLine("---------------------------------");

            //EkranaYaz();

            //Console.WriteLine("---------------------------------");
            //string gelenDeger = IsimGonder();
            //Console.WriteLine(gelenDeger);
            //Console.WriteLine("---------------------------------");
            //Console.ReadLine();

            //int toplamSonuc = Toplama(50, 100);
            //Console.WriteLine(toplamSonuc);
            //Console.WriteLine("---------------------------------");
            //double urunFiyat = 999.90;
            //int kDVOrani = 8;
            //double kDVUcreti = KdvHesapYap(urunFiyat, kDVOrani);
            //double toplamFiyat = urunFiyat + kDVUcreti;

            //Console.WriteLine("Ürün Fiyat: {0} Tl olan bir ürünün Kdv Oranı: {1}, Vergi Ücreti: {2} Tl Toplam Ücret:  {3} Tl", urunFiyat, kDVOrani, kDVUcreti, toplamFiyat);

            //Console.ReadLine();


            /* Örnek 1 Standart Method, Ekran Görüntüsü Nedir? */
            //int number1 = 40;
            //int number2 = 100;
            //int sonuc = OrnekTopla1(number1, number2);
            //Console.WriteLine(sonuc);
            //Console.WriteLine(number1);
            //Console.ReadLine();


            /*
            /*  Ref Keyword Method */
            //int number3 = 40;
            //int number4 = 100;
            //int sonuc2 = OrnekTopla2(ref number3, number4);

            //Console.WriteLine(sonuc2);
            //Console.WriteLine(number3);
            //Console.ReadLine();

            ///*  OutKeyword Method */
            //int number5;
            //int number6 = 100;
            //int sonuc3 = OrnekTopla3(out number5, number6);

            //Console.WriteLine(sonuc3);
            //Console.WriteLine(number5);
            //Console.ReadLine();

            /*   Params Keyword */


            Console.WriteLine(ToplamaIslemiToplu(200,1, 2, 23, 3, 59, 5, 6, 7, 8,95));
            Console.ReadLine();

        }
        /*  Params Keyword */
        static int ToplamaIslemiToplu(params int[] sayilar)
        {
            return sayilar.Sum();
        }

        static double KdvHesapYap(double Fiyat, int KdvOran)
        {
            return (Fiyat / 100) * KdvOran;
        }
        static int Toplama(int sayi1, int sayi2)
        {
            return sayi1+sayi2;
        }
        static void EkranaYaz()
        {
            Console.WriteLine("Samet ERDEM");
        }
        static string IsimGonder()
        {
            return "Ege Ali ERDEM";
        }

        /* Örnek 1 Standart Method */
        static int OrnekTopla1(int number1, int number2)
        {
            number1 = 50;
            int sonuc = number1 + number2;
            return sonuc;
        }

        /*  Ref Keyword Method */
        static int OrnekTopla2(ref int gelenSayi, int number4)
        {
            gelenSayi = 50;
            int sonuc = gelenSayi + number4;
            return sonuc;
        }
        /*  OutKeyword Method */
        static int OrnekTopla3(out int number1, int number2)
        {
            number1 = 60;
            int sonuc = number1 + number2;
            return sonuc;
        }
        /*  Method Overloading */
        static int OrnekTopla3(out int number1, int number2, int number3)
        {
            number1 = 60;
            int sonuc = number1 + number2 + number3;
            return sonuc;
        }

      


    }
}