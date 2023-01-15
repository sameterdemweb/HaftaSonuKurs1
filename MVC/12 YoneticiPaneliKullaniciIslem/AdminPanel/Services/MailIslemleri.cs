using System.Net.Mail;

namespace AdminPanel.Services
{
    public class MailIslemleri
    {
        public static void MailGonderme(string icerik, string konu, string gidecekMail)
        {
            SmtpClient smtp = new SmtpClient(); // smtp nesnesi oluşturuyoruz
            /*
            * Nesnemizi oluşturduğumuza göre şimdi mail sunucumuzun adresini girelim
            * Gmail ile kimlik doğrulama sorunu yaşadığım için ben Outlook mail kullandım
            * Mail adresinizin smtp ayarlarını sunucunuzdan öğrenebilirsiniz
            */
            smtp.Host = "mail.sanalyonet.com"; // Mail sunucusu adresi
            smtp.Port = 587; // Outlook için 587
            smtp.EnableSsl = false; // Sunucu SSL kullanıyorsa True olacak
                                    // mail adresimizin kullanıcı adı ve parolasını yazıyoruz
            smtp.Credentials = new System.Net.NetworkCredential("kurs@sanalyonet.com", "123123112312");


            // eposta adında bir mail nesnesi oluştur
            MailMessage eposta = new MailMessage();
            // Giden mailde görünecek e-posta adresi ve isim email adresi smtp ile aynı olmayınca hata veriyor.
            eposta.From = new MailAddress("kurs@sanalyonet.com", "Site Mesaj");
            // Mail gönderilecek kişi(ler). Eğer birden fazla kişiye gidecekse, kişiler arasına virgül koyulacak
            // eposta.To.Add("furkanozden_1998@hotmail.com, gamzearici46@gmail.com, 4973443@gmail.com, ferhat.khyaa@gmail.com,mehmet59850@gmail.com, smt.e.59@gmail.com");
            eposta.To.Add(gidecekMail);
            // eposta.CC.Add("ism3@mail3.com, isim4@mail4.com"); // Bilgi maili gönerilecek kişileri CC özelliğine ekle
            //eposta.Bcc.Add("isim5@mail5.com"); // Gizli alıcıları bcc özelliğine ekle
            eposta.Subject = konu; // Mail konusunu subject özelliğine ekle
            eposta.Body = icerik; // mesaj içeriğini body özelliğine ekle
                                  // ekleri dosya yolu ile birlikte bir string dizisinde tutuyoruz

            try
            { // Hata kontrolü
                smtp.Send(eposta); // eposta nesnesini smtp.Send fonksiyonu ile gönder
            }
            catch (Exception ex)
            { // Hata oluştuysa oluşan hatayı ex değişkenine aktar
                string hata = "Mail gönderilirkene bir hata ile karşılaşıldı: " + ex.Message; // Hatayı kullanıcıya bildir
            }
        }

    }
}
