using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace _17HataAyiklaMailGonder
{
    internal class AletCantam
    {

        public  void MailGonder(string konu, string gonderilecekEPosta, string mesajBilgisi)
        {

            int simdikiSaat = DateTime.Now.Hour;


            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            sc.Credentials = new NetworkCredential("12312312312", "1231231231");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("12312312312", "Ekranda Görünecek İsim");

            mail.To.Add("alici1@mail.com");
            mail.To.Add("alici2@mail.com");

            mail.CC.Add("alici3@mail.com");
            mail.CC.Add("alici4@mail.com");

            mail.Subject = "E-Posta Konusu"; mail.IsBodyHtml = true; mail.Body = "E-Posta İçeriği";

            mail.Attachments.Add(new Attachment(@"C:\Rapor.xlsx"));
            mail.Attachments.Add(new Attachment(@"C:\Sonuc.pptx"));

            sc.Send(mail);
        }
    }
}
