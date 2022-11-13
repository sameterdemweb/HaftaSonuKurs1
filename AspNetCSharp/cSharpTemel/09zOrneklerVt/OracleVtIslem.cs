using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09zOrneklerVt
{
    internal class OracleVtIslem : IVeritabaniIslemleri
    {
        public void Duzenleme(Urunler urun)
        {
            Console.WriteLine("Oracle Veritabanına {0} isimli ürünün düzenlenme işlemi yapıldı.", urun.Adi);
        }

        public void Ekle(Urunler urun)
        {
            Console.WriteLine("Oracle Veritabanına {0} isimli ürünün ekleme işlemi yapıldı.", urun.Adi);
        }

        public void Listeleme(Urunler urun)
        {
            Console.WriteLine("Oracle Veritabanına {0} isimli ürünün Listeleme işlemi yapıldı.", urun.Adi);
        }

        public void Silme(Urunler urun)
        {
            Console.WriteLine("Oracle Veritabanına {0} isimli ürünün Silme işlemi yapıldı.", urun.Adi);
        }
    }
}
