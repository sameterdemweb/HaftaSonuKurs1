namespace _04Diziler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] ogrenciler = new string[3]; // ogrenciler array inin yani dizisinin 3 endexe kadar elemanı olacak şekilde oluşturuyoruz.  

            //ogrenciler[0] = "Samet";
            //ogrenciler[1] = "Ege";
            //ogrenciler[2] = "Özge";
            ////ogrenciler[3] = "Mehmet";

           
            //foreach (var ogrenci in ogrenciler) //Foreach döngüsü ile ogrenciler içerisindeki tüm değerleri in ile ogrenci değişkenine tanımlyıoruz
            //{
            //    Console.WriteLine(ogrenci);
            //}

            //Console.ReadLine();



            //// Diziler 2. Kullanım örneği

            //string[] ogrenciler2 = new[] { "Samet", "Ege" }; // ogrenciler arrayının tek bir satır ile içerisine değerleri tanımlayabiliriz.

            //foreach (var ogrenci in ogrenciler2) //Foreach döngüsü ile ogrenciler içerisindeki tüm değerleri in ile ogrenci değişkenine tanımlyıoruz
            //{
            //    Console.WriteLine(ogrenci);
            //}

            //Console.ReadLine();


            //// Diziler 3. Kullanım örneği

            //string[] ogrenciler3 = { "Samet", "Özge", "Ege" }; // ogrenciler arrayının tek bir satır ile içerisine değerleri tanımlayabiliriz.

            //foreach (var ogrenci in ogrenciler3) //Foreach döngüsü ile ogrenciler içerisindeki tüm değerleri in ile ogrenci değişkenine tanımlyıoruz
            //{
            //    Console.WriteLine(ogrenci);
            //}

            //Console.ReadLine();

            //// Çok boyutlu diziler

            ////Ornek 1
            //string[,] bolgeler = new string[5, 3]; // 5 Satırdan ve 3 kolondan oluşan bir çok boyutlu dizi oluşturduk.


            // Ornek 2
            string[,] bolgeler2 = new string[7, 3]// 5 Satırdan ve 3 kolondan oluşan bir çok boyutlu dizi oluşturduk Süslü parantezler ile içeriğini doldurabiliriz.
            {
                {"İstanbul","Edirne","Tekirdağ" },  // Marmara Bölgesi ve 3 Örnek Şehir
                {"Ankara","Konya","Kırıkkale" },  // İç Anadolu Bölgesi ve 3 Örnek Şehir
                {"Antalya","Adana","Mersin" }, // Akdeniz Bölgesi ve 3 Örnek Şehir
                {"Rize","Trabzon","Samsun" }, // Karadeniz Bölgesi ve 3 Örnek Şehir
                {"İzmir","Muğla","Manisa" }, // Ege Bölgesi ve 3 Örnek Şehir
                {"Muş","Van","Kars" }, // Doğu Anadolu Bölgesi ve 3 Örnek Şehir
                {"Şanlıurfa","Mardin","Gaziantep" } // Güney Doğu Anadolu Bölgesi ve 3 Örnek Şehir
            };

            Console.WriteLine(bolgeler2[0, 2]);
            Console.WriteLine(bolgeler2[6, 0]);



           // Bu alana iç içe döngüleri gördükten sonra tekrar göz atacağız.

            for (int i = 0; i <= bolgeler2.GetUpperBound(0); i++) //  bolgeler2.GetUpperBound(0) Satırların en üst değerini bana verir. 
            {
                for (int j = 0; j <= bolgeler2.GetUpperBound(1); j++)//  bolgeler2.GetUpperBound(1) Sütununda yer alan en üst değerini bana verir. 
                {
                    Console.WriteLine(bolgeler2[i, j]);
                }
                Console.WriteLine("**************");
            }
            Console.ReadLine();

        }
    }
}
