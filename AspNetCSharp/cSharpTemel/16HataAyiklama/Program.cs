
namespace _16HataAyiklama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            { // Try içerisine uygulamamızın kodlarını yazıyoruz Dene diyerek kodlarımız 
                string[] ogrenciler = new string[3] { "Samet", "Özge", "Ege" }; // 3 Elemanlı olduğu için endex değeri 2 de biter 

                ogrenciler[3] = "Muhittin";//  Endex değeri 3 olan bir eleman yok ! 

                Console.ReadLine();

            }
            catch (IndexOutOfRangeException hataBilgisi) //Hata türü IndexOutOfRangeException ise bu alan çalışır .
            {
                Console.ReadLine();
            }
            catch (Exception hataBilgisi)
            {  //Try içerisindeki kodlarımızda bir hata oluşması durumunda çalışacak olan kısım.

                Console.WriteLine("Hata Var Sorun: " + hataBilgisi.Message); //Hata Mesajına ulaşırız
                Console.WriteLine("Hata Var Satır ve Konum Bilgisi: " + hataBilgisi.StackTrace); //Hata ile ilgili satır ve konum bilgisini verir.
                Console.WriteLine("Hata Var Detay: " + hataBilgisi.InnerException); //Hata ile ilgili daha detaylı bilgi mevcut ise bunu verir.
                Console.WriteLine("Hata Var Yardım Linki: " + hataBilgisi.HelpLink); // Eğer hata ile ilgili çözümü gösteren bir makale tanımlanmış ise bunun linkini bize verir

                Console.ReadLine();
            }

            //KendiHataSinifimiziOlusturma();



            /* Action Delegasyonu ile profesyonel hata yakalama!  */
            HatayiIncele(() => { Kodlarim(); });  // Method yazıyoruz ve bu methoda sana bir method göndericem ve methodumum içeri bu diyerek gönderilecek methodu tanımlıyoruz.

        }


        private static void HatayiIncele(Action action) // Hayatımızda sadece 1 kere yazacağımız HatayıInceleme methodu static olarak tanımlayacağız! actionlar parametresiz methodlar sadece parametresiz methodlar ile kullanılır. Void operasyonlar için 
        {
            try
            {
                action.Invoke(); // Hatayıinceleme Methoduna gönderilen methodu çalıştırıyoruz. Try içinde olduğu için 1 kereye mahsus

                /* ######### Merkezi bir classın içerisine koyulan Hata ayıklama işlemini basitçe her yerde kullanabiliriz.*/
            }
            catch (Exception HataBilgisi)
            {
                Console.WriteLine(HataBilgisi.Message);
                Console.ReadLine();
            }
        }


        private static void Kodlarim()
        {
            List<string> nesneler = new List<string> { "Kalem", "Defter", "Silgi" };

            if (nesneler.Contains("Çanta"))
            {
                Console.WriteLine("Çanta Var");
            }
            else
            {
                throw new HataSinifimiz("Tanımlanan Nesnelerde aranan kelime bulunamadı.");//Eğer Çanta nesneler içerisinde yoksa false değerini gönderdi ve else kısmı çalıştı burada da kendi classımıza throw ile hatayı sıpıtıyoruz. Artık hata kodumuzdan geri gelecek mesaj bilgisi değişmiş oldu!
            }
        }



        private static void KendiHataSinifimiziOlusturma()
        {
            try
            {
                List<string> nesneler = new List<string> { "Kalem", "Defter", "Silgi" };


                if (nesneler.Contains("Çanta"))
                {
                    Console.WriteLine("Çanta Var");
                }
                else
                {
                    throw new HataSinifimiz("Tanımlanan Nesnelerde aranan kelime bulunamadı.");//Eğer Çanta nesneler içerisinde yoksa false değerini gönderdi ve else kısmı çalıştı burada da kendi classımıza throw ile hatayı sıpıtıyoruz. Artık hata kodumuzdan geri gelecek mesaj bilgisi değişmiş oldu!
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

   
    }
}
