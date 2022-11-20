namespace _17HataAyiklaMailGonder
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
            catch (Exception hataBilgisi)
            {  //Try içerisindeki kodlarımızda bir hata oluşması durumunda çalışacak olan kısım.
                string konu = "Yazdığınız Kurs Yazılımında Hata Var Samet BEY";
                string gonderilecekEPosta = "sameterdemweb@gmail.com";
                string mesajBilgisi = "<h1>Sistemde Hata Var, Hata Bilgileri:</h1><br/>";


                mesajBilgisi+= "<br/>Hata Var Sorun: " + hataBilgisi.Message ; //Hata Mesajına ulaşırız
                mesajBilgisi += "<br/>Hata  Satır ve Konum Bilgisi: " + hataBilgisi.StackTrace; //Hata ile ilgili satır ve konum bilgisini verir.
                mesajBilgisi += "<br/>Hata  Detay: " + hataBilgisi.InnerException; //Hata ile ilgili daha detaylı bilgi mevcut ise bunu verir.
                mesajBilgisi += "<br/>Hata Var Yardım Linki: " + hataBilgisi.HelpLink; // Eğer hata ile ilgili çözümü gösteren bir makale tanımlanmış ise bunun linkini bize verir



                AletCantam olusturdugumMethodlar = new();
                olusturdugumMethodlar.MailGonder(konu, gonderilecekEPosta, mesajBilgisi);


                konu = "Abuldulhamit Han";
                gonderilecekEPosta = "m.ulusoyyyy@gmail.com";
                mesajBilgisi = "TEst";
                olusturdugumMethodlar.MailGonder(konu, gonderilecekEPosta, mesajBilgisi);
                Console.WriteLine("Sistemde günclleme var çok çalışıyoruz sürekli güncel tutuyoruz.");

                Console.ReadLine();
            }
        }
    }
}