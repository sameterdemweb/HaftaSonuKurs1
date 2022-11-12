using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07ClasslarNesneOlusturma
{
    class Musteri
    {
        public int Id { get; set; }  //"prop" yazıp 2 kere tıklarsak biz bir Müşterinin özelliklerini kullanmak için tuttuğumuz nesne
        private string _adi;
        public string Ad
        {
            get { return "Hoşgeldiniz: " + _adi; } //Değeri Okurken başına Hoşgeldin ekletiyoruz. 
            set { _adi = value; } // Değer geldiğinden _adi değişkenine ilgili değeri atıyoruz. ve okunduğunda get fonksiyonu geri değer gönderiyor.
        }

        public string Soyad; // Field
        public string Sehir { get; set; }

    }
}
